using System.Windows.Forms;

namespace WeatherTuner
{
    public partial class WeatherTunerForm : Form
    {
        public static WeatherTunerForm Instance { get; private set; }
        public WeatherTunerForm(string filePath = null)
        {
            InitializeComponent();
            WebWorksShared.ToolboxStyle.ApplyToolBoxStyle(this, Handle);

            if (filePath != null)
            {
                Open(filePath);
            }

            Instance = this;
        }

        // Open atmosphere and load it
        //------------------------------------------------------------------------------------------
        private void Open(string filePath = null)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                string path = WebWorksCore.DialogsToTextbox.OpenFileDialogAndSaveToTextbox(textBox_AtmospherePath, "atmosphere");

                if (path != null)
                {
                    AtmosphereContent.LoadAtmosphere(textBox_AtmospherePath.Text);
                }
            }
            else
            {
                AtmosphereContent.LoadAtmosphere(filePath);
            }

            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;

            button1.Visible = true;
            button2.Visible = true;

            checkBox_Normalize.Visible = true;

            textBox_Path1.Visible = true;
            textBox_Hash1.Visible = true;
            textBox_Hash2.Visible = true;
        }

        private void Save()
        {
            string path = WebWorksCore.DialogsToTextbox.OpenSaveFileDialogAndSaveToTextbox(textBox_AtmospherePath, "atmosphere");

            if (path != null)
            {
                AtmosphereContent.SaveAtmosphere(textBox_AtmospherePath.Text, AtmosphereValues_grid, AtmosphereHashes_grid);
            }
        }

        private void Search()
        {
            string searchText = Search_Textbox.Text.ToLower();

            if (string.IsNullOrEmpty(Search_Textbox.Text))
            {
                foreach (DataGridViewRow row in AtmosphereValues_grid.Rows)
                {
                    row.Visible = false;
                    string rowType = row.Cells[2].Value.ToString();

                    if (rowType == "+" || rowType == "-")
                    {
                        row.Visible = true;
                        AtmosphereContent.CollapseRows(AtmosphereValues_grid, row.Index);
                    }
                }

                return;
            }

            foreach (DataGridViewRow row in AtmosphereValues_grid.Rows)
            {
                row.Visible = false;
            }

            foreach (DataGridViewRow row in AtmosphereValues_grid.Rows)
            {
                string parentRowTag = row.Tag.ToString();

                if (parentRowTag == "collapsed" || parentRowTag == "expanded")
                {
                    row.Visible = true;
                }
                else
                {
                    string rowName = row.Cells[0].Value?.ToString().ToLower();
                    string rowDescription = row.Cells[3].Value?.ToString().ToLower();

                    bool matchesSearch = !string.IsNullOrEmpty(rowName) && rowName.Contains(searchText) || rowDescription.Contains(searchText);

                    row.Visible = matchesSearch;

                    int parentRowIndex = (int?)row.Tag ?? -1;
                    if (parentRowIndex >= 0)
                    {
                        AtmosphereValues_grid.Rows[parentRowIndex].Visible = matchesSearch;
                    }
                }
            }
        }


        // User input
        //------------------------------------------------------------------------------------------
        private void LoadAtmosphere_Button_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void SaveAtmosphere_Button_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Search_Textbox_KeyUp(object sender, KeyEventArgs e)
        {
            Search();
        }

        private void textBox_Path1_TextChanged(object sender, EventArgs e)
        {
            string input = textBox_Path1.Text;
            string extension = Path.GetExtension(input);

            var crc64 = DAT1.CRC64.Hash(input, checkBox_Normalize.Checked);
            var crc32 = DAT1.CRC32.Hash(extension, checkBox_Normalize.Checked);

            label3.Text = $"Hashed Extension... ({extension})";

            textBox_Hash1.Text = $"{crc64:X016}";
            textBox_Hash2.Text = $"{crc32:X08}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebWorksCore.Utilities.CopyToClipboard(textBox_Hash1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WebWorksCore.Utilities.CopyToClipboard(textBox_Hash2.Text);
        }
    }
}
