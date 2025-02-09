using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebWorksShared;

namespace ModelToolsGUI
{
    internal class ModelConversionHelpers
    {
        public static void InjectAsciiToModel(string ascii, string materials, string model, string game, ModelToolGUI mainWindow)
        {
            string executablePath;
            string arguments = $"\"{model}\" \"{ascii}\" \"{materials}\"";

            if (game == "MSM2")
            {
                executablePath = WebWorksPaths.SpiderMan2_ModelImportToolPath;
            }
            else
            {
                executablePath = WebWorksPaths.ALERT_ModelImportToolPath;
            }

            if (!File.Exists(executablePath))
            {
                MessageBox.Show($"Couldn't find {Path.GetFileName(executablePath)} in WebWorksMisc");
                return;
            }

            StartToolWithArgs(executablePath, arguments, mainWindow);
        }

        public static void ConvertModelToAscii(string model, string ascii, string game, ModelToolGUI mainWindow)
        {
            string executablePath;
            string materials = $"{Path.GetDirectoryName(ascii)}\\{Path.GetFileNameWithoutExtension(ascii)}_materials.txt";

            string arguments;
            string asciiPath;

            if (game == "MSM2")
            {
                executablePath = WebWorksPaths.SpiderMan2_ModelExtractToolPath;
                arguments = $"\"{model}\"";
            }
            else
            {
                executablePath = WebWorksPaths.ALERT_ModelExtractToolPath;
                arguments = $"\"{model}\" \"{ascii}\" \"{materials}\"";
            }

            if (!File.Exists(executablePath))
            {
                MessageBox.Show($"Couldn't find {Path.GetFileName(executablePath)} in WebWorksMisc");
                return;
            }

            StartToolWithArgs(executablePath, arguments, mainWindow);

            if (game == "MSM2")
            {
                MoveMSM2Model(arguments, ascii);
            }
        }

        private static void MoveMSM2Model(string arguments, string asciiOutputPath)
        {
            string modelName = Path.GetFileNameWithoutExtension(arguments);     // hero_spiderman.model

            string asciiName = $"{modelName}.ascii";                            // hero_spiderman.ascii
            string materialsName = $"{modelName}_materials.txt";                // hero_spiderman_materials.txt

            string programDir = AppDomain.CurrentDomain.BaseDirectory;

            string asciiOutput = Path.Combine(programDir, asciiName);           // C:/Path/To/WebWorks/hero_spiderman.ascii
            string materialsOutput = Path.Combine(programDir, materialsName);   // C:/Path/To/WebWorks/hero_spiderman_materials.ascii

            string materialsOutputPath = Path.Combine(Path.GetDirectoryName(asciiOutputPath), $"{Path.GetFileNameWithoutExtension(asciiOutputPath)}_materials.txt");   // C:/User/Path/To/ascii_materials.txt

            try
            {
                File.Move(asciiOutput, asciiOutputPath, true);
                File.Move(materialsOutput, materialsOutputPath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"There was an error while attempting to move generated files. Error: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static void RemoveHairStrands(string model, ModelToolGUI mainWindow)
        {
            string executablePath = WebWorksPaths.Tool_RemoveHairStrands;
            string arguments = $"\"{model}\"";

            StartToolWithArgs(executablePath, arguments, mainWindow);

            string modifiedModel = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Path.GetFileNameWithoutExtension(model) + "_modified.model");

            MoveHairStrandModel(model, modifiedModel, mainWindow);
        }

        private static void MoveHairStrandModel(string model, string modifiedModel, ModelToolGUI mainWindow)
        {
            if (File.Exists (modifiedModel))
            {
                string modelDirectory = Path.GetDirectoryName(model);
                string modifiedModelFileName = Path.GetFileName(modifiedModel);

                try
                {
                    string outputPath = Path.Combine(modelDirectory, modifiedModelFileName);

                    if (File.Exists(outputPath))
                    {
                        var f = MessageBox.Show($"{modifiedModelFileName} already exists. Do you want to replace it?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        
                        if (f == DialogResult.Cancel)
                        {
                            File.Delete(modifiedModel);
                            return;
                        }
                    }

                    File.Move(modifiedModel, outputPath, true);

                    mainWindow.richTextBox1.AppendText($"Modified model moved to: {outputPath}");
                }
                catch {}
            }
        }

        //------------------------------------------------------------------------------------------
        // Start model tools 
        //------------------------------------------------------------------------------------------
        private static void StartToolWithArgs(string executablePath, string arguments, ModelToolGUI mainWindow)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = executablePath,
                Arguments = arguments,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            try
            {
                using (Process process = Process.Start(startInfo))
                {
                    string output = process.StandardOutput.ReadToEnd();
                    string errorOutput = process.StandardError.ReadToEnd();

                    mainWindow.richTextBox1.AppendText($"Output:\n{output}\n");

                    if (!string.IsNullOrEmpty(errorOutput))
                    {
                        mainWindow.richTextBox1.AppendText($"Errors:\n{errorOutput}\n");
                    }

                    process.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                mainWindow.richTextBox1.AppendText($"Error executing process: {ex.Message}\n");
            }
        }
    }
}
