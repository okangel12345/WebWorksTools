using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Text;
using System.Linq;
using System.Net.Mail;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebWorksCore;
using WebWorksCore.Sections;

namespace WeatherTuner
{
    public class AtmosphereContent
    {
        static byte[] fileBytes;

        static byte[] sectionContent;
        static int sectionOffset;

        private static AssetManager _atmosphere;

        public static void LoadAtmosphere(string atmospherePath)
        {
            try
            {
                fileBytes = File.ReadAllBytes(atmospherePath);
                _atmosphere = new AssetManager(fileBytes);

                if (_atmosphere._assetType != AssetManager.AssetType.Atmosphere ||
                    _atmosphere._assetGame != AssetManager.AssetGame.MSM2)
                {
                    MessageBox.Show("Not a MSM2 atmosphere file! Expected MAGIC = 0x4FBCF482", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Couldn't read the .atmosphere file. Error: {ex}");
                return;
            }

            var atmosphereContentID = Section.Atmosphere.Content;

            sectionContent = _atmosphere.GetAssetSection(atmosphereContentID);
            sectionOffset = _atmosphere.GetAssetSectionOffset(atmosphereContentID);

            // Exit if the content can't be found
            if (sectionContent == null)
            {
                MessageBox.Show("Atmosphere content couldn't be found. Aborting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var AtmosphereValues_grid = WeatherTunerForm.Instance.AtmosphereValues_grid;
            var AtmosphereHashes_grid = WeatherTunerForm.Instance.AtmosphereHashes_grid;

            // Read the settings range and use them to load the settings into the AtmosphereValues_grid
            //--------------------------------------------------------------------------------------
            var settingsRanges = new List<(string ParentName, int MinAddress, int MaxAddress)>
            {
                ("Keylight Settings", 104, 279),

                ("Weather Settings", 52, 55),
                ("Weather Settings", 280, 375),

                ("Particles Settings", 1160, 1263),

                ("Wind Settings", 1264, 1311),

                ("Color Correction Settings", 1464, 1591),

                ("Vignette Settings", 1616, 1623),

                ("Chromatic Aberration Settings", 1624, 1639),

                ("Ambient Occlusion Settings", 1656, 1695),

                ("Anti-aliasing Settings", 1696, 1711),

                ("Fog Settings", 1732, 1783),
                ("Fog Settings", 1888, 1935),

                ("Motion Blur Settings", 1952, 1955),

                ("Depth Of Field Settings", 1960, 1975),

                ("Film Grain Settings", 1976, 1999),

                ("Rayleigh Settings", 2016, 2035),

                ("Light Shaft Settings", 2040, 2071),

                ("Camera Clip Settings", 2072, 2079),

                ("Volumetric Fog Settings", 1784, 1887),

                ("Bloom Settings", 1352, 1463),

                ("Tone Map Settings", 1312, 1344),

                ("Ocean Settings", 480, 691)
            };

            // Load values and hashes
            //--------------------------------------------------------------------------------------
            foreach (var (parentName, minAddress, maxAddress) in settingsRanges)
            {
                LoadAtmosphereValues(sectionContent, AtmosphereValues_grid, minAddress, maxAddress, parentName);
            }

            LoadAtmosphereHashes(sectionContent, AtmosphereHashes_grid);
        }

        //------------------------------------------------------------------------------------------
        public static void SaveAtmosphere(string filePath, DataGridView modified_AtmosphereValues_grid, DataGridView modified_AtmosphereHashes_grid)
        {
            // Save the atmosphere values and hashes
            try
            { 
                SaveAtmosphereValues(sectionContent, modified_AtmosphereValues_grid, _atmosphere._assetBytes, sectionOffset);
                SaveAtmosphereHashes(sectionContent, modified_AtmosphereHashes_grid, _atmosphere._assetBytes, sectionOffset);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred updating the atmosphere content. Error: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Write the modified atmosphere file bytes to user-specified path
            try
            {
                File.WriteAllBytes(filePath, _atmosphere._assetBytes);
                MessageBox.Show("Atmosphere values saved successfully.", "Success!", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Load atmosphere methods
        //------------------------------------------------------------------------------------------
        private static void LoadAtmosphereValues(byte[] content, DataGridView targetGrid, int minAddress, int maxAddress, string parentName)
        {
            var filteredValues = AtmosphereDefs.Values
                .Where(entry => entry.Address >= minAddress && entry.Address <= maxAddress)
                .ToList();

            int parentRowIndex = -1;
            foreach (DataGridViewRow row in targetGrid.Rows)
            {
                if (row.Cells[0].Value?.ToString() == parentName)
                {
                    parentRowIndex = row.Index;
                    break;
                }
            }

            if (parentRowIndex == -1)
            {
                targetGrid.Invoke((MethodInvoker)(() =>
                {
                    parentRowIndex = targetGrid.Rows.Add(); // Add a parent row
                    targetGrid.Rows[parentRowIndex].Cells[0].Value = parentName;
                    targetGrid.Rows[parentRowIndex].Cells[0].Style.Font = new Font(targetGrid.DefaultCellStyle.Font, FontStyle.Bold); // Set font to bold
                    targetGrid.Rows[parentRowIndex].Cells[1].Value = "";
                    targetGrid.Rows[parentRowIndex].Cells[2].Value = "+";
                    targetGrid.Rows[parentRowIndex].Tag = "collapsed";
                }));
            }

            foreach (var (name, address, type, mode, description) in filteredValues)
            {
                object value = null;

                if (type == AtmosphereDefs.t.Float)
                {
                    value = BitConverter.ToSingle(content, address);
                }
                else if (type == AtmosphereDefs.t.Int)
                {
                    value = BitConverter.ToInt32(content, address);
                }

                targetGrid.Invoke((MethodInvoker)(() =>
                {
                    int subrowIndex = targetGrid.Rows.Add();
                    targetGrid.Rows[subrowIndex].Cells[0].Value = name;
                    targetGrid.Rows[subrowIndex].Cells[1].Value = type.ToString();
                    targetGrid.Rows[subrowIndex].Cells[2].Value = value;
                    targetGrid.Rows[subrowIndex].Cells[3].Value = description;
                    targetGrid.Rows[subrowIndex].Cells[4].Value = address;
                    targetGrid.Rows[subrowIndex].Cells[5].Value = mode.ToString();

                    targetGrid.Rows[subrowIndex].Tag = parentRowIndex;

                    targetGrid.Rows[subrowIndex].Visible = false;
                }));
            }

            targetGrid.RowHeaderMouseClick -= TargetGrid_RowHeaderMouseClick;
            targetGrid.RowHeaderMouseClick += TargetGrid_RowHeaderMouseClick;
        }

        private static void LoadAtmosphereHashes(byte[] content, DataGridView targetGrid)
        {
            var allHashes = AtmosphereDefs.Hashes.ToList();

            foreach (var (name, address, description) in allHashes)
            {
                int startAddress = address;

                byte[] pathHashBytes = content.Skip(startAddress).Take(8).ToArray();
                string pathHash = BitConverter.ToString(pathHashBytes).Replace("-", "");

                // Reverse the pathHash in pairs
                pathHash = ReverseInPairs(pathHash);

                int extensionHashStart = startAddress + 8 + 12;
                byte[] extensionHashBytes = content.Skip(extensionHashStart).Take(4).ToArray();
                string extensionHash = BitConverter.ToString(extensionHashBytes).Replace("-", "");

                extensionHash = ReverseInPairs(extensionHash);

                targetGrid.Invoke((MethodInvoker)(() =>
                {
                    int rowIndex = targetGrid.Rows.Add();
                    targetGrid.Rows[rowIndex].Cells[0].Value = name;
                    targetGrid.Rows[rowIndex].Cells[1].Value = pathHash;
                    targetGrid.Rows[rowIndex].Cells[2].Value = extensionHash;
                    targetGrid.Rows[rowIndex].Cells[3].Value = address;
                }));
            }
        }

        // Helper method to reverse the string in pairs of two characters
        private static string ReverseInPairs(string hexString)
        {
            var pairs = new List<string>();
            for (int i = 0; i < hexString.Length; i += 2)
            {
                pairs.Add(hexString.Substring(i, 2));
            }
            pairs.Reverse();
            return string.Join("", pairs);
        }

        // Save atmosphere methods
        //------------------------------------------------------------------------------------------
        private static void SaveAtmosphereValues(byte[] sectionContent, DataGridView targetGrid, byte[] fileBytes, int sectionOffset)
        {
            foreach (DataGridViewRow row in targetGrid.Rows)
            {
                string valueType = row.Cells[1].Value?.ToString();
                string value = row.Cells[2].Value?.ToString();
                int address = Convert.ToInt32(row.Cells[4].Value);

                if (valueType == "Float" && !string.IsNullOrEmpty(value) && float.TryParse(value, out float floatValue))
                {
                    byte[] floatBytes = BitConverter.GetBytes(floatValue);
                    Array.Copy(floatBytes, 0, sectionContent, address, floatBytes.Length);
                }

                else if (valueType == "Int" && !string.IsNullOrEmpty(value) && int.TryParse(value, out int intValue))
                {
                    byte[] intBytes = BitConverter.GetBytes(intValue);
                    Array.Copy(intBytes, 0, sectionContent, address, intBytes.Length);
                }
            }

            Array.Copy(sectionContent, 0, fileBytes, sectionOffset, sectionContent.Length);
        }

        private static void SaveAtmosphereHashes(byte[] sectionContent, DataGridView targetGrid, byte[] fileBytes, int sectionOffset)
        {
            foreach (DataGridViewRow row in targetGrid.Rows)
            {
                string pathHashValue = row.Cells[1].Value?.ToString();
                string extensionHashValue = row.Cells[2].Value?.ToString();

                int address = Convert.ToInt32(row.Cells[3].Value);

                // Convert hex string values to byte arrays
                byte[] pathHashBytes = ConvertHexStringToByteArray(pathHashValue);
                byte[] extensionHashBytes = ConvertHexStringToByteArray(extensionHashValue);

                Array.Reverse(pathHashBytes);
                Array.Reverse(extensionHashBytes);

                Array.Copy(pathHashBytes, 0, sectionContent, address, pathHashBytes.Length);
                Array.Copy(extensionHashBytes, 0, sectionContent, address + 8 + 12, extensionHashBytes.Length);
            }

            Array.Copy(sectionContent, 0, _atmosphere._assetBytes, sectionOffset, sectionContent.Length);
        }

        // Helper method to convert to byte array
        private static byte[] ConvertHexStringToByteArray(string hexString)
        {
            int numberOfChars = hexString.Length;
            byte[] byteArray = new byte[numberOfChars / 2];

            for (int i = 0; i < byteArray.Length; i++)
            {
                byteArray[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }

            return byteArray;
        }

        // User input helper methods (Collapse and expand)
        //------------------------------------------------------------------------------------------
        private static void TargetGrid_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView targetGrid = (DataGridView)sender;
            int rowIndex = e.RowIndex;

            if (rowIndex >= 0 && targetGrid.Rows[rowIndex].Tag != null)
            {
                if (targetGrid.Rows[rowIndex].Tag.ToString() == "expanded")
                {
                    CollapseRows(targetGrid, rowIndex);
                }
                else if (targetGrid.Rows[rowIndex].Tag.ToString() == "collapsed")
                {
                    ExpandRows(targetGrid, rowIndex);
                }
            }
        }

        public static void CollapseRows(DataGridView targetGrid, int parentRowIndex)
        {
            foreach (DataGridViewRow row in targetGrid.Rows)
            {
                if (row.Tag is int parentRow && parentRow == parentRowIndex)
                {
                    row.Visible = false;
                }
            }

            targetGrid.Rows[parentRowIndex].Cells[2].Value = "+";
            targetGrid.Rows[parentRowIndex].Tag = "collapsed";
        }

        public static void ExpandRows(DataGridView targetGrid, int parentRowIndex)
        {
            foreach (DataGridViewRow row in targetGrid.Rows)
            {
                if (row.Tag is int parentRow && parentRow == parentRowIndex)
                {
                    bool isAdvanced = row.Cells[5].Value != null && row.Cells[5].Value.ToString() == "Advanced";

                    // Always show rows with "Simplified" mode
                    if (row.Cells[5].Value != null && row.Cells[5].Value.ToString() == "Simplified")
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        // Show only if it's not advanced or if the checkbox is checked
                        row.Visible = !isAdvanced || WeatherTunerForm.Instance.checkBox_AdvancedSettings.Checked;
                    }
                }
            }

            targetGrid.Rows[parentRowIndex].Cells[2].Value = "-";
            targetGrid.Rows[parentRowIndex].Tag = "expanded";
        }

    }
}
