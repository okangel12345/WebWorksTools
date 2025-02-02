using Spiderman;
using System.Collections;
using System.Diagnostics;
using System.Reflection;

namespace Spandex
{
    public partial class Form1 : Form
    {
        public Material[] materials;
        public Dictionary<uint, GridEntry> textures { get; set; }
        public Dictionary<uint, GridEntry[]> values { get; set; }
        public HashSet<string> texturelist;
        public HashSet<string> materialgraphlist;
        string lastsourcedir, lastoutputdir, lastsavefile;
        bool _openWith;

        string _hashesOption;

        byte[] fileMagicNumber;

        public Form1(string[] argv, string WebWorksHashes = null)
        {
            InitializeComponent();
            materials = new Material[2];
            comboBox1.Items.Add("Marvel's Spider-Man Remastered");
            comboBox1.Items.Add("Marvel's Spider-Man: Miles Morales");

            if (WebWorksHashes != null)
            {
                _hashesOption = WebWorksHashes;
            }
            else
            {
                _hashesOption = "hashes.txt";
            }

            textures = new Dictionary<uint, GridEntry>();
            stringGrid.DataSource = textures.Values.ToList();
            stringGrid.AutoResizeColumns();

            values = new Dictionary<uint, GridEntry[]>();
            valueGrid.DataSource = textures.Values.ToList();
            valueGrid.CellValueChanged += ValueGrid_CellValueChanged;

            if (argv.Length > 0 && File.Exists(argv[0]))
                Open(argv[0]);

            this.Text = $"Spandex v{Assembly.GetExecutingAssembly().GetName().Version.ToString(3)}";
            statusLabel.Image = global::Spandex.Properties.Resources.warning;
            statusLabel.Text = $"layout.csv / {_hashesOption} weren't found, autocomplete is disabled";

            LoadTextureStrings();

            if (_openWith)
            {
                Open();
            }

            WebWorksShared.ToolboxStyle.ApplyToolBoxStyle(this, Handle);

            if (Screen.PrimaryScreen.WorkingArea.Width > this.Width)
            {
                float scale = 0.6f * Screen.PrimaryScreen.WorkingArea.Width / this.Width;
                this.Width = (int)(scale * Width);
                this.Height = (int)(scale * Height);
            }
        }


        private void openbutton_Click(object sender, EventArgs e)
        {
            Open();
        }

        private byte[] originalBinary;

        private bool resizedSplit = true;

        private void LoadTextureStrings()
        {
            texturelist = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            materialgraphlist = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            if (File.Exists("layout.csv"))
            {
                using (var reader = new StreamReader("layout.csv"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var commaIndex = line.IndexOf(',');
                        if (commaIndex >= 0)
                        {
                            var s = line.Substring(0, commaIndex).Replace("\"", "").Trim();
                            if (!string.IsNullOrEmpty(s))
                            {
                                if (s.EndsWith(".texture", StringComparison.OrdinalIgnoreCase))
                                    texturelist.Add(s);
                                else if (s.EndsWith(".materialgraph", StringComparison.OrdinalIgnoreCase))
                                    materialgraphlist.Add(s);
                            }
                        }
                    }
                }

                statusLabel.Image = Properties.Resources.ok;
                statusLabel.Text = "Loaded layout.csv";
                label1.Text = "Autocompleting with layout.csv";
            }
            else if (File.Exists(_hashesOption))
            {
                using (var reader = new StreamReader(_hashesOption))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var fields = line.Split(',');
                        if (fields.Length >= 2)
                        {
                            var texturePath = fields[1].Trim().Replace("\\", "/");

                            if (texturePath.EndsWith(".texture", StringComparison.OrdinalIgnoreCase))
                            {
                                texturelist.Add(texturePath);
                            }
                            else if (texturePath.EndsWith(".materialgraph", StringComparison.OrdinalIgnoreCase))
                            {
                                materialgraphlist.Add(texturePath);
                            }
                        }
                    }
                }

