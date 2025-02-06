using WebWorks;
using WebWorks.Utilities;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace WebWorks.Windows.Search
{
    public partial class SearchWindow : Form
    {
        private List<Asset> _assets;
        private Dictionary<string, List<int>> _assetsByPath;
        private System.Action<string> _callback;
        private System.Action<string, System.Collections.IList> _contextMenuCallback;
        private ObservableCollection<SearchResult> _displayedResults = new();

        MainWindow mainWindow = MainWindow.Instance;

        public SearchWindow(List<Asset> assets, Dictionary<string, List<int>> assetsByPath)
        {
            InitializeComponent();
            _assets = assets;
            _assetsByPath = assetsByPath;

            SearchTextBox.Text = "";
            Search();

            ToolUtils.ApplyStyle(this, Handle);
        }

        class SearchResult
        {
            public int AssetIndex { get; set; }
            public byte Span { get; set; }
            public ulong Id;
            public uint Size { get; set; }
            public string SizeFormatted { get => SizeFormat.FormatSize(Size); }

            public string Path { get; set; }
            public string Archive { get; set; }
            public string RefPath { get => $"{Span}/{Id:X016}"; }
        }

        private void SearchTextBox_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            dataGridView_Files.Rows.Clear();
            _displayedResults.Clear();

            var search = Normalize(SearchTextBox.Text.Trim());
            var words = search.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (words.Length > 0)
            {
                var i = 0;
                foreach (var asset in _assets)
                {
                    if (asset.FullPath != null && MatchesWords(Normalize(asset.FullPath), words))
                    {
                        dataGridView_Files.Rows.Add(asset.FullPath, asset.SizeFormatted, asset.Archive, asset.Span, asset.Id, asset.FullPath, asset.RefPath, asset.HasHeader);
                    }
                    ++i;
                }

                foreach (var path in _assetsByPath.Keys)
                {
                    foreach (var assetIndex in _assetsByPath[path])
                    {
                        var asset = _assets[assetIndex];
                        if (asset.FullPath != null) continue;

                        var fakepath = Path.Combine(path, asset.Name);
                        if (MatchesWords(Normalize(fakepath), words))
                        {
                            dataGridView_Files.Rows.Add(asset.Name, asset.SizeFormatted, asset.Archive, asset.Span, asset.Id, asset.FullPath, asset.RefPath, asset.HasHeader);
                        }
                    }
                }
            }

            label_ResultCount.Text = $"{dataGridView_Files.Rows.Count} results";
        }

        private static string Normalize(string text)
        {
            return text.Replace('\\', '/').ToLower();
        }

        private static bool MatchesWords(string path, IEnumerable<string> words)
        {
            foreach (var word in words)
            {
                if (!path.Contains(word)) return false;
            }
            return true;
        }

        private void dataGridView_Files_MouseClick(object sender, MouseEventArgs e)
        {
            mainWindow.OpenContextMenu(sender, e);
        }

        private void dataGridView_Files_KeyDown(object sender, KeyEventArgs e)
        {
            mainWindow.CommandsDataGrid(sender, e);
        }

        private void SearchWindow_KeyDown(object sender, KeyEventArgs e)
        {
            ToolUtils.CloseWithKeyboardShortcut(this, sender, e);
        }

        private void dataGridView_Files_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView_Files.SelectedRows[0];

            foreach (DataGridViewRow row in dataGridView_Files.Rows)
            {
                if (row != selectedRow)
                {
                    row.Selected = false;
                }
            }

            string path = GetCurrentAssets.Paths()[0];

            mainWindow.JumpTo(path);
        }

        private void dataGridView_Files_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MainWindow.Instance.SortBySize_MouseClick(sender, e);
        }
    }
}
