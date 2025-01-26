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

            string arguments = $"\"{model}\" \"{ascii}\" \"{materials}\"";

            if (game == "MSM2")
            {
                MessageBox.Show("Direct .model to .ascii conversion isn't supported for MSM2!");
                executablePath = WebWorksPaths.SpiderMan2_ModelExtractToolPath;
            }
            else
            {
                executablePath = WebWorksPaths.ALERT_ModelExtractToolPath;
            }

            if (!File.Exists(executablePath))
            {
                MessageBox.Show($"Couldn't find {Path.GetFileName(executablePath)} in WebWorksMisc");
                return;
            }

            StartToolWithArgs(executablePath, arguments, mainWindow);
        }

        public static void RemoveHairStrands(string model, ModelToolGUI mainWindow)
        {
            string executablePath = WebWorksPaths.Tool_RemoveHairStrands;
            string arguments = $"\"{model}\"";

            StartToolWithArgs(executablePath, arguments, mainWindow);
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
