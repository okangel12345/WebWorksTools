using WebWorks.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace WebWorks.Windows
{
    public partial class StageSelectorWindow : Form
    {
        // Initiliaze

        private ObservableCollection<string> _stages = new();
        private bool _verified = false;
        public bool OnlyExisting = false;
        public string Stage = null;

        //------------------------------------------------------------------------------------------
        public StageSelectorWindow()
        {
            InitializeComponent();

            _stages.Clear();

            WarningMessage.Text = "";

            ToolUtils.ApplyStyle(this, Handle);

            var cwd = Directory.GetCurrentDirectory();
            var path = Path.Combine(cwd, "stages");
            if (Directory.Exists(path))
            {
                var dirs = Directory.GetDirectories(path, "*", SearchOption.TopDirectoryOnly);
                foreach (var dir in dirs)
                {
                    _stages.Add(Path.GetRelativePath(path, dir));
                }
            }

            NameComboBox.DataSource = _stages;
            Verify();
        }

        // Verify stage folder exists
        //------------------------------------------------------------------------------------------
        private bool Verify()
        {
            _verified = false;

            var text = NameComboBox.Text;
            var isValid = Regex.IsMatch(text, "^[A-Za-z0-9 _-]+$");
            var stageExists = _stages.Contains(text);
            _verified = isValid;

            WarningMessage.Text = (isValid ? "" : "Stage name isn't valid!");
            SelectButton.Enabled = isValid;
            SelectButton.Text = (stageExists ? "Select" : "Create");

            if (OnlyExisting && !stageExists)
            {
                WarningMessage.Text = "Stage doesn't exist!";
                SelectButton.Enabled = false;
                SelectButton.Text = "Select";
                _verified = false;
            }

            return _verified;
        }

        // Select a stage folder
        //------------------------------------------------------------------------------------------
        private void Select()
        {
            if (!Verify()) return;

            Stage = NameComboBox.Text;
            Close();
        }

        // User input
        //------------------------------------------------------------------------------------------
        private void SelectButton_Click(object sender, EventArgs e)
        {
            Select();
        }

        private void NameComboBox_TextChanged(object sender, EventArgs e)
        {
            Verify();
        }

        private void NameComboBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Select();
            }
        }
    }
}
