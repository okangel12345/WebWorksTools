using System.Reflection;

namespace SpideyTextureScaler
{
    public partial class SpideyTexture : Form
    {
        Program program;
        string lastsourcedir, lastddsdir, lastoutputdir;
        bool _openWith;
        string openingWith;

        public SpideyTexture(Program p, bool OpenWith = false, string filePath = "")
        {
            InitializeComponent();
            program = p;

            _openWith = OpenWith;

            p.texturestats[0].ResetVisible();
            p.texturestats[1].ResetVisible();
            p.texturestats[2].ResetVisible();
            sourcelabel.DataBindings.Add("Text", p.texturestats[0], nameof(TextureBase.Filename));
            ddslabel.DataBindings.Add("Text", p.texturestats[1], nameof(TextureBase.Filename));
            outputlabel.DataBindings.Add("Text", p.texturestats[2], nameof(TextureBase.Filename));
            texturestatsBindingSource.DataSource = program.texturestats;
            this.Text = $"Silk Texture v{Assembly.GetExecutingAssembly().GetName().Version.ToString(3)}";

            WebWorksShared.ToolboxStyle.ApplyToolBoxStyle(this, Handle);

            if (filePath != "")
            {
                MessageBox.Show("Opening");
                openingWith = filePath;
            }
        }

        private void UpdateControls()
        {
            if (program.texturestats[0].Ready && program.texturestats[0].Images > 0 && program.texturestats[1].Ready &&
                program.texturestats[1].Images < program.texturestats[0].Images)
            {
                program.texturestats[1].Ready = false;
                MarkError(1, 6);
            }
            generatebutton.Enabled = program.texturestats[0].Ready && program.texturestats[1].Ready && program.texturestats[2].Ready;

            if (program.texturestats[0].Ready && program.texturestats[1].Ready && program.texturestats[0].HDSize > 0)
            {
                var scale = (int)(Math.Floor(Math.Log(program.texturestats[1].basemipsize / (float)program.texturestats[0].basemipsize) / Math.Log(2.0f)) / 2.0f);
                extrasdctl.Maximum = scale;
                extrasdctl.Minimum = 0;
                extrasdctl.Enabled = true;
                extrasdctl_ValueChanged(null, null);
            }
            else
                extrasdctl.Enabled = false;
        }

        private void extrasdctl_ValueChanged(object sender, EventArgs e)
        {
            hdlabel.Text = $"({extrasdctl.Maximum - extrasdctl.Value} HD)";
        }

        private void sourcebutton_Click(object sender, EventArgs e)
        {
            Open();
        }

        public void Open(string fileName = "")
        {
            this.Text = $"Silk Texture v{Assembly.GetExecutingAssembly().GetName().Version.ToString(3)}";
            string output;
            int errorrow = 0;
            int errorcol = -1;
            var obj = (Source)program.texturestats[0];
            obj.ResetVisible();
            ClearErrorRow(dataGridView1.Rows[0]);

            var f = new OpenFileDialog();
            f.Filter = "Low or high res texture|*.texture";
            if (lastsourcedir is not null)
                f.InitialDirectory = lastsourcedir;
            f.FileName = fileName;

            saveddsbutton.Enabled = false;
            if (f.FileName != "" || f.ShowDialog() == DialogResult.OK)
            {
                program.texturestats[0] = obj = new Source();
                string filePath = f.FileName;

                obj.Filename = filePath;
                lastsourcedir = Path.GetDirectoryName(filePath) + @"\";
                if (obj.Filename.ToLower().EndsWith(".hd.texture") || obj.Filename.ToLower().EndsWith("_hd.texture"))
                {
                    var h = obj.Filename.Substring(0, obj.Filename.Length - ".hd.texture".Length) + ".texture";
                    if (File.Exists(h))
                        obj.Filename = h;
                }
                if (obj.Read(out output, out errorrow, out errorcol))
                {
                    saveddsbutton.Enabled = true;
                    this.Text = $"{Path.GetFileNameWithoutExtension(Path.GetFileName(obj.Filename))} - Silk Texture v{Assembly.GetExecutingAssembly().GetName().Version.ToString(3)}";
                }
                ddsfilenamelabel.Text = Path.GetFileName(Path.ChangeExtension(obj.Filename, (obj.Images > 1 ? ".Ax.dds" : ".dds")));
                saveddsbutton.Text = obj.Images > 1 ? "Save multiple .dds" : "Save as .dds";

                outputbox.Text = output;
            }

            dataGridView1.Refresh();
            dataGridView1.AutoResizeColumns();
            sourcelabel.DataBindings.Clear();
            sourcelabel.DataBindings.Add("Text", obj, nameof(TextureBase.Filename));
            MarkError(errorrow, errorcol);
            UpdateControls();
        }

