using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebWorksCore.Updater
{
    public partial class UpdateWindow : Form
    {
        public UpdateWindow(string currentVersion, string newestVersion, string newestPatchNotes)
        {
            InitializeComponent();
            WebWorksShared.ToolboxStyle.ApplyToolBoxStyle(this, Handle);

            SystemSounds.Beep.Play();

            label1.Text = $"WebWorks v{newestVersion} is available. You currently have WebWorks v{currentVersion}.";
            richTextBox1.Text = newestPatchNotes;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/okangel12345/WebWorksTools/releases/latest",
                UseShellExecute = true
            });
        }
    }

    public class UpdateChecker
    {
        private const string GitHubAPIUrl = "https://api.github.com/repos/okangel12345/WebWorksTools/releases/latest";
        private static string _currentVersion;
        private static string _latestVersion;
        private static string _patchNotes;
        private static readonly HttpClient client = new HttpClient { DefaultRequestHeaders = { { "User-Agent", "request" } } };


        public static async Task CheckForUpdateAsync()
        {
            try
            {
                _currentVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();

                using (client)
                {
                    client.DefaultRequestHeaders.Add("User-Agent", "request");

                    var response = await client.GetStringAsync(GitHubAPIUrl);

                    var latestRelease = JObject.Parse(response);

                    _latestVersion = latestRelease["tag_name"].ToString();
                    _patchNotes = latestRelease["body"].ToString();

                    string _extractedVersion = ExtractVersion(_latestVersion);

                    if (IsNewerVersion(_currentVersion, _extractedVersion))
                    {
                        ShowUpdateWindow(_currentVersion, _extractedVersion, _patchNotes);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error checking for updates: {ex.Message}");
                MessageBox.Show("An error occurred while checking for updates. Please try again later.", "Update Check Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string ExtractVersion(string versionString)
        {
            // "WebWorks_1.0.7" -> "1.0.7"
            var match = Regex.Match(versionString, @"_(\d+\.\d+\.\d+)");
            return match.Success ? match.Groups[1].Value : string.Empty;
        }

        private static bool IsNewerVersion(string currentVersion, string latestVersion)
        {
            var current = new Version(currentVersion);
            var latest = new Version(latestVersion);
            return latest > current;
        }

        private static void ShowUpdateWindow(string currentVersion, string latestVersion, string patchNotes)
        {
            if (Application.OpenForms[0].InvokeRequired)
            {
                Application.OpenForms[0].Invoke(new Action(() =>
                {
                    UpdateWindow updateWindow = new UpdateWindow(currentVersion, latestVersion, patchNotes);
                    updateWindow.ShowDialog();
                }));
            }
            else
            {
                UpdateWindow updateWindow = new UpdateWindow(currentVersion, latestVersion, patchNotes);
                updateWindow.ShowDialog();
            }
        }
    }
}
