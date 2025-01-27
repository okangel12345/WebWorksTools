using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebWorksCore
{
    public class DialogsToTextbox
    {
        public static void OpenFileDialogAndSaveToTextbox(TextBox textBox, params string[] extensions)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a file...";

                string filter = "";
                if (extensions != null && extensions.Length > 0)
                {
                    string joinedExtensions = string.Join(";", extensions.Select(ext => $"*.{ext}"));
                    filter = $"Supported files ({joinedExtensions})|{joinedExtensions}|";
                }
                filter += "All files|*.*";

                openFileDialog.Filter = filter;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox.Text = openFileDialog.FileName;
                }
            }
        }

        public static void OpenSaveFileDialogAndSaveToTextbox(TextBox textBox, params string[] extensions)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Select an output path...";

                string filter = "";
                if (extensions != null && extensions.Length > 0)
                {
                    string joinedExtensions = string.Join(";", extensions.Select(ext => $"*.{ext}"));
                    filter = $"Supported files ({joinedExtensions})|{joinedExtensions}|";
                }
                filter += "All files|*.*";

                saveFileDialog.Filter = filter;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox.Text = saveFileDialog.FileName;
                }
            }
        }
    }
}
