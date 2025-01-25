using WebWorks;
using WebWorks.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using WebWorks.Utilities;

namespace WebWorks.Windows.Tools
{
    public partial class QuickGameLaunch : Form
    {
        //------------------------------------------------------------------------------------------
        public static QuickGameLaunch Instance { get; private set; }
        private string runningProcess;

        //------------------------------------------------------------------------------------------
        public QuickGameLaunch()
        {
            InitializeComponent();

            ToolUtils.ApplyStyle(this, Handle);
        }

        // Load and end game
        //------------------------------------------------------------------------------------------
        private async void LoadGame()
        {
            label_TempProcess.Text = textBox_Process.Text;
            runningProcess = textBox_Process.Text;

            await GameLaunchHelper.LoadGameAsync(textBox_GamePath.Text, textBox_Args.Text, textBox_Process.Text, panel1, richTextBox1);
        }
        public void ConfirmEndGame()
        {
            string targetProcessName = textBox_Process.Text;

            var confirmResult = MessageBox.Show($"Are you sure you want to end '{targetProcessName}'? All insances will be closed.",
                                                 "Confirm End Process",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Warning);
            if (confirmResult == DialogResult.Yes)
                EndGameProcess();
            else
                return;
        }
        public void EndGameProcess()
        {
            try
            {
                string targetProcessName = textBox_Process.Text;
                Process targetProcess = Process.GetProcessesByName(targetProcessName).FirstOrDefault();

                if (string.IsNullOrEmpty(targetProcessName))
                {
                    return;
                }

                if (targetProcess == null)
                {
                    richTextBox1.Text = $"The process '{targetProcessName}' is not currently running.";
                    return;
                }
                else
                {
                    targetProcess.Kill();
                }
            }
            catch
            { }

        }

        // Misc
        //------------------------------------------------------------------------------------------
        public bool IsProcessRunning()
        {
            if (string.IsNullOrEmpty(runningProcess) || string.IsNullOrWhiteSpace(runningProcess))
            {
                return false;
            }
            else
            {
                try
                {
                    return Process.GetProcessesByName(runningProcess).Length > 0;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public string GetProcessName()
        { return label_TempProcess.Text; }

        // User input
        //------------------------------------------------------------------------------------------
        private void BrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select a Program File";
            openFileDialog.Filter = "Executable Files (*.exe)|*.exe|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(openFileDialog.FileName);

                textBox_GamePath.Text = openFileDialog.FileName;

                textBox_Process.Text = fileNameWithoutExtension;
            }
        }
        private void StartGameButton_Click(object sender, EventArgs e)
        {
            LoadGame();
        }
        private void EndGameButton_Click(object sender, EventArgs e)
        {
            ConfirmEndGame();
        }
        private async void FullReloadButton_Click(object sender, EventArgs e)
        {
            EndGameProcess();
            Thread.Sleep(3000);

            LoadGame();
        }
        private void ParentWindowButton_Click(object sender, EventArgs e)
        {
            label_TempProcess.Text = textBox_Process.Text;
            GameLaunchHelper.ParentProcessToPanelAsync(label_TempProcess.Text, panel1, richTextBox1);
        }
    }
}
