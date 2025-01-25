using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebWorks.Windows;
using System.Reflection.Metadata;
using System.Windows.Forms;

namespace WebWorks.Utilities
{
    internal class ToolUtils
    {
        // Close form with Ctrl + W
        //------------------------------------------------------------------------------------------
        public static void CloseWithKeyboardShortcut(Form formToClose, object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.W)
            {
                formToClose.Close();
            }

            if (e.KeyCode == Keys.Escape)
            {
                formToClose.Close();
            }
        }

        // Check for file
        //------------------------------------------------------------------------------------------
        public static void EnsureFileExists(string filePath, string? type = null)
        {
            type = type ?? "file";

            if (!File.Exists(filePath))
            {
                MessageBox.Show($"The {type} was not found at:\n{filePath}",
                                "File not found!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                return;
            }
        }


        // Load Style with settings
        //------------------------------------------------------------------------------------------
        public static void ApplyStyle(Control parent, IntPtr hwnd, MenuStrip strip = null, ContextMenuStrip context = null)
        {
            SettingsWindow sets = new SettingsWindow();
            AppSettings settings = sets.LoadSettings();
            WebWorksShared.ToolboxStyle.ApplyToolBoxStyle(parent, hwnd, strip, context, settings._accentColor, settings._accentColorGrid);
        }

        // Copy to clipboard
        //------------------------------------------------------------------------------------------
        public static void copyToClipboard(string[] paths)
        {
            string clipboardText = paths.Length == 1 ? paths[0] : string.Join(", ", paths);
            Clipboard.SetText(clipboardText);
        }
    }

    // Modding Tool classes
    //----------------------------------------------------------------------------------------------
    public static class Extensions
    {
        public static void Set<K, V>(this Dictionary<K, V> d, K k, V v)
        {
            if (d.ContainsKey(k))
                d[k] = v;
            else
                d.Add(k, v);
        }

        public static void Update<K, V>(this Dictionary<K, V> d, K k, V v, Func<V, V, V> update)
        {
            if (d.ContainsKey(k))
                d[k] = update(d[k], v);
            else
                d.Add(k, v);
        }
    }
    public static class SizeFormat
    {
        public static string FormatSize(uint bytesCount)
        {
            var v = bytesCount;
            var r = "";
            var u = "B";

            if (v > 1024)
            {
                r = Remainder(v);
                v /= 1024;
                u = "KB";

                if (v > 1024)
                {
                    r = Remainder(v);
                    v /= 1024;
                    u = "MB";

                    if (v > 1024)
                    {
                        r = Remainder(v);
                        v /= 1024;
                        u = "GB";
                    }
                }
            }

            return $"{v}{r} {u}";
        }

        private static string Remainder(uint v)
        {
            if (v % 1024 == 0) return "";
            var v2 = (v % 1024) / 1024.0;
            int v3 = (int)(v2 * 10);
            if (v3 == 0) return ".1";
            return "." + v3;
        }
    }
    public class Asset
    {
        public byte Span { get; set; }
        public ulong Id;
        public uint Size { get; set; }
        public string SizeFormatted { get => SizeFormat.FormatSize(Size); }
        public bool HasHeader;

        public string Name { get; set; }
        public string Archive { get; set; }
        public string FullPath = null;
        public string RefPath { get => $"{Span}/{Id:X016}"; }
    }
    public class AssetWWPROJHelper
    {
        public byte Span { get; }
        public ulong Id { get; }
        public string Name { get; }
        public string Archive { get; }
        public string FullPath { get; }
        public string RefPath { get; }
        public string AssociatedString { get; }

        // Constructor to map Asset to AssetDataWithString and include the associated string
        public AssetWWPROJHelper(Asset asset, string associatedString)
        {
            Span = asset.Span;
            Id = asset.Id;
            Name = asset.Name;
            Archive = asset.Archive;
            FullPath = asset.FullPath;
            RefPath = $"{Span}/{Id:X016}";
            AssociatedString = associatedString;  // Store the associated string
        }
    }
}