        private void saveddsbutton_Click(object sender, EventArgs e)
        {
            SaveAsDDS();
        }

        private void SaveAsDDS()
        {
            var tex = (Source)program.texturestats[0];
            var savedds = new DDS();
            savedds.Filename = Path.ChangeExtension(tex.Filename, ".dds");
            savedds.Mipmaps = tex.Mipmaps;
            savedds.Images = tex.Images;
            savedds.Format = tex.Format;
            savedds.basemipsize = tex.basemipsize;
            byte[] hdmips = null;
            string output;

            savedds.HDMipmaps = 0;
            savedds.Width = tex.Width;
            savedds.Height = tex.Height;
            if (tex.HDSize > 0)
            {
                if (tex.hdfilename == "" || !File.Exists(tex.hdfilename))
                {
                    if (MessageBox.Show($"No corresponding .hd.texture file found.\r\n\r\nDo you want to proceed with the low resolution texture ({tex.sd_width} x {tex.sd_height})?",
                    "Alert",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }

                    savedds.Width = (uint)tex.sd_width;
                    savedds.Height = (uint)tex.sd_height;
                }
                else
                {
                    savedds.HDMipmaps = tex.HDMipmaps;
                    hdmips = File.ReadAllBytes(tex.hdfilename);
                }
            }

            savedds.Write(hdmips, tex.mipmaps, out output);
            outputbox.Text = output;
        }

        private void ddsbutton_Click(object sender, EventArgs e)
        {
            var f = new OpenFileDialog();
            f.Filter = program.texturestats[0].Images > 1 ? "DirectDraw Surface Array (*.A0.dds)|*.A0.dds" : "DirectDraw Surface (*.dds)|*.dds";
            if (lastddsdir is not null)
                f.InitialDirectory = lastddsdir;
            var obj = (DDS)program.texturestats[1];
            obj.ResetVisible();
            ClearErrorRow(dataGridView1.Rows[1]);
            string output;
            int errorrow = 0;
            int errorcol = -1;

            if (f.ShowDialog() == DialogResult.OK)
            {
                program.texturestats[1] = obj = new DDS();

                obj.Filename = f.FileName;
                lastddsdir = Path.GetDirectoryName(f.FileName) + @"\";
                obj.Read(out output, out errorrow, out errorcol);
                obj.Images = 1;
                if (program.texturestats[2].Filename == Output.defaultfilelabel)
                {
                    var suggestfn = Path.ChangeExtension(f.FileName, ".texture");
                    if (suggestfn != program.texturestats[0].Filename)
                    {
                        program.texturestats[2].Filename = suggestfn;
                        program.texturestats[2].Ready = true;
                        outputlabel.DataBindings.Clear();
                        outputlabel.DataBindings.Add("Text", program.texturestats[2], nameof(TextureBase.Filename));
                    }
                }

                if (obj.Filename.ToLower().EndsWith(".a0.dds"))
                {
                    var stub = obj.Filename.Substring(0, obj.Filename.Length - ".a0.dds".Length);
                    for (obj.Images = 1; obj.Images < 32; obj.Images++)
                    {
                        if (!File.Exists($"{stub}.A{obj.Images}.dds"))
                            break;
                    }
                    output += $"({obj.Images} textures available)\r\n";
                }
                outputbox.Text = output;
            }

            dataGridView1.Refresh();
            dataGridView1.AutoResizeColumns();
            ddslabel.DataBindings.Clear();
            ddslabel.DataBindings.Add("Text", obj, nameof(TextureBase.Filename));
            MarkError(errorrow, errorcol);
            UpdateControls();
        }

        private void outputbutton_Click(object sender, EventArgs e)
        {
            var f = new SaveFileDialog();
            f.Filter = "Modified texture|*.texture";
            if (lastoutputdir is not null)
                f.InitialDirectory = Path.GetDirectoryName(lastoutputdir);
            var obj = (Output)program.texturestats[2];
            obj.ResetVisible();

            if (f.ShowDialog() == DialogResult.OK)
            {
                lastoutputdir = Path.GetDirectoryName(f.FileName) + @"\";
                program.texturestats[2] = obj = new Output();
                if (obj.Filename != program.texturestats[0].Filename)
                {
                    obj.Filename = f.FileName;
                    obj.Ready = true;

                    outputbox.Text = "";
                }
                else
                    outputbox.Text = "Output file can't be the same as input file.";
            }

            dataGridView1.Refresh();
            dataGridView1.AutoResizeColumns();
            outputlabel.DataBindings.Clear();
            outputlabel.DataBindings.Add("Text", obj, nameof(TextureBase.Filename));
            UpdateControls();
        }

        private void generatebutton_Click(object sender, EventArgs e)
        {
            outputbox.Text = "";
            string output;
            var obj = (Output)program.texturestats[2];
            var savefn = obj.Filename;
            obj.ResetVisible();
            obj.Filename = savefn;
            ClearErrorRow(dataGridView1.Rows[2]);

            int errorrow;
            int errorcol;

            for (int i = 0; i < 3; i++)
            {
                program.texturestats[i].Ready = false;

                if (program.texturestats[i].Read(out output, out errorrow, out errorcol))
                    program.texturestats[i].Ready = true;

                MarkError(errorrow, errorcol);
                outputbox.Text += output;
            }

            UpdateControls();
            dataGridView1.Refresh();
            if (!generatebutton.Enabled)
                return;

            var ddss = new List<DDS>() { (DDS)(program.texturestats[1]) };
            var stub = ddss[0].Filename.Substring(0, ddss[0].Filename.Length - ".a0.dds".Length);
            for (int i = 1; i < program.texturestats[0].Images; i++)
            {
                ddss.Add(new DDS());
                ddss[i].Filename = $"{stub}.A{i}.dds";
                if (!ddss[i].Read(out output, out errorrow, out errorcol))
                {
                    MarkError(errorrow, errorcol);
                    outputbox.Text += output;
                    return;
                }
                outputbox.Text += output;
            }
            ((Output)program.texturestats[2]).Generate(
                (Source)(program.texturestats[0]),
                ddss,
                testmode.Checked,
                ignoreformat.Checked ? true : null,
                (uint)extrasdctl.Value,
                out output, out errorrow, out errorcol);

            outputbox.AppendText(output);
            dataGridView1.Refresh();
            dataGridView1.AutoResizeColumns();
            MarkError(errorrow, errorcol);
        }

        private void MarkError(int errorrow, int errorcol)
        {
            if (errorcol < 0)
                return;

            dataGridView1.Rows[errorrow].Cells[errorcol].ErrorText = "Error";
        }

        private void ClearErrors(DataGridView d)
        {
            // seems like there should already be a function for this
            foreach (DataGridViewRow row in d.Rows)
                ClearErrorRow(row);
        }

        private void ClearErrorRow(DataGridViewRow row)
        {
            foreach (DataGridViewCell c in row.Cells)
            {
                c.ErrorText = "";
            }
        }

        private void btn_batchExtractDDS_Click(object sender, EventArgs e)
        {
            // Loop through all rows except the last one in the DataGridView
            for (int i = 0; i < data_Batch.Rows.Count - 1; i++)
            {
                // Retrieve batchTexturePath and batchOutputDir for each row
                string batchTexturePath = data_Batch.Rows[i].Cells["batchTexturePath"].Value?.ToString();  // Column name for texture path
                string batchOutputDir = data_Batch.Rows[i].Cells["batchOutputDir"].Value?.ToString();  // Column name for output directory
                string defaultOutputPath = textBox_batchDefaultPath.Text;

                // Skip the row if batchTexturePath is empty
                if (string.IsNullOrEmpty(batchTexturePath))
                {
                    continue; // Skip the current iteration and move to the next row
                }

                // Use batchTexturePath for the source file
                FileInfo sourceInfo = new FileInfo(batchTexturePath);

                // If batchOutputDir is empty, use textBox_batchDefaultPath as the output directory
                string outputPath = string.IsNullOrEmpty(batchOutputDir) ? defaultOutputPath : batchOutputDir;
                DirectoryInfo outputdirInfo = new DirectoryInfo(outputPath);

                // Assuming allowsd is true for this case (or can be set based on user input)
                bool allowsd = checkBox_batchAllowSD.Checked;

                // Initialize Program object (if necessary)
                var p = new Program();
                p.texturestats = new List<TextureBase>()
                {
                    new Source(), // Ensure this is the correct object type and populated
                    new DDS(),
                    new Output(),
                };

                p.Extract(sourceInfo, outputdirInfo, allowsd);
            }
        }

        private void data_Batch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked column is the 4th column (index 3)
            if (e.ColumnIndex == 3 && e.RowIndex >= 0)
            {
                // Ensure there's more than one row to prevent deleting the last row
                if (data_Batch.Rows.Count > 1)
                {
                    // Get the clicked row index
                    int rowIndex = e.RowIndex;

                    // Delete the clicked row
                    data_Batch.Rows.RemoveAt(rowIndex);
                }
            }
        }

