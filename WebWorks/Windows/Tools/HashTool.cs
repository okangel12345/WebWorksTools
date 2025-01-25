using DAT1;
using WebWorks.Utilities;
using System.Media;

namespace WebWorks.Windows
{
    public partial class HashTool : Form
    {
        public HashTool()
        {
            InitializeComponent();

            textBox_Path1.Text = "";
            Hash(textBox_Path1.Text);

            DataContext = this;

            WebWorksShared.ToolboxStyle.ApplyToolBoxStyle(this, Handle);
        }

        private void Hash(string input)
        {
            var crc64 = CRC64.Hash(input, checkBox_Normalize.Checked);
            var crc32 = CRC32.Hash(input, checkBox_Normalize.Checked);
            textBox_Hash1.Text = $"{crc64:X016}";
            textBox_Hash2.Text = $"{crc32:X08}";
        }

        private void textBox_Path1_KeyUp(object sender, KeyEventArgs e)
        {
            Hash(textBox_Path1.Text);
        }

        private void CopyToClipboard(TextBox TextBox)
        {
            if (!string.IsNullOrEmpty(TextBox.Text))
            {
                Clipboard.SetText(TextBox.Text);
                SystemSounds.Hand.Play();
            }

        }
        private void btn_Copy64_Click(object sender, EventArgs e)
        {
            CopyToClipboard(textBox_Hash1);
        }

        private void btn_Copy32_Click(object sender, EventArgs e)
        {
            CopyToClipboard(textBox_Hash2);
        }

        private void checkBox_Normalize_CheckedChanged(object sender, EventArgs e)
        {
            Hash(textBox_Path1.Text);
        }

        private void HashTool_KeyDown(object sender, KeyEventArgs e)
        {
            ToolUtils.CloseWithKeyboardShortcut(this, sender, e);
        }
    }
}
