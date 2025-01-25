using System.ComponentModel;
using System.Data;

namespace Spandex
{
    public partial class Form2 : Form
    {
        public HashSet<string> valuepool;
        public List<string> displayed;
        public string? selected;

        internal string lastneedle;
        public Form2(string current, HashSet<string> values)
        {
            InitializeComponent();
            valuepool = values;
            searchBox.Text = current;

            resultlist.DataSource = displayed;
            backgroundWorker1.WorkerSupportsCancellation = false;

            WebWorksShared.ToolboxStyle.ApplyToolBoxStyle(this, Handle);
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
            }
            else
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            lastneedle = searchBox.Text;
            BackgroundWorker worker = (BackgroundWorker)sender;

            // Split the search term into individual keywords, removing any extra spaces
            var keywords = lastneedle.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Search for items that contain all of the keywords
            displayed = valuepool.Where(s => !worker.CancellationPending &&
                                              keywords.All(keyword => s.Contains(keyword, StringComparison.OrdinalIgnoreCase)))
                                 .Take(1000)
                                 .ToList();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (lastneedle != searchBox.Text)
                // Start again if cancelled
                backgroundWorker1.RunWorkerAsync();
            else
            {
                resultlist.DataSource = displayed;
                selected = null;
                resultlist.SelectedIndex = -1;
            }
        }


        //private void searchBox_TextChanged(object sender, EventArgs e)
        //{
        //    if (backgroundWorker1.IsBusy)
        //    {
        //        backgroundWorker1.CancelAsync();

        //    }
        //    else
        //        backgroundWorker1.RunWorkerAsync();
        //}

        //private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    lastneedle = searchBox.Text;
        //    BackgroundWorker worker = (BackgroundWorker)sender;
        //    displayed = valuepool.Where(s => !worker.CancellationPending && s.Contains(lastneedle, StringComparison.OrdinalIgnoreCase)).
        //        Where(s => !worker.CancellationPending).Take(1000).ToList();
        //}

        //private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    if (lastneedle != searchBox.Text)
        //        start again if cancelled
        //        backgroundWorker1.RunWorkerAsync();
        //    else
        //    {
        //        resultlist.DataSource = displayed;
        //        selected = null;
        //        resultlist.SelectedIndex = -1;
        //    }
        //}

        private void resultlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy && resultlist.SelectedIndex > -1)
                selected = (string)resultlist.SelectedItem;
            else
                selected = null;

            button1.Enabled = selected != null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}