using System.Diagnostics;
using WebWorksShared;

namespace ModelToolsGUI
{
    public partial class ModelToolGUI : Form
    {
        public static ModelToolGUI Instance { get; private set; }

        public ModelToolGUI()
        {
            InitializeComponent();
            ToolboxStyle.ApplyToolBoxStyle(this, Handle);

            AsciiToModel_ComboBox.SelectedIndex = 0;
            ModelToAscii_ComboBox.SelectedIndex = 0;
        }

        //------------------------------------------------------------------------------------------
        //
        // Ascii to Model
        //
        //------------------------------------------------------------------------------------------
        string asciiToModel_Ascii;
        string asciiToModel_Materials;
        string asciiToModel_Model;

        private void AsciiToModel_AsciiButton_Click(object sender, EventArgs e)
        {
            WebWorksCore.DialogsToTextbox.OpenFileDialogAndSaveToTextbox(AsciiToModel_AsciiTextBox, "ascii");
            asciiToModel_Ascii = AsciiToModel_AsciiTextBox.Text;
        }

        private void AsciiToModel_MaterialsButton_Click(object sender, EventArgs e)
        {
            WebWorksCore.DialogsToTextbox.OpenFileDialogAndSaveToTextbox(AsciiToModel_MaterialsTextBox, "txt");
            asciiToModel_Materials = AsciiToModel_MaterialsTextBox.Text;
        }

        private void AsciiToModel_ModelButton_Click(object sender, EventArgs e)
        {
            WebWorksCore.DialogsToTextbox.OpenFileDialogAndSaveToTextbox(AsciiToModel_ModelTextBox, "model");
            asciiToModel_Model = AsciiToModel_ModelTextBox.Text;
        }

        private void AsciiToModel_StartButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(asciiToModel_Ascii) || string.IsNullOrEmpty(asciiToModel_Materials) || string.IsNullOrEmpty(asciiToModel_Model))
            {
                MessageBox.Show("One or more missing parameters!");
                return;
            }

            string game = AsciiToModel_ComboBox.Text;

            ModelConversionHelpers.InjectAsciiToModel(asciiToModel_Ascii, asciiToModel_Materials, asciiToModel_Model, game, this);
        }

        //------------------------------------------------------------------------------------------
        //
        // Model to Ascii user input
        //
        //------------------------------------------------------------------------------------------
        string modelToAscii_Ascii;
        string modelToAscii_Model;

        private void ModelToAscii_ModelButton_Click(object sender, EventArgs e)
        {
            WebWorksCore.DialogsToTextbox.OpenFileDialogAndSaveToTextbox(ModelToAscii_ModelTextBox, "model");
            modelToAscii_Model = ModelToAscii_ModelTextBox.Text;
        }

        private void ModelToAscii_AsciiButton_Click(object sender, EventArgs e)
        {
            WebWorksCore.DialogsToTextbox.OpenSaveFileDialogAndSaveToTextbox(ModelToAscii_AsciiTextBox, "ascii");
            modelToAscii_Ascii = ModelToAscii_AsciiTextBox.Text;
        }

        private void ModelToAscii_StartButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(modelToAscii_Model) || string.IsNullOrEmpty(modelToAscii_Ascii))
            {
                MessageBox.Show("One or more missing parameters!");
                return;
            }

            string game = ModelToAscii_ComboBox.Text;

            ModelConversionHelpers.ConvertModelToAscii(modelToAscii_Model, modelToAscii_Ascii, game, this);
        }

        //------------------------------------------------------------------------------------------
        //
        // Remove hair strands user input
        //
        //------------------------------------------------------------------------------------------

        private void RemoveHairStrands_ModelButton_Click(object sender, EventArgs e)
        {
            WebWorksCore.DialogsToTextbox.OpenFileDialogAndSaveToTextbox(RemoveHairStrands_ModelTextBox, "model");
        }

        private void RemoveHairStrands_StartButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(RemoveHairStrands_ModelTextBox.Text))
            {
                MessageBox.Show("One or more missing parameters!");
                return;
            }

            ModelConversionHelpers.RemoveHairStrands(RemoveHairStrands_ModelTextBox.Text, this);
        }
    }
}
