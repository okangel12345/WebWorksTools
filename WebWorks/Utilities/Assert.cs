using WebWorks.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace WebWorks.Windows.Asserts
{
    public partial class Assert : Form
    {
        public enum IconType
        {
            None,
            Warning,
            Error
        }

        public enum AssertResult
        {
            OK,
            Cancel
        }

        public AssertResult Result { get; private set; }

        public Assert(string message, string title, string okButtonText = "OK", string cancelButtonText = "Cancel")
        {
            InitializeComponent();
            ToolUtils.ApplyStyle(this, Handle);

            MessageBox.Show("Test");
            richTextBox1.Text = message;
            Text = title;

            Size messageSize = MeasureTextSize(message, richTextBox1.Font);

            // Adjust form and control sizes
            int width = Math.Max(300, messageSize.Width + 100); // Minimum width
            int height = messageSize.Height + 120; // Add extra space for buttons and padding

            this.ClientSize = new Size(width, height);
            richTextBox1.Size = new Size(messageSize.Width, messageSize.Height);
            richTextBox1.Text = message;
        }

        private Size MeasureTextSize(string text, Font font)
        {
            using (Graphics g = this.CreateGraphics())
            {
                return g.MeasureString(text, font).ToSize();
            }
        }
    }
}
