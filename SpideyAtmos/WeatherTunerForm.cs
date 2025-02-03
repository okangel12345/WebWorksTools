using System.Reflection;
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

            this.Text = $"Weather Tuner v{Assembly.GetExecutingAssembly().GetName().Version.ToString(3)}";
            UpdateColorToTextbox();
        }

        // Open atmosphere and load it
        //------------------------------------------------------------------------------------------
        string openPath;
        public void Open(string filePath = null)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                openPath = WebWorksCore.DialogsToTextbox.OpenFileDialogAndSaveToTextbox(textBox_AtmospherePath, "atmosphere");

                if (openPath != null)
                {
                    AtmosphereContent.LoadAtmosphere(textBox_AtmospherePath.Text);
                }
            }
            else
            {
                AtmosphereContent.LoadAtmosphere(filePath);
            }

            if (!string.IsNullOrEmpty(openPath) || !string.IsNullOrEmpty(filePath))
            {
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;

                button1.Visible = true;
                button2.Visible = true;

                checkBox_Normalize.Visible = true;

                textBox_Path1.Visible = true;
                textBox_Hash1.Visible = true;
                textBox_Hash2.Visible = true;

                sharpColorPicker1.Visible = true;
                pictureBox1.Visible = true;

                textBox_Red.Visible = true;
                textBox_Blue.Visible = true;
                textBox_Green.Visible = true;

                textBox_Hexadecimal.Visible = true;
            }
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

        private void textBox_Path1_TextChanged(object sender = null, EventArgs e = null)
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

        private void checkBox_Normalize_CheckedChanged(object sender, EventArgs e)
        {
            textBox_Path1_TextChanged();
        }

        private void sharpColorPicker1_ColorChanged(object sender, EventArgs e)
        {
            UpdateColorToTextbox();
        }

        private void UpdateColorToTextbox()
        {
            float red = sharpColorPicker1.Color.R / 255.0f;
            float green = sharpColorPicker1.Color.G / 255.0f;
            float blue = sharpColorPicker1.Color.B / 255.0f;

            textBox_Red.Text = red.ToString("0.#####");
            textBox_Green.Text = green.ToString("0.#####");
            textBox_Blue.Text = blue.ToString("0.#####");

            string hexColor = $"#{sharpColorPicker1.Color.R:X2}{sharpColorPicker1.Color.G:X2}{sharpColorPicker1.Color.B:X2}";
            textBox_Hexadecimal.Text = hexColor;

            pictureBox1.BackColor = sharpColorPicker1.Color;
        }

        private void textBox_Color_KeyUp(object sender, KeyEventArgs e)
        {
            if (float.TryParse(textBox_Red.Text, out float red) &&
                float.TryParse(textBox_Green.Text, out float green) &&
                float.TryParse(textBox_Blue.Text, out float blue))
            {
                red = Math.Clamp(red, 0.0f, 1.0f);
                green = Math.Clamp(green, 0.0f, 1.0f);
                blue = Math.Clamp(blue, 0.0f, 1.0f);

                int r = (int)(red * 255);
                int g = (int)(green * 255);
                int b = (int)(blue * 255);

                sharpColorPicker1.Color = Color.FromArgb(r, g, b);

                string hexColor = $"#{r:X2}{g:X2}{b:X2}";
                textBox_Hexadecimal.Text = hexColor;
            }
            else if (sender == textBox_Hexadecimal)
            {
                string hex = textBox_Hexadecimal.Text;
                if (hex.StartsWith("#") && hex.Length == 7)
                {
                    try
                    {
                        int r = int.Parse(hex.Substring(1, 2), System.Globalization.NumberStyles.HexNumber);
                        int g = int.Parse(hex.Substring(3, 2), System.Globalization.NumberStyles.HexNumber);
                        int b = int.Parse(hex.Substring(5, 2), System.Globalization.NumberStyles.HexNumber);

                        sharpColorPicker1.Color = Color.FromArgb(r, g, b);

                        textBox_Red.Text = (r / 255.0f).ToString("0.#####");
                        textBox_Green.Text = (g / 255.0f).ToString("0.#####");
                        textBox_Blue.Text = (b / 255.0f).ToString("0.#####");
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Invalid Hex color format.");
                    }
                }
            }

            UpdateColorToTextbox();
        }
    }
}