        private void btn_batchClearRow_Click(object sender, EventArgs e)
        {
            // This will ensure the data is cleared when the button is clicked
            if (data_Batch.SelectedCells.Count > 0)
            {
                // Get the selected row (first selected cell's row)
                int rowIndex = data_Batch.SelectedCells[0].RowIndex;

                // Clear the fields in the row (assuming columns 0, 1, and 2 hold the data)
                data_Batch.Rows[rowIndex].Cells[0].Value = null; // Clear batchTexturePath
                data_Batch.Rows[rowIndex].Cells[1].Value = null; // Clear batchOutputDir
                data_Batch.Rows[rowIndex].Cells[2].Value = null; // Clear any other field
            }
        }

        private void data_Batch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 0)
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog
                    {
                        Filter = "Textures (*.texture*)|*.texture", // Adjust the filter as necessary
                        Title = "Select a Texture File"
                    };

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Update the cell with the selected file path
                        data_Batch.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = openFileDialog.FileName;
                        data_Batch.BeginEdit(false);
                    }
                }
                else if (e.ColumnIndex == 1)
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog
                    {
                        Filter = "DDS (*.dds*)|*.dds", // Adjust the filter as necessary
                        Title = "Select a DDS File"
                    };

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Update the cell with the selected file path
                        data_Batch.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = openFileDialog.FileName;
                        data_Batch.BeginEdit(false);
                    }
                }
                else if (e.ColumnIndex == 2) // 4th column (folder selection)
                {
                    FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
                    {
                        Description = "Select a Folder"
                    };

                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Update the cell with the selected folder path
                        data_Batch.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = folderBrowserDialog.SelectedPath;
                        data_Batch.EndEdit();
                    }
                }
            }
        }

        private void btn_batchFolderChoose_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
            {
                Description = "Select a Folder"
            };

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBox_batchDefaultPath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btn_batchInjectDDS_Click(object sender, EventArgs e)
        {
            // Loop through all rows except the last one in the DataGridView
            for (int i = 0; i < data_Batch.Rows.Count - 1; i++)
            {
                // Retrieve batchTexturePath, batchDDSPath, and batchOutputDir for each row
                string batchTexturePath = data_Batch.Rows[i].Cells["batchTexturePath"].Value?.ToString();  // Column name for texture path
                string batchDDSPath = data_Batch.Rows[i].Cells["batchDDSPath"].Value?.ToString();  // Column name for DDS path
                string batchOutputDir = data_Batch.Rows[i].Cells["batchOutputDir"].Value?.ToString();  // Column name for output directory
                string defaultOutputPath = textBox_batchDefaultPath.Text;

                MessageBox.Show("Trigger");

                // Skip the row if batchTexturePath or batchDDSPath is empty
                if (string.IsNullOrEmpty(batchTexturePath) || string.IsNullOrEmpty(batchDDSPath))
                {
                    continue; // Skip the current iteration and move to the next row
                }

                // Use batchTexturePath for the source file
                FileInfo sourceInfo = new FileInfo(batchTexturePath);
                FileInfo ddsInfo = new FileInfo(batchDDSPath);

                // If batchOutputDir is empty, use textBox_batchDefaultPath as the output directory
                string outputPath = string.IsNullOrEmpty(batchOutputDir) ? defaultOutputPath : batchOutputDir;
                DirectoryInfo outputdirInfo = new DirectoryInfo(outputPath);

                // Retrieve additional options for the Replace method
                uint extrasd = (uint)numericUpDown_batchExtrasd.Value;
                bool ignoreformat = checkBox_batchIgnoreFormat.Checked;  // Assuming there's a CheckBox for ignoreformat

                bool testmode = false;

                MessageBox.Show("Trigger2");

                // Initialize Program object (if necessary)
                var p = new Program();
                p.texturestats = new List<TextureBase>()
                {
                    new Source(), // Ensure this is the correct object type and populated
                    new DDS(),
                    new Output(),
                };

                // Call Replace method
                p.RunReplace(sourceInfo, ddsInfo, outputdirInfo, extrasd, false, testmode);
            }
        }

        private void SpideyTexture_Load(object sender, EventArgs e)
        {
            if (_openWith)
            {
                Open();
            }
            if (openingWith != null)
            {
                Open(openingWith);
            }
        }
    }
}