                statusLabel.Image = Properties.Resources.ok;
                statusLabel.Text = $"Loaded {_hashesOption}";
                label1.Text = $"Autocompleting with {_hashesOption}";
            }
            else
            {
                statusLabel.Image = Properties.Resources.warning;
                statusLabel.Text = "No valid data found.";
                label1.Text = $"No layout.csv or {_hashesOption} found.";
            }
        }




        public void Open(string filename = "")
        {
            this.Text = $"Spandex v{Assembly.GetExecutingAssembly().GetName().Version.ToString(3)}";
            textures = new Dictionary<uint, GridEntry>();
            values = new Dictionary<uint, GridEntry[]>();
            statusLabel.Image = null;
            statusLabel.Text = "Open a material file";
            savebutton.Enabled = false;

            var f = new OpenFileDialog();
            f.Filter = "Material asset|*.material;*.materialgraph";
            if (lastsourcedir is not null)
                f.InitialDirectory = lastsourcedir;
            f.FileName = filename;

            if (f.FileName != "" || f.ShowDialog() == DialogResult.OK)
            {
                UseWaitCursor = true;
                Application.DoEvents();

                // Read magic and store as bytes

                byte[] fileData = File.ReadAllBytes(f.FileName);

                if (fileData.Length >= 0x2C)  // Ensure there's enough data
                {
                    fileMagicNumber = fileData.Skip(0x28).Take(4).ToArray();
                }

                lastsourcedir = Path.GetDirectoryName(f.FileName) + @"\";
                lastsavefile = Path.ChangeExtension(Path.GetFileName(f.FileName), $".modified{Path.GetExtension(f.FileName)}");

                ProcessFile(f.FileName, 0);
                originalBinary = File.ReadAllBytes(f.FileName);

                // Detect magic number and set ComboBox selection
                bool isMaterialGraph = Path.GetExtension(f.FileName).Equals(".materialgraph", StringComparison.OrdinalIgnoreCase);

                if (isMaterialGraph)
                {
                    byte[] magicNumber = new byte[4];
                    Array.Copy(originalBinary, 0, magicNumber, 0, 4);
                    SetComboBoxSelection(magicNumber);
                }
                else
                {
                    byte[] magicNumber = new byte[4];
                    Array.Copy(originalBinary, 0, magicNumber, 0, 4);
                    SetComboBoxSelection(magicNumber);
                }

                savebutton.Enabled = true;

                if (textures.ContainsKey(0) && textures[0].Value != null && textures[0].Value != "")
                {
                    string trytemplate = lastsourcedir + (textures[0].Value as string).Replace('\\', '_').Replace('/', '_');
                    if (File.Exists(trytemplate))
                    {
                        ProcessFile(trytemplate, 1);
                        statusLabel.Image = global::Spandex.Properties.Resources.ok;
                        statusLabel.Text = $"Template loaded: {trytemplate}";
                    }
                    else
                    {
                        statusLabel.Image = global::Spandex.Properties.Resources.warning;
                        statusLabel.Text = $"Template could not be found: {trytemplate}";
                    }
                }
                else
                {
                    statusLabel.Image = global::Spandex.Properties.Resources.ok;
                    statusLabel.Text = $"Material loaded";
                }

                UseWaitCursor = false;
                this.Text = $"{materials[0].assetfile} - Spandex v{Assembly.GetExecutingAssembly().GetName().Version.ToString(3)}";

                // Okangel: set file path to new field
                textBox_FileLoaded.Text = $"{materials[0].assetfile}";

                if (resizedSplit)
                {
                    Size currentSize = splitContainer1.Size;

                    splitContainer1.Size = new Size(currentSize.Width, currentSize.Height - 25);

                    Point currentLocation = splitContainer1.Location;

                    splitContainer1.Location = new Point(currentLocation.X, currentLocation.Y + 25);

                    resizedSplit = false;
                }
            }

            stringGrid.DataSource = textures.Values.
                OrderBy(v => v.ID).
                ToList();
            stringGrid.AutoResizeColumns();

            valueGrid.DataSource = values.Values.
                SelectMany(v => v).
                OrderBy(v => v.Type == GridEntry.TypeOrder.Integer ? 1 : 0).
                ThenBy(v => v.ID).
                ToList();
            valueGrid.AutoResizeColumns();
        }

        private byte[] ReplaceBytesAtOffset(byte[] data, int offset, byte[] newBytes)
        {
            byte[] result = new byte[data.Length];
            Array.Copy(data, result, data.Length);
            Array.Copy(newBytes, 0, result, offset, newBytes.Length);
            return result;
        }

        private void ProcessFile(string filename, int entry)
        {
            materials[entry] = new Material(filename);
            Material material = materials[entry];
            var slotoverride = entry > 0 ? GridEntry.SLOTEXTERNAL : GridEntry.SLOTOVERRIDE;
            var slotshader = entry > 0 ? GridEntry.SLOTEXTERNAL : GridEntry.SLOTINTERNAL;

            var tl = material.GetSection<Material.ShaderTextures>();
            if (tl == null)
            {
                if (material.segments.Length > 0)
                {
                    (var segstrings, var segoffsets) = Material.UnpackStrings(material.segments[0].data);
                    if (segstrings.Count == 1)
                    {
                        textures.TryAdd(0, new GridEntry { ID = 0 });
                        textures[0].values[slotoverride].Value = segstrings[0];
                    }
                }
            }
            else if (tl.entries.Count > 0)
            {
                var dataseg = material.sectionlayout.GetSectionByOffset(((Material.ShaderTextures.ShaderTextureEntry)tl.entries[0]).nameoffset);
                if (dataseg != null)
                {
                    (var segstrings, var segoffsets) = Material.UnpackStrings(dataseg.data);
                    if (segoffsets.Where(s => s != 0).SequenceEqual(tl.entries.Values.Cast<Material.ShaderTextures.ShaderTextureEntry>().Select(s => s.nameoffset - dataseg.offset).Where(s => s != 0)))
                    {
                        if (dataseg is Material.Headerless)
                            ((Material.Headerless)dataseg).moveable = true;

                        int currentstr = 0;
                        if (((Material.ShaderTextures.ShaderTextureEntry)tl.entries[0]).nameoffset != dataseg.offset)
                        {
                            textures.TryAdd(0, new GridEntry { ID = 0 });
                            textures[0].values[slotoverride].Value = segstrings[currentstr++];
                        }

                        for (int i = 0; i < tl.entries.Count; i++)
                        {
                            var v = (Material.ShaderTextures.ShaderTextureEntry)tl.entries[i];
                            if (v.nameoffset != segoffsets[currentstr] + dataseg.offset)
                                throw new Exception("Parsing assumption failure");
                            textures.TryAdd(v.InputID, new GridEntry { ID = v.InputID });
                            textures[v.InputID].values[slotshader].Slot = (uint)i;
                            textures[v.InputID].values[slotshader].Value = segstrings[currentstr++];
                        }
                    }
                }
            }

            var material8 = material.GetSection<Material.ShaderOverrides>();
            if (material8 != null)
            {
                for (uint i = 0; i < material8.Textures.Count; i++)
                {
                    var s = material8.Textures.Cast<DictionaryEntry>().ElementAt((int)i);
                    textures.TryAdd((uint)s.Key, new GridEntry { ID = (uint)s.Key });
                    textures[(uint)s.Key].values[slotoverride].Slot = i;
                    textures[(uint)s.Key].values[slotoverride].Value = (string)s.Value;
                }

                for (uint i = 0; i < material8.Floats.Count; i++)
                {
                    var s = material8.Floats.Cast<DictionaryEntry>().ElementAt((int)i);
                    List<object> vs = null;

                    GridEntry.TypeOrder? type = null;
                    switch (s.Value)
                    {
                        case float[]:
                            vs = ((float[])s.Value).Cast<object>().ToList();
                            type = GridEntry.TypeOrder.Float;
                            break;
                        case ushort[]:
                            vs = ((ushort[])s.Value).Cast<object>().ToList();
                            type = GridEntry.TypeOrder.Short;
                            break;
                        case byte[]:
                            vs = ((byte[])s.Value).Cast<object>().ToList();
                            type = GridEntry.TypeOrder.Byte;
                            break;

                    }

                    values.TryAdd((uint)s.Key, new GridEntry[vs.Count]);
                    var varray = values[(uint)s.Key];
                    for (int j = 0; j < vs.Count; j++)
                    {
                        if (varray[j] == null)
                        {
                            varray[j] = new GridEntry();
                            varray[j].Span = vs.Count > 1 ? j / (float)(vs.Count - 1) : null;
                            varray[j].ID = (uint)s.Key;
                        }

                        varray[j].values[slotoverride].Slot = i;
                        varray[j].Type = type;
                        varray[j].values[slotoverride].Value = vs[j];
                    }
                }

                for (uint i = 0; i < material8.Ints.Count; i++)
                {
                    var n = material8.Ints.Cast<DictionaryEntry>().ElementAt((int)i);
                    values.TryAdd((uint)n.Key, new GridEntry[1]);
                    var varray = values[(uint)n.Key];
                    varray[0] = new GridEntry();
                    varray[0].ID = (uint)n.Key;
                    varray[0].Type = GridEntry.TypeOrder.Integer;
                    varray[0].values[slotoverride].Slot = i;
                    varray[0].values[slotoverride].Value = n.Value;
                }
            }

            var shaderfloats = material.GetSection<Material.ShaderFloats>();
            if (shaderfloats != null)
            {
                for (uint i = 0; i < shaderfloats.definitions.Length; i++)
                {
                    var c = shaderfloats.definitions[i];
                    var v = shaderfloats.values[(int)i];
                    List<object> vs = new List<object>();

                    GridEntry.TypeOrder? type = null;
                    switch (v)
                    {
                        case float[]:
                            vs = ((float[])v).Cast<object>().ToList();
                            type = GridEntry.TypeOrder.Float;
                            break;
                        case ushort[]:
                            vs = ((ushort[])v).Cast<object>().ToList();
                            type = GridEntry.TypeOrder.Short;
                            break;
                        case byte[]:
                            vs = ((byte[])v).Cast<object>().ToList();
                            type = GridEntry.TypeOrder.Byte;
                            break;

                    }

                    //values.TryAdd((uint)c.ID, new GridEntry[vs.Count]);
                    //var varray = values[(uint)c.ID];
                    //for (int j = 0; j < vs.Count; j++)
                    //{
                    //    if (varray[j] == null)
                    //    {
                    //        varray[j] = new GridEntry();
                    //        varray[j].Span = vs.Count > 1 ? j / (float)(vs.Count - 1) : null;
                    //        varray[j].ID = (uint)c.ID;
                    //    }

                    //    varray[j].values[slotshader].Slot = i;
                    //    varray[j].Type = type;
                    //    varray[j].values[slotshader].Value = vs[j];
                    //}

                    values.TryAdd(c.ID, new GridEntry[vs.Count]);
                    var varray = values[c.ID];

                    for (int j = 0; j < vs.Count; j++)
                    {
                        if (varray.Length <= j)
                        {
                            Array.Resize(ref varray, j + 1);
                        }

                        if (varray[j] == null)
                        {
                            varray[j] = new GridEntry();
                            varray[j].Span = vs.Count > 1 ? j / (float)(vs.Count - 1) : null;
                            varray[j].ID = c.ID;
                        }

                        varray[j].values[slotshader].Slot = i;
                        varray[j].Type = type;
                        varray[j].values[slotshader].Value = vs[j];
                    }

                }
            }

            var shaderints = material.GetSection<Material.ShaderIntegers>();
            if (shaderints != null)
            {
                for (int i = 0; i < shaderints.integers.Count; i++)
                {
                    uint v = ((uint)shaderints.integers[i]);
                    var id = shaderints.integers.Keys.Cast<uint>().ElementAt(i);

                    values.TryAdd(id, new GridEntry[1]);
                    values[id][0] ??= new GridEntry();
                    values[id][0].ID = id;
                    values[id][0].Type = GridEntry.TypeOrder.Integer;
                    values[id][0].values[slotshader].Slot = (uint)i;
                    values[id][0].values[slotshader].Value = v;
                }
            }
        }

        private byte[] GetMagicNumber(string filename)
        {
            byte[] magicNumber;
            bool isMaterialGraph = Path.GetExtension(filename).Equals(".materialgraph", StringComparison.OrdinalIgnoreCase);

            if (isMaterialGraph)
            {
                // Values for .materialgraph files
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        // Replace the first 4 bytes with the magic number for Marvel's Spider-Man Remastered (materialgraph)
                        magicNumber = new byte[] { 0xE3, 0x03, 0xD7, 0x07 }; // Example values
                        break;
                    case 1:
                        // Replace the first 4 bytes with the magic number for Marvel's Spider-Man: Miles Morales (materialgraph)
                        magicNumber = new byte[] { 0x2A, 0x34, 0x60, 0xFF }; // Example values
                        break;
                    //default:
                    //throw new InvalidOperationException("Invalid option selected in ComboBox1");
                    default:
                        // Default to the magic number for Marvel's Spider-Man: Miles Morales (materialgraph)
                        magicNumber = new byte[] { 0x5B, 0xDC, 0x1A, 0x1C };
                        break;
                }
            }
            else
            {
                // Values for .material files
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        // Replace the first 4 bytes with the magic number for Marvel's Spider-Man Remastered (material)
                        magicNumber = new byte[] { 0x8C, 0xEF, 0x04, 0x1C };
                        break;
                    case 1:
                        // Replace the first 4 bytes with the magic number for Marvel's Spider-Man: Miles Morales (material)
                        magicNumber = new byte[] { 0x9C, 0x7E, 0x75, 0x18 };
                        break;
                    //default:
                    //throw new InvalidOperationException("Invalid option selected in ComboBox1");
                    default:
                        // Default to the magic number for Marvel's Spider-Man: Miles Morales (material)
                        magicNumber = new byte[] { 0x68, 0x67, 0x6C, 0x4C };
                        break;

                }
            }
            return magicNumber;
        }

        private void SetComboBoxSelection(byte[] magicNumber)
        {
            if (magicNumber.SequenceEqual(new byte[] { 0x8C, 0xEF, 0x04, 0x1C }))
            {
                comboBox1.SelectedIndex = 0; // Marvel's Spider-Man Remastered
            }
            else if (magicNumber.SequenceEqual(new byte[] { 0x9C, 0x7E, 0x75, 0x18 }))
            {
                comboBox1.SelectedIndex = 1; // Marvel's Spider-Man: Miles Morales
            }
            else if (magicNumber.SequenceEqual(new byte[] { 0xE3, 0x03, 0xDC, 0x07 }))
            {
                comboBox1.SelectedIndex = 0; // Marvel's Spider-Man Remastered
            }
            else if (magicNumber.SequenceEqual(new byte[] { 0x2A, 0x34, 0x60, 0xFF }))
            {
                comboBox1.SelectedIndex = 1; // Marvel's Spider-Man: Miles Morales
            }
            else
            {
                comboBox1.SelectedIndex = -1; // Unknown magic number
            }
        }

        private void savebutton_Click(object sender, EventArgs e)
        {
            var material = materials[0];

            var f = new SaveFileDialog();
            switch (material.ps4header.type)
            {
                case Material.SectionType.SM_MATERIALTEMPLATE:
                case Material.SectionType.MM_MATERIALTEMPLATE:
                    f.Filter = "Material template asset|*.materialgraph";
                    break;
                default:
                    f.Filter = "Material asset|*.material";
                    break;
            }
            if (lastoutputdir is not null)
                f.InitialDirectory = Path.GetDirectoryName(lastoutputdir);
            f.FileName = lastsavefile;

            if (f.ShowDialog() == DialogResult.OK)
            {
                lastoutputdir = Path.GetDirectoryName(f.FileName) + @"\";
                lastsavefile = f.FileName;
                UseWaitCursor = true;
                Application.DoEvents();

                if (material.assetfile == f.FileName)
                {
                    MessageBox.Show("Can't overwrite the original. Choose a new filename.", "Aborted", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                // reset
                materials[0] = new Material(material.assetfile);
                material = materials[0];


                var tl = material.GetSection<Material.ShaderTextures>();
                var datastrings = new List<string>();
                var material8 = material.GetSection<Material.ShaderOverrides>();
                Material.SectionHeader dataseg = tl == null ? (material.segments.Length > 0 ? material.segments[0] : null) : material.sectionlayout.GetSectionByOffset(((Material.ShaderTextures.ShaderTextureEntry)tl.entries[0]).nameoffset);

                if (textures.ContainsKey(0))
                    datastrings.Add((string?)textures[0].values[GridEntry.SLOTOVERRIDE].Value ?? String.Empty);

                foreach (var kv in textures)
                {
                    if (kv.Key == 0)
                        continue;

                    if (tl != null)
                    {
                        if (kv.Value.values[GridEntry.SLOTINTERNAL].Slot != null)
                            datastrings.Add(((string?)kv.Value.values[GridEntry.SLOTINTERNAL].Value) ?? String.Empty);
                    }

                    if (material8 != null)
                    {
                        if (!removeUndefTextures.Checked || materials[1] == null || kv.Value.values[GridEntry.SLOTEXTERNAL].Slot != null)
                            material8.Textures[kv.Key] = kv.Value.values[GridEntry.SLOTOVERRIDE].Value ?? String.Empty;
                        else if (material8.Textures.Contains(kv.Key))
                            material8.Textures.Remove(kv.Key);
                    }
                }

                if (dataseg != null)
                {
                    (dataseg.newdata, var offsets) = Material.PackStrings(datastrings);

                    if (tl != null)
                    {
                        offsets = offsets.Skip(offsets.Length - tl.entries.Count).ToArray();
                        for (int i = 0; i < tl.entries.Count; i++)
                            ((Material.ShaderTextures.ShaderTextureEntry)tl.entries[i]).nameoffset = offsets[i] + dataseg.offset;
                    }
                }


                var shaderfloats = material.GetSection<Material.ShaderFloats>();
                var shaderints = material.GetSection<Material.ShaderIntegers>();

                foreach (var kv in values)
                {
                    var k = kv.Key;
                    var v = kv.Value;

                    // Debugging: Check the size of v
                    if (v == null)
                    {
                        //MessageBox.Show("v is NULL");
                        continue;
                    }
                    if (v.Length == 0)
                    {
                        //MessageBox.Show("v is EMPTY");
                        continue;
                    }
                    if (v[0] == null)
                    {
                        //MessageBox.Show("v[0] is NULL");
                        continue;
                    }
                    if (v[0].values == null)
                    {
                        //MessageBox.Show("v[0].values is NULL");
                        continue;
                    }

                    if (v[0].values[GridEntry.SLOTINTERNAL].Slot != null)
                    {
                        // internal template
                        object[] varray = v.Select(v => v.values[GridEntry.SLOTINTERNAL].Value).ToArray();
                        int slot = (int)v[0].values[GridEntry.SLOTINTERNAL].Slot;


                        switch (v[0].Type)
                        {
                            case GridEntry.TypeOrder.Float:
                                switch (varray[0])
                                {
                                    case float:
                                        shaderfloats.values[slot] = varray.Select(f => f ?? 0f).Cast<float>().ToArray();
                                        break;
                                    case ushort:
                                        shaderfloats.values[slot] = varray.Select(f => f ?? 0f).Cast<ushort>().ToArray();
                                        break;
                                    case byte:
                                        shaderfloats.values[slot] = varray.Select(f => f ?? 0f).Cast<byte>().ToArray();
                                        break;
                                }
                                break;
                            case GridEntry.TypeOrder.Integer:
                                shaderints.integers[slot] = (uint)(varray[0] ?? v[0].values[GridEntry.SLOTEXTERNAL].Value);
                                break;
                        }
                    }

                    if (v[0].values[GridEntry.SLOTOVERRIDE].Slot != null || v[0].values[GridEntry.SLOTEXTERNAL].Slot != null)
                    {
                        // material8
                        object[] varray = v.Select(v => v.values[GridEntry.SLOTOVERRIDE].Value).ToArray();

                        switch (v[0].Type)
                        {
                            case GridEntry.TypeOrder.Float:
                                if (!varray.All(v => v == null) && (!removeUndefFloats.Checked || materials[1] == null || v[0].values[GridEntry.SLOTEXTERNAL].Slot != null))
                                    switch (varray[0])
                                    {
                                        case float:
                                            material8.Floats[k] = varray.Select((f, i) => f = f ?? v[i].values[GridEntry.SLOTEXTERNAL].Value).Cast<float>().ToArray();
                                            break;
                                        case ushort:
                                            material8.Floats[k] = varray.Select((f, i) => f = f ?? v[i].values[GridEntry.SLOTEXTERNAL].Value).Cast<ushort>().ToArray();
                                            break;
                                        case byte:
                                            material8.Floats[k] = varray.Select((f, i) => f = f ?? v[i].values[GridEntry.SLOTEXTERNAL].Value).Cast<byte>().ToArray();
                                            break;
                                    }
                                else if (material8.Floats.Contains(k))
                                    material8.Floats.Remove(k);
                                break;

                            case GridEntry.TypeOrder.Integer:
                                if (!varray.All(v => v == null) && (!removeUndefInts.Checked || materials[1] == null || v[0].values[GridEntry.SLOTEXTERNAL].Slot != null))
                                    material8.Ints[k] = (uint)(varray[0] ?? v[0].values[GridEntry.SLOTEXTERNAL].Value);
                                else if (material8.Ints.Contains(k))
                                    material8.Ints.Remove(k);
                                break;
                        }
                    }
                }

                if (shaderfloats != null)
                    // hack, but why is this in a separate section anyway?
                    shaderfloats.WriteValues(material.GetSection<Material.ShaderFloatValues>()?.newdata);

                material.ToBytes();

                // Replace the first 4 bytes with the magic number based on the selection in the comboBox1
                byte[] magicNumber = GetMagicNumber(f.FileName);
                //Array.Copy(magicNumber, 0, material.binary, 0, magicNumber.Length);
                //Array.Copy(magicNumber, 0, material.binary, 40, magicNumber.Length);

                material.Save(lastsavefile);
                statusLabel.Image = global::Spandex.Properties.Resources.ok;
                statusLabel.Text = $"Saved material: {lastsavefile}";
                UseWaitCursor = false;
            }

            // Replace with magic

            // Open "lastsavefile" and jump to 0x28, replace the following 4 bytes with fileMagicNumber

            if (File.Exists(lastsavefile))
            {
                using (FileStream fs = new FileStream(lastsavefile, FileMode.Open, FileAccess.Write))
                {
                    if (fs.Length >= 0x2C)
                    {
                        fs.Seek(0x28, SeekOrigin.Begin); // Move to offset 0x28
                        fs.Write(fileMagicNumber, 0, fileMagicNumber.Length); // Overwrite 4 bytes
                    }
                }
            }

            // Do Universal Header
            if (checkBox_UniversalHeader.Checked)
            { UniversalHeaderOverride(); }
            else { }
        }

        private void UniversalHeaderOverride()
        {
            byte[] fileBytes = File.ReadAllBytes(lastsavefile);

            string fileExtension = Path.GetExtension(lastsavefile).ToLower();

            byte[] headerBytes = GetHeaderBytes(fileExtension, fileBytes);

            if (headerBytes == null)
            {
                MessageBox.Show("Checked null");
                return;
            }

            // Replace the start of the file with the new headerBytes
            int overrideLength = Math.Min(headerBytes.Length, fileBytes.Length);
            Array.Copy(headerBytes, 0, fileBytes, 0, overrideLength);

            File.WriteAllBytes(lastsavefile, fileBytes);
        }

        private static byte[] GetHeaderBytes(string fileExtension, byte[] fileBytes)
        {
            // Skip 36 bytes more because of the default header
            byte[] sizeBytes = fileBytes.Skip(8 + 36).Take(3).ToArray();

            // We just need .materialgraph and .nodegraph for Spandex
            var headerDictionary = new Dictionary<string, (byte[] header, byte[] additionalBytes)>
            {
                {
                    ".materialgraph", (
                        new byte[] { 0x5B, 0xDC, 0x1A, 0x1C, 0x00, 0x01, 0x00, 0x00 },
                        new byte[] { 0x40, 0x71, 0x55, 0x00, 0x10, 0x0C, 0x53, 0x77, 0xBA, 0x00, 0x04, 0x10, 0x00, 0x40, 0x10, 0x00, 0x80, 0x45, 0x0D, 0x00, 0x10, 0x4C, 0x51, 0x00, 0x80 }
                    )
                },
                {
                    ".material", (
                        new byte[] { 0x68, 0x67, 0x6C, 0x4C, 0x00, 0x01, 0x00, 0x00 },
                        new byte[] { 0x80, 0x7F, 0x00, 0x00, 0x10, 0x6A, 0xF6, 0xB1, 0x28, 0x00, 0x02, 0x00, 0x00, 0x40, 0x04, 0x00, 0x00, 0xC9, 0x09, 0x00, 0x10, 0x00, 0x37, 0x00, 0x00 }
                    )
                }
            };

            if (headerDictionary.ContainsKey(fileExtension))
            {
                var (header, additionalBytes) = headerDictionary[fileExtension];
                return header.Concat(sizeBytes).Concat(additionalBytes).ToArray();
            }

            return null;
        }


        private void folderButton_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = folderDialog.SelectedPath;
                    ReplaceMagicNumberInMaterials(selectedPath);
                }
            }
        }

        private void ReplaceMagicNumberInMaterials(string folderPath)
        {
            // Get all .material and .materialgraph files in the selected folder
            string[] materialFiles = Directory.GetFiles(folderPath, "*.material", SearchOption.AllDirectories)
                                              .Concat(Directory.GetFiles(folderPath, "*.materialgraph", SearchOption.AllDirectories))
                                              .ToArray();

            foreach (var file in materialFiles)
            {
                // Read the file into a byte array
                byte[] fileBytes = File.ReadAllBytes(file);

                // Get the magic number based on the file extension and ComboBox selection
                byte[] magicNumber = GetMagicNumber(file);

                // Replace the first 4 bytes with the magic number
                Array.Copy(magicNumber, 0, fileBytes, 0, magicNumber.Length);
                Array.Copy(magicNumber, 0, fileBytes, 40, magicNumber.Length);

                // Save the modified file
                File.WriteAllBytes(file, fileBytes);
            }

            MessageBox.Show($"Processed {materialFiles.Length} files.", "Operation Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void stringGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            stringGrid.Columns[1].Visible = materials[0]?.GetSectionHeader(Material.SectionType.COMPILEDSHADERS) != null;
            stringGrid.Columns[2].Visible = stringGrid.Columns[3].Visible = materials[0]?.GetSectionHeader(Material.SectionType.SHADEROVERRIDES) != null;
            removeUndefTextures.Enabled = stringGrid.Columns[2].Visible;

            foreach (DataGridViewRow row in stringGrid.Rows)
            {
                if (row.Cells[0].Value == "Template")
                {
                    row.Cells[1].ReadOnly = true;
                    row.Cells[1].Style.BackColor = SystemColors.ControlDark;
                    row.Cells[3].ReadOnly = true;
                    row.Cells[3].Style.BackColor = SystemColors.ControlDark;
                }
                else if (materials[1] != null && ((List<GridEntry>)stringGrid.DataSource)[row.Index].values[GridEntry.SLOTEXTERNAL].Slot == null)
                {
                    row.Cells[2].Style.BackColor = Color.LightPink;
                }
            }
        }

        private void stringGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 0 && e.ColumnIndex == 2)
            {
                statusLabel.Image = global::Spandex.Properties.Resources.warning;
                statusLabel.Text = $"Template path changed.  Save and reopen to apply the new template.";
            }
        }

        private void stringGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (texturelist != null && (e.ColumnIndex == 1 || e.ColumnIndex == 2) && checkBox_Autocompletion.Checked)
            {
                var form2 = new Form2(stringGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value as string,
                    stringGrid.CurrentCell.RowIndex == 0 ? materialgraphlist : texturelist);
                if (form2.ShowDialog() == DialogResult.OK && form2.selected != null)
                    stringGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = form2.selected;
            }
        }

        private void valueGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            valueGrid.Columns[2].Visible = materials[0]?.GetSectionHeader(Material.SectionType.COMPILEDSHADERS) != null;
            valueGrid.Columns[3].Visible = valueGrid.Columns[4].Visible = materials[0]?.GetSectionHeader(Material.SectionType.SHADEROVERRIDES) != null;

            removeUndefFloats.Enabled = removeUndefInts.Enabled = valueGrid.Columns[3].Visible;

            foreach (DataGridViewRow row in valueGrid.Rows)
            {
                var v = ((List<GridEntry>)valueGrid.DataSource)[row.Index];
                if (materials[1] != null && v.values[GridEntry.SLOTEXTERNAL].Slot == null)
                {
                    row.Cells[3].Style.BackColor = Color.LightPink;
                }

                if (v.Span > 0f)
                {
                    row.Cells[0].Style.ForeColor = SystemColors.Window;
                    row.Cells[1].Style.ForeColor = SystemColors.Window;
                }
            }
        }

        private void valueGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var v = ((List<GridEntry>)valueGrid.DataSource)[e.RowIndex];

            if (e.ColumnIndex > 1)
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.Single;
            else
                switch (v.Span)
                {
                    case null:
                    case 0f:
                        e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.Single;
                        break;
                }
        }

        private void ValueGrid_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            // back out invalid values here because cell validation is completely broken
            var cell = valueGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (cell.Value != null && cell.Value is string)
            {
                switch (((List<GridEntry>)valueGrid.DataSource)[e.RowIndex].Type)
                {
                    case GridEntry.TypeOrder.Float:
                        float ftest;
                        cell.Value = float.TryParse((string)cell.Value, out ftest) ? ftest : null;
                        break;
                    case GridEntry.TypeOrder.Short:
                        ushort utest;
                        cell.Value = ushort.TryParse((string)cell.Value, out utest) ? utest : null;
                        break;
                    case GridEntry.TypeOrder.Byte:
                        byte btest;
                        cell.Value = byte.TryParse((string)cell.Value, out btest) ? btest : null;
                        break;
                    case GridEntry.TypeOrder.Integer:
                        uint ui32test;
                        cell.Value = uint.TryParse((string)cell.Value, out ui32test) ? ui32test : null;
                        break;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void stringGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox_Autocompletion_CheckedChanged(object sender, EventArgs e)
        {
            label1.Visible = checkBox_Autocompletion.Checked;
        }
    }

    public class GridEntry
    {
        public const int SLOTINTERNAL = 0;
        public const int SLOTOVERRIDE = 1;
        public const int SLOTEXTERNAL = 2;

        private uint id;
        public float? Span { get; set; }
        public uint ID
        {
            get { return id; }
            set
            {
                if (value == 0)
                    IDdisplay = "Template";
                else
                    IDdisplay = Enum.IsDefined(typeof(KnownMaterialIDs), value) ? $"{((KnownMaterialIDs)value).ToString()} ({value:X8})" : $"{value:X8}";
                id = value;
            }
        }
        public string IDdisplay { get; set; }

        public Values[] values;
        public TypeOrder? Type { get; set; }
        public object Value { get { return values[SLOTOVERRIDE].Value; } set { values[SLOTOVERRIDE].Value = value; } }
        public object InternalValue { get { return values[SLOTINTERNAL].Value; } set { values[SLOTINTERNAL].Value = value; } }
        public object TemplateValue { get { return values[SLOTEXTERNAL].Value; } set { values[SLOTEXTERNAL].Value = value; } }

        public GridEntry()
        {
            values = new Values[3] { new Values(), new Values(), new Values() };
        }

        public enum TypeOrder : uint
        {
            Template = 0,

            // definitions
            Float = 30,
            Short = 31,
            Byte = 32,
            Integer = 39,
        }

        public class Values
        {
            public uint? Slot { get; set; }
            public object Value { get; set; }
        }
    }
}
