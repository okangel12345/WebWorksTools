using DAT1.Files;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using WebWorksShared;

namespace ConfigWeaver
{
    internal class ConfigHelper
    {
        public static void SaveConfigAsJSON(string configPath, string jsonPath)
        {
            WebWorksCore.Utilities.EnsureFileExists(configPath);

            using (var fileStream = new FileStream(configPath, FileMode.Open, FileAccess.Read))
            using (var binaryReader = new BinaryReader(fileStream))
            {
                var config = new Config(binaryReader);

                var root = config.ContentSection.Root;
                var references = config.ReferencesSection;

                using (var writer = new StreamWriter(jsonPath, false))
                {
                    writer.WriteLine(root);
                    writer.WriteLine(references);
                }
            }
        }

        public static void SaveJSONAsConfig(string configPath, string jsonPath, string configType)
        {
            string executablePath = WebWorksPaths.ALERT_JSONToConfig;
            
            WebWorksCore.Utilities.EnsureFileExists(jsonPath);
            WebWorksCore.Utilities.EnsureFileExists(executablePath);

            string arguments = $"\"{jsonPath}\" \"{configType}\"";

            string tempConfigPath = $"{Path.GetDirectoryName(jsonPath)}\\{Path.GetFileName(jsonPath)}.config";

            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = executablePath;
                startInfo.Arguments = arguments;
                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = false;

                Process process = Process.Start(startInfo);
                process.WaitForExit();

                if (File.Exists(tempConfigPath))
                {
                    File.Move(tempConfigPath, configPath, true);
                }
            }
            catch {}
        }

        public static string GetConfigType(string configPath)
        {
            using (var fileStream = new FileStream(configPath, FileMode.Open, FileAccess.Read))
            using (var binaryReader = new BinaryReader(fileStream))
            {
                // Create a Config object using the BinaryReader
                var config = new Config(binaryReader);

                // Access the Type property from the Root object
                if (config.TypeSection.Root is JObject rootObject && rootObject.ContainsKey("Type"))
                {
                    return rootObject["Type"]?.ToString();
                }
                else
                {
                    return "The config file does not contain a valid 'Type' field.";
                }
            }
        }

        public static string GetConfigData(string configPath)
        {
            using (var fileStream = new FileStream(configPath, FileMode.Open, FileAccess.Read))
            using (var configData = new BinaryReader(fileStream))
            {
                var config = new Config(configData);

                var root = config.ContentSection.Root;
                var references = config.ReferencesSection;

                using (var stringWriter = new StringWriter())
                {
                    stringWriter.WriteLine(root);
                    stringWriter.WriteLine(references);

                    return stringWriter.ToString();
                }
            }
        }

        public static string GetJsonData(string jsonPath)
        {
            try
            {
                WebWorksCore.Utilities.EnsureFileExists(jsonPath);
                
                string jsonData = File.ReadAllText(jsonPath);
                return jsonData;
            }
            catch (Exception ex)
            {
                return $"An error occurred loading the JSON: {ex.Message}";
            }
        }
    }
}
