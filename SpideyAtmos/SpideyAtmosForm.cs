using System.Windows.Forms;

namespace SpideyAtmos
{
    public partial class SpideyAtmosForm : Form
    {
        public static SpideyAtmosForm Instance { get; private set; }
        public SpideyAtmosForm(string filePath = null)
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
        }

        private void Save()
        {
            string path = WebWorksCore.DialogsToTextbox.OpenSaveFileDialogAndSaveToTextbox(textBox_AtmospherePath, "atmosphere");

            if (path != null)
            {
                AtmosphereContent.SaveAtmosphere(textBox_AtmospherePath.Text, AtmosphereValues_grid);
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
    }
}
