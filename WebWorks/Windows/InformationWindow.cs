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
using System.Windows.Forms;
using System.Reflection;

namespace WebWorks.Windows
{
    public partial class InformationWindow : Form
    {
        public InformationWindow()
        {
            InitializeComponent();

            ToolUtils.ApplyStyle(this, Handle);

            MaximizeBox = false;
            MinimizeBox = false;

            richTextBox1.ReadOnly = true;

            richTextBox1.AppendText($"v{Assembly.GetExecutingAssembly().GetName().Version.ToString(3)}");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/okangel12345/WebWorksTools",
                UseShellExecute = true
            });
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
