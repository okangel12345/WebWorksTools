using System.Reflection;
using System.Text.RegularExpressions;

namespace ConfigWeaver
{
    public partial class ConfigWeaverForm : Form
    {
        public ConfigWeaverForm()
        {
            InitializeComponent();

            WebWorksShared.ToolboxStyle.ApplyToolBoxStyle(this, Handle);
            this.Text = $"Config Weaver v{Assembly.GetExecutingAssembly().GetName().Version.ToString(3)}";
        }

        public void Open(string filePath)
        {
            textBox1.Text = filePath;

            DetectInput();
        }

        private void InputFileButton_Click(object sender, EventArgs e)
        {
            var f = MessageBox.Show("MSM2 configs aren't supported as of now, are you sure you want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (f != DialogResult.Yes)
            {
                return;
            }

            WebWorksCore.DialogsToTextbox.OpenFileDialogAndSaveToTextbox(textBox1, "config", "json");

            DetectInput();

            HighlightJsonSyntax(richTextBox1);
        }

        private void DetectInput()
        {
            StartConversionButton.Visible = true;
            string extensionFromPath = Path.GetExtension(textBox1.Text);

            if (extensionFromPath == ".config")
            {
                SetConfigEnvironment();
            }
            else if (extensionFromPath == ".json")
            {
                SetJsonEnvironment();
            }
            else
            {
                DetectedFileTypeLabel.Text = "Unknown file type!";
                StartConversionButton.Visible = false;
            }
        }

        private void OutputFileButton_Click(object sender, EventArgs e)
        {
            WebWorksCore.DialogsToTextbox.OpenSaveFileDialogAndSaveToTextbox(textBox2, "config", "json");
        }

        private void SetConfigEnvironment()
        {
            DetectedFileTypeLabel.Text = "Config File";

            label2.ForeColor = Color.FromArgb(80, 80, 80);

            textBox_type.Enabled = false;

            textBox_type.ReadOnly = true;
            textBox_type.Text = ConfigHelper.GetConfigType(textBox1.Text);

            StartConversionButton.Text = "Convert to JSON";

            try
            {
                richTextBox1.Text = ConfigHelper.GetConfigData(textBox1.Text);
            }
            catch (Exception ex)
            {
                richTextBox1.Text = $"Error: {ex.Message}";
            }
        }

        private void SetJsonEnvironment()
        {
            DetectedFileTypeLabel.Text = "JSON File";

            label2.ForeColor = Color.FromKnownColor(KnownColor.Control);

            textBox_type.Enabled = true;

            textBox_type.ReadOnly = false;
            textBox_type.Text = null;

            StartConversionButton.Text = "Convert to Config";

            try
            {
                richTextBox1.Text = ConfigHelper.GetJsonData(textBox1.Text);
            }
            catch {}
        }

        private void StartConversionButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Select an input file first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                string output = WebWorksCore.DialogsToTextbox.OpenSaveFileDialogAndSaveToTextbox(textBox2, "config", "json");

                if (output == null)
                {
                    // MessageBox.Show("Select an output path first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            StartConversion();
        }

        private void StartConversion()
        {
            if (DetectedFileTypeLabel.Text.Contains("Config"))
            {
                ConfigHelper.SaveConfigAsJSON(textBox1.Text, textBox2.Text);
            }
            else if (DetectedFileTypeLabel.Text.Contains("JSON"))
            {
                if (string.IsNullOrEmpty(textBox_type.Text))
                {
                    MessageBox.Show("Missing config type! Write it first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                ConfigHelper.SaveJSONAsConfig(textBox2.Text, textBox1.Text, textBox_type.Text);
            }
            else
            {
                MessageBox.Show("Select a supported file type (.json / .config)", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void HighlightJsonSyntax(RichTextBox richTextBox)
        {
            // Save the current selection
            int selectionStart = richTextBox.SelectionStart;
            int selectionLength = richTextBox.SelectionLength;

            // Lock the UI update for performance
            richTextBox.SuspendLayout();

            // Reset formatting
            richTextBox.SelectAll();
            richTextBox.SelectionColor = Color.White; // Default text color
            richTextBox.SelectionFont = new Font(richTextBox.Font, FontStyle.Regular);

            // Define JSON regex patterns
            var patterns = new (string pattern, Color color)[]
            {
                (@"(?<=""|')([\w\s-]+)(?=""|')(?=\s*:)", Color.SteelBlue), // Keys
                (@"""[^""\\]*(?:\\.[^""\\]*)*""", Color.SkyBlue), // Strings
                (@"\b\d+(\.\d+)?\b", Color.LightSlateGray), // Numbers
                (@"\b(true|false|null)\b", Color.CadetBlue), // Booleans and null
                (@"[{}[\],:]", Color.LightGray) // Symbols
            };

            // Apply syntax highlighting
            foreach (var (pattern, color) in patterns)
            {
                foreach (Match match in Regex.Matches(richTextBox.Text, pattern))
                {
                    richTextBox.Select(match.Index, match.Length);
                    richTextBox.SelectionColor = color;
                }
            }

            // Restore original selection
            richTextBox.Select(selectionStart, selectionLength);

            // Unlock the UI update
            richTextBox.ResumeLayout();
        }
    }
}
