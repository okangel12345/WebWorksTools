using WebWorks;
using WebWorks.Utilities;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using Spiderman;
using SpideyTextureScaler;

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

        // Search result class
        //------------------------------------------------------------------------------------------
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

        // User input
        //------------------------------------------------------------------------------------------
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

        // Search method
        //------------------------------------------------------------------------------------------
        private void Search()
        {
            dataGridView_Files.Rows.Clear();
            _displayedResults.Clear();

            var searchInput = SearchTextBox.Text.Trim();
            if (string.IsNullOrEmpty(searchInput))
            {
                label_ResultCount.Text = "0 results";
                return;
            }

            var searchQueries = ParseSearchQuery(searchInput);

            foreach (var asset in _assets)
            {
                if (asset.FullPath != null && MatchesAnyQuery(Normalize(asset.FullPath), searchQueries))
                {
                    AddRowToGrid(asset);
                }
            }

            foreach (var (path, assetIndices) in _assetsByPath)
            {
                foreach (var assetIndex in assetIndices)
                {
                    var asset = _assets[assetIndex];
                    if (asset.FullPath == null)
                    {
                        string fakePath = Path.Combine(path, asset.Name);
                        if (MatchesAnyQuery(Normalize(fakePath), searchQueries))
                        {
                            AddRowToGrid(asset);
                        }
                    }
                }
            }

            label_ResultCount.Text = $"{dataGridView_Files.Rows.Count} results";
        }

        // Parses the search query and splits by " OR " while handling normal space-separated words.
        private List<string[]> ParseSearchQuery(string input)
        {
            return input.Split(" OR ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(q => q.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                        .ToList();
        }

        // Checks if a given asset path matches any of the OR-separated word groups.
        private bool MatchesAnyQuery(string assetPath, List<string[]> queryGroups)
        {
            return queryGroups.Any(words => MatchesWords(assetPath, words));
        }

        // Checks if all words in an AND-group exist within the given path.
        private bool MatchesWords(string assetPath, string[] words)
        {
            return words.All(word => assetPath.Contains(word, StringComparison.OrdinalIgnoreCase));
        }

        // Adds an asset to the DataGridView
        //------------------------------------------------------------------------------------------
        private void AddRowToGrid(Asset asset)
        {
            dataGridView_Files.Rows.Add(
                asset.FullPath ?? asset.Name,
                asset.SizeFormatted,
                asset.Archive,
                asset.Span,
                asset.Id,
                asset.FullPath,
                asset.RefPath,
                asset.HasHeader
            );
        }

        //------------------------------------------------------------------------------------------
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
