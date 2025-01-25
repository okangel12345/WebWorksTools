using WebWorks.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using KeyEventArgs = System.Windows.Forms.KeyEventArgs;

namespace WebWorks.Windows.Search
{
    public partial class JumpToWindow : Form
    {
        public bool Jumped = false;
        public string Path = null;

        public JumpToWindow()
        {
            InitializeComponent();

            ToolUtils.ApplyStyle(this, Handle);
        }

        private void PathTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Jump();
            }
        }

        private void JumpButton_Click(object sender, EventArgs e)
        {
            Jump();
        }

        private void Jump()
        {
            Jumped = true;
            Path = PathTextBox.Text;
            Close();
        }

        private void JumpToWindow_KeyDown(object sender, KeyEventArgs e)
        {
            ToolUtils.CloseWithKeyboardShortcut(this, sender, e);
        }
    }
}
