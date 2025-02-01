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
                WebWorksCore.DialogsToTextbox.OpenFileDialogAndSaveToTextbox(textBox_AtmospherePath, "atmosphere");

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Atmosphere Files (*.atmosphere)|*.atmosphere|All Files (*.*)|*.*";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        AtmosphereContent.LoadAtmosphere(openFileDialog.FileName);
                    }
                }
            }
            else
            {
                AtmosphereContent.LoadAtmosphere(filePath);
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
            
        }
    }
}
