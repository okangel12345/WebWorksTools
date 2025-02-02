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

namespace SpideyAtmos
{
    public class AtmosphereContent
    {
        static byte[] fileBytes;

        static uint sectionID = 0x02F06D4E;
        static byte[] sectionContent;
        static int sectionOffset;

        public static void LoadAtmosphere(string atmospherePath)
        {
            fileBytes = File.ReadAllBytes(atmospherePath);

            sectionContent = CustomAssetUtilities.GetAssetSection(fileBytes, sectionID);
            sectionOffset = CustomAssetUtilities.GetAssetSectionOffset(fileBytes, sectionID);

            var AtmosphereValues_grid = SpideyAtmosForm.Instance.AtmosphereValues_grid;
            var AtmosphereHashes_grid = SpideyAtmosForm.Instance.AtmosphereHashes_grid;

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

            //--------------------------------------------------------------------------------------
            foreach (var (parentName, minAddress, maxAddress) in settingsRanges)
            {
                LoadAtmosphereValues(sectionContent, AtmosphereValues_grid, minAddress, maxAddress, parentName);
            }

            LoadAtmosphereHashes(sectionContent, AtmosphereHashes_grid);
        }

        public static void SaveAtmosphere(string filePath, DataGridView modified_AtmosphereValues_grid)
        {
            SaveAtmosphere(sectionContent, modified_AtmosphereValues_grid, fileBytes, sectionOffset, filePath);
        }

        //------------------------------------------------------------------------------------------
        private static void LoadAtmosphereValues(byte[] content, DataGridView targetGrid, int minAddress, int maxAddress, string parentName)
        {
            var filteredValues = AtmosphereDefs.Values
                .Where(entry => entry.Address >= minAddress && entry.Address <= maxAddress)
                .ToList();

            // Add the parent row
            int parentRowIndex = -1;
            foreach (DataGridViewRow row in targetGrid.Rows)
            {
                if (row.Cells[0].Value?.ToString() == parentName)
                {
                    parentRowIndex = row.Index;
                    break;
                }
            }

            // If no existing parent row is found, add a new one
            if (parentRowIndex == -1)
            {
                targetGrid.Invoke((MethodInvoker)(() =>
                {
                    parentRowIndex = targetGrid.Rows.Add(); // Add a parent row
                    targetGrid.Rows[parentRowIndex].Cells[0].Value = parentName; // Set parent row's name
                    targetGrid.Rows[parentRowIndex].Cells[0].Style.Font = new Font(targetGrid.DefaultCellStyle.Font, FontStyle.Bold); // Set font to bold
                    targetGrid.Rows[parentRowIndex].Cells[1].Value = ""; // Description for the parent
                    targetGrid.Rows[parentRowIndex].Cells[2].Value = "+"; // Expand/Collapse button text
                    targetGrid.Rows[parentRowIndex].Tag = "expanded"; // Tag to keep track of the state (collapsed or expanded)
                }));
            }

            // Iterate through the filtered values and add them as subrows under the parent
            foreach (var (name, address, type, description) in filteredValues)
            {
                object value = null;

                // Parse based on type (float or int)
                if (type == AtmosphereDefs.t.Float)
                {
                    value = BitConverter.ToSingle(content, address); // Parsing as float
                }
                else if (type == AtmosphereDefs.t.Int)
                {
                    value = BitConverter.ToInt32(content, address); // Parsing as int
                }

                // Add subrow (child row) under the parent row
                targetGrid.Invoke((MethodInvoker)(() =>
                {
                    int subrowIndex = targetGrid.Rows.Add();
                    targetGrid.Rows[subrowIndex].Cells[0].Value = name;
                    targetGrid.Rows[subrowIndex].Cells[1].Value = type.ToString();
                    targetGrid.Rows[subrowIndex].Cells[2].Value = value;
                    targetGrid.Rows[subrowIndex].Cells[3].Value = description;
                    targetGrid.Rows[subrowIndex].Cells[4].Value = address;

                    // Set the row as a subrow of the parent row
                    targetGrid.Rows[subrowIndex].Tag = parentRowIndex; // Link subrow to parent

                    // Initially hide child rows
                    targetGrid.Rows[subrowIndex].Visible = false;
                }));
            }

            // Remove any previous event handler to avoid duplication
            targetGrid.RowHeaderMouseClick -= TargetGrid_RowHeaderMouseClick;

            // Add event handler to handle row clicks (for expanding/collapsing)
            targetGrid.RowHeaderMouseClick += TargetGrid_RowHeaderMouseClick;
        }
        private static void LoadAtmosphereHashes(byte[] content, DataGridView targetGrid)
        {
            var allHashes = AtmosphereDefs.Hashes.ToList();

            foreach (var (name, address, description) in allHashes)
            {
                byte[] pathBytes = new byte[4];
                Array.Copy(content, address, pathBytes, 0, 4);

                for (int i = 0; i < 2; i++)
                {
                    byte temp = pathBytes[i * 2];
                    pathBytes[i * 2] = pathBytes[i * 2 + 1];
                    pathBytes[i * 2 + 1] = temp;
                }

                byte[] hashBytes = new byte[4];
                Array.Copy(content, address + 20, hashBytes, 0, 4);

                for (int i = 0; i < 2; i++)
                {
                    byte temp = hashBytes[i * 2];
                    hashBytes[i * 2] = hashBytes[i * 2 + 1];
                    hashBytes[i * 2 + 1] = temp;
                }

                string pathHash = BitConverter.ToString(pathBytes).Replace("-", "");
                string extensionHash = BitConverter.ToString(hashBytes).Replace("-", "");

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

        private static void SaveAtmosphere(byte[] sectionContent, DataGridView targetGrid, byte[] fileBytes, int sectionOffset, string filePath)
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

            try
            {
                File.WriteAllBytes(filePath, fileBytes);
                MessageBox.Show("Atmosphere values saved successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving file: {ex.Message}");
            }
        }


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

        // Collapse rows function
        private static void CollapseRows(DataGridView targetGrid, int parentRowIndex)
        {
            foreach (DataGridViewRow row in targetGrid.Rows)
            {
                if (row.Tag is int parentRow && parentRow == parentRowIndex)
                {
                    row.Visible = false; // Hide child row
                }
            }

            // Change the parent row to indicate it's collapsed
            targetGrid.Rows[parentRowIndex].Cells[2].Value = "+"; // Show the "+" icon for collapse
            targetGrid.Rows[parentRowIndex].Tag = "collapsed"; // Update the parent row's tag to "collapsed"
        }

        // Expand rows function
        private static void ExpandRows(DataGridView targetGrid, int parentRowIndex)
        {
            foreach (DataGridViewRow row in targetGrid.Rows)
            {
                if (row.Tag is int parentRow && parentRow == parentRowIndex)
                {
                    row.Visible = true; // Show child row
                }
            }

            // Change the parent row to indicate it's expanded
            targetGrid.Rows[parentRowIndex].Cells[2].Value = "-"; // Show the "-" icon for expand
            targetGrid.Rows[parentRowIndex].Tag = "expanded"; // Update the parent row's tag to "expanded"
        }
    }
}
