using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using WebWorksCore;
using static WebWorksCore.Sections.Section;

namespace WebWave
{
    public partial class WebWaveForm : Form
    {
        static List<string> wwnames = new List<string>();
        AssetManager currentSoundbank;
        string currentSoundBankPath;
        BnkEditor currentBnk;

        public WebWaveForm()
        {
            InitializeComponent();
            WebWorksShared.ToolboxStyle.ApplyToolBoxStyle(this, Handle);

            this.Text = $"WebWave v{Assembly.GetExecutingAssembly().GetName().Version.ToString(3)}";
        }

        // Load the soundbank and set it as the currentSoundbank
        //------------------------------------------------------------------------------------------
        private void LoadSounBank_Button_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog f = new OpenFileDialog())
            {
                f.Filter = "Soundbank Files (*.soundbank)|*.soundbank|All Files (*.*)|*.*";
                f.Title = "Select a .soundbank file...";

                if (f.ShowDialog() == DialogResult.OK)
                {
                    NewWems_dataGridView.Rows.Clear();
                    WemNames_dataGridView.Rows.Clear();
                    EventNames_dataGridView.Rows.Clear();
                    wwnames.Clear();

                    currentSoundBankPath = f.FileName;

                    SoundBank_TextBox.Text = currentSoundBankPath;
                    currentSoundbank = new AssetManager(File.ReadAllBytes(currentSoundBankPath));

                    SoundbankConversion.ExtractEventNames(currentSoundbank, wwnames);

                    for (int i = 0; i < wwnames.Count; i++)
                    {
                        EventNames_dataGridView.Rows.Add(wwnames[i]);
                    }

                    try
                    {
                        currentBnk = new BnkEditor(currentSoundbank.GetAssetSection(WebWorksCore.Sections.Section.Soundbank.bnkData));
                        string[] wemNames = currentBnk.ListAudio();

                        for (int i = 0; i < wemNames.Length; i++)
                        {
                            WemNames_dataGridView.Rows.Add(wemNames[i]);
                        }
                    }
                    catch (Exception ex)
                    {
                        WemNames_dataGridView.Rows.Clear();
                        WemNames_dataGridView.Rows.Add("There was an error parsing the wem file names.");
                    }
                }
            }
        }

        // Save soundbank as .bnk in the user path
        //------------------------------------------------------------------------------------------
        private void SaveAsBnk_Button_Click(object sender, EventArgs e)
        {
            // Exit early if the currentSoundbank is null or empty
            if (currentSoundbank == null)
            {
                MessageBox.Show("Select a .soundbank first!", "",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Open the save file dialog to choose where to save the bnk
            using (SaveFileDialog f = new SaveFileDialog())
            {
                f.Filter = "BNK Files (*.bnk)|*.bnk|All Files (*.*)|*.*";
                f.Title = "Select .bnk output path...";
                f.FileName = Path.GetFileName(Path.ChangeExtension(currentSoundBankPath, ".bnk"));

                if (f.ShowDialog() == DialogResult.OK)
                {
                    string output = f.FileName;

                    try
                    {
                        // Extract the bnk bytes from currentSoundbank and write them to output
                        SoundbankConversion.ExtractBnk(currentSoundbank, output);
                    }
                    catch (Exception ex)
                    {
                        // Notify of any errors
                        MessageBox.Show("There was an error attempting to save the .bnk file.", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ExtractWems_Button_Click(object sender, EventArgs e)
        {
            var f = new FolderBrowserDialog();
            DialogResult r = f.ShowDialog();

            if (r == DialogResult.OK)
            {
                try
                {
                    currentBnk.Extract(f.SelectedPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"There was an error while extracting the WEM files. Error: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddFromFolder_button_Click(object sender, EventArgs e)
        {
            var f = new FolderBrowserDialog();
            DialogResult r = f.ShowDialog();

            if (r == DialogResult.OK)
            {
                List<string> files = new List<string>();
                string[] fileArray = Directory.GetFiles(f.SelectedPath);
                files.AddRange(fileArray);

                for (int i = 0; i < files.Count; i++)
                {
                    NewWems_dataGridView.Rows.Add(files[i]);
                }
            }
        }

        private void Generate_Button_Click(object sender, EventArgs e)
        {
            try
            {
                // Update currentBnk
                List<string> replacements = new List<string>();

                foreach (DataGridViewRow row in NewWems_dataGridView.Rows)
                {
                    if (row.Cells[0].Value != null) 
                    {
                        string wemFilePath = row.Cells[0].Value.ToString();
                        currentBnk.AddReplacement(wemFilePath);

                        string wemFileName = Path.GetFileName(wemFilePath);
                        replacements.Add(wemFileName);
                    }
                }

                currentBnk.Update(replacements);

                using var f = new SaveFileDialog();
                {
                    f.Filter = "Soundbank files (*.bnk)|*.bnk|All files (*.*)|*.*";
                    f.FileName = Path.ChangeExtension(currentSoundBankPath, "modified.soundbank");

                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        currentSoundbank.UpdateSection(Soundbank.bnkData, currentBnk.fileBytes);

                        // Write the updated soundbank data to the selected file
                        File.WriteAllBytes(f.FileName, currentSoundbank._assetBytes);
                    }
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex); }
        }
    }
}
