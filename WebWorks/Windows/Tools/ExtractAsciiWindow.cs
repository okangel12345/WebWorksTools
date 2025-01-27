using DAT1;
using WebWorks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using WebWorks.Utilities;
using WebWorksShared;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.AccessControl;

namespace WebWorks.Windows.Tools
{
    public partial class ExtractAsciiWindow : Form
    {
        private string _assetPath;
        private ulong _assetHash;
        private ulong _assetID;
        private byte _assetSpan;
        private TOCBase _toc;
        public ExtractAsciiWindow(string assetPath, bool toci29, ulong assetID, byte assetSpan, TOCBase toc)
        {
            InitializeComponent();
            ToolUtils.ApplyStyle(this, Handle);

            _assetPath = assetPath;
            _assetID = assetID;
            _assetSpan = assetSpan;
            _toc = toc;

            textBox_FileHash.ReadOnly = true;
            textBox_FilePath.ReadOnly = true;

            string assetName = Path.GetFileName(_assetPath);

            this.Text = Text + assetName;

            // Assume MSM2 if TOC is i29
            if (toci29)
            {
                comboBox_OutputGame.SelectedIndex = 2;
            }
            else
            {
                comboBox_OutputGame.SelectedIndex = 0;
            }

            FillFields();
        }

        private void ExtractButton_Click(object sender, EventArgs e)
        {
            // Clear log text
            richTextBox_Log.Text = "";

            // Index 2 = MSM2
            if (comboBox_OutputGame.SelectedIndex == 2)
            {
                RunAsciiCommandSM2();
            }
            else
            {
                RunAsciiCommandALERT();
            }
        }

        //------------------------------------------------------------------------------------------
        //
        // Extract ASCII from MSM2 using id-daemon's tool
        //  - This is an implementation for i30, official port will most likely require a
        //    new tool to convert from MODEL to ASCII.
        //
        //------------------------------------------------------------------------------------------
        void RunAsciiCommandSM2()
        {
            try
            {
                // Ensure required files exist
                WebWorksCore.Utilities.EnsureFileExists(WebWorksPaths.SpiderMan2_ModelExtractToolPath, "Spider-Man 2 model extraction tool");
                WebWorksCore.Utilities.EnsureFileExists(WebWorksPaths.Spiderman2_ModelExtractIniPath, "Spider-Man 2 model extraction INI file");

                // Populate spider.ini with the asset archive path
                string archivePath = MainWindow._toc.AssetArchivePath;
                File.WriteAllText(WebWorksPaths.Spiderman2_ModelExtractIniPath, archivePath);

                // Retrieve asset hash and configure save file dialog
                string assetHash = textBox_FileHash.Text.Trim();
                using (SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "ASCII File (*.ascii)|*.ascii",
                    FileName = Path.GetFileNameWithoutExtension(textBox_FilePath.Text) + ".ascii",
                })
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string savedFile = saveFileDialog.FileName;
                        string outputPath = $"{Path.GetDirectoryName(savedFile)}\\{Path.GetFileName(savedFile)}";
                        string arguments = $"{assetHash} \"{outputPath}\"";

                        ExecuteExternalTool(WebWorksPaths.SpiderMan2_ModelExtractToolPath, arguments);

                        LogCommand(Path.GetFileName(WebWorksPaths.SpiderMan2_ModelExtractToolPath), assetHash, outputPath);
                    }
                }
            }
            catch (Exception ex)
            {
                AppendLogMessage($"Error in RunAsciiCommandSM2: {ex.Message}");
            }
        }

        //------------------------------------------------------------------------------------------
        //
        // Convert MODEL to ASCII using ALERT
        //  - Supported games: MSMR, MSMM, & RCRA
        //
        //------------------------------------------------------------------------------------------
        void RunAsciiCommandALERT()
        {
            try
            {
                // Ensure the required executable exists and clean temporary model files
                WebWorksCore.Utilities.EnsureFileExists(WebWorksPaths.ALERT_ModelExtractToolPath, "ALERT model extraction tool");
                CleanTemporaryModel();

                // Extract the asset to a temporary model file
                ExtractionMethods.ExtractAsset(_assetID, _assetSpan, WebWorksPaths.ALERT_TemporaryModelPath, _toc);

                using (SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    FileName = Path.GetFileNameWithoutExtension(_assetPath),
                    Filter = "ASCII File (*.ascii)|*.ascii",
                    DefaultExt = "ascii"
                })
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string outputPath = saveFileDialog.FileName;
                        string outputMaterialsPath = Path.Combine(
                            Path.GetDirectoryName(outputPath),
                            Path.GetFileNameWithoutExtension(outputPath) + "_materials.txt"
                        );

                        string arguments = $"tempfile_model.model \"{outputPath}\" \"{outputMaterialsPath}\"";

                        ExecuteExternalTool(WebWorksPaths.ALERT_ModelExtractToolPath, arguments);

                        string assetHash = textBox_FileHash.Text.Trim();
                        LogCommand(Path.GetFileName(WebWorksPaths.ALERT_ModelExtractToolPath), assetHash, outputPath);

                        CleanTemporaryModel();
                    }
                }
            }
            catch (Exception ex)
            {
                AppendLogMessage($"Error in RunAsciiCommandALERT: {ex.Message}");
            }
        }

        //------------------------------------------------------------------------------------------
        // Helper methods
        //------------------------------------------------------------------------------------------
        private void ExecuteExternalTool(string toolPath, string arguments)
        {
            try
            {
                using (Process process = new Process())
                {
                    process.StartInfo.FileName = toolPath;
                    process.StartInfo.Arguments = arguments;
                    process.StartInfo.WorkingDirectory = WebWorksPaths.MiscFolder;
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.UseShellExecute = false;

                    process.Start();
                    process.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                AppendLogMessage($"Error executing external tool '{toolPath}': {ex.Message}");
                throw;
            }
        }

        private void CleanTemporaryModel()
        {
            try
            {
                if (File.Exists(WebWorksPaths.ALERT_TemporaryModelPath))
                {
                    File.Delete(WebWorksPaths.ALERT_TemporaryModelPath);
                }
            }
            catch { }
        }

        private void AppendLogMessage(string message)
        {
            richTextBox_Log.AppendText($"\n\n{message}");
        }

        private void LogCommand(string toolPath, string assetHash, string outputAsciiPath)
        {
            richTextBox_Log.AppendText($"Running {toolPath}");
            richTextBox_Log.AppendText($"\nAsset hash: {assetHash}");
            richTextBox_Log.AppendText($"\nOutput file: {outputAsciiPath}");

            richTextBox_Log.AppendText($"\n\nFile successfully created!");
        }

        private void FillFields()
        {
            _assetHash = CRC64.Hash(_assetPath, true);

            textBox_FilePath.Text = _assetPath;
            textBox_FileHash.Text = $"{_assetHash:X016}";
        }

        private void ExtractAsciiWindow_KeyDown(object sender, KeyEventArgs e)
        {
            ToolUtils.CloseWithKeyboardShortcut(this, sender, e);
        }
    }
}

