using DAT1;
using DAT1.Sections.TOC;

using SpideyTextureScaler;
using Spiderman;

using WebWorks.Utilities;
using WebWorks.Windows;
using WebWorks.Windows.Tools;
using WebWorks.Windows.Asserts;
using WebWorks.Windows;
using WebWorks.Utilities;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Text;
using System.Windows.Controls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WebWorks
{
    //----------------------------------------------------------------------------------------------
    //
    // Spidey Toolbox Main Window
    //
    //----------------------------------------------------------------------------------------------
    public partial class MainWindow : Form
    {
        public static MainWindow Instance { get; private set; }

        bool SkipRecentToc = false;

        static SettingsWindow settingsWindow = new SettingsWindow();
        AppSettings settings = settingsWindow.LoadSettings();

        //------------------------------------------------------------------------------------------
        public MainWindow(string filePath, string tocPath, bool skipRecentToc)
        {
            InitializeComponent();

            Instance = this;

            ToolUtils.ApplyStyle(this, Handle, menuStrip1, contextMenuStrip1);

            panel_Main.Dock = DockStyle.Fill;

            if (!string.IsNullOrEmpty(filePath))
            {
                ReadFile(filePath);
            }

            if (!string.IsNullOrEmpty(tocPath))
            {
                StartLoadTOCThread(tocPath);
            }

            SkipRecentToc = skipRecentToc;
        }

        // Initialize
        //------------------------------------------------------------------------------------------
        private Thread _tickThread;
        private List<Thread> _taskThreads = new();

        // loaded data
        public static TOCBase? _toc = null;
        public string? _tocPath = null;
        public List<Asset> _assets = new();
        public string? _selectedHashes = null;
        public Dictionary<string, List<int>> _assetsByPath = new();

        // replaced data
        public Dictionary<Asset, string> _replacedAssets = new();
        public Dictionary<Asset, string> _addedAssets = new();


        #region User Settings

        // Load user settings
        //------------------------------------------------------------------------------------------
        private void LoadPreferences()
        {
            OverlayHeaderLabel.Text = "";
            OverlayOperationLabel.Text = "";

            LoadRecentTOC();
            LoadRecentMenus();
        }
        private void LoadRecentTOC(object sender = null, EventArgs e = null, string TOC = "")
        {
            if (settings._autoloadRecent == true && settings._recentTOC1 != null && TOC == "" && !SkipRecentToc)
            {
                StartLoadTOCThread(settings._recentTOC1);
            }
            else if (TOC != "")
            {
                StartLoadTOCThread(TOC);
            }
        }
        private void LoadRecentMenus()
        {
            ToolStripMenuItem[] toolStripMenuItems = { toolStripMenuItem2,
                                                       toolStripMenuItem3,
                                                       toolStripMenuItem4,
                                                       toolStripMenuItem5,
                                                       toolStripMenuItem6 };

            string[] recentTOCs = { settings._recentTOC1,
                                    settings._recentTOC2,
                                    settings._recentTOC3,
                                    settings._recentTOC4,
                                    settings._recentTOC5 };


            int nonEmptyCount = recentTOCs.Count(t => !string.IsNullOrEmpty(t));

            if (nonEmptyCount >= 1)
            {
                loadRecentToolStripMenuItem.Visible = true;
            }
            else
            {
                loadRecentToolStripMenuItem.Visible = false;
            }

            for (int i = 0; i < toolStripMenuItems.Length; i++)
            {
                if (!string.IsNullOrEmpty(recentTOCs[i]))
                {
                    string numTOC = recentTOCs[i];
                    toolStripMenuItems[i].Text = recentTOCs[i];
                    toolStripMenuItems[i].Visible = true;
                    toolStripMenuItems[i].Click += (sender, e) => LoadRecentTOC(sender, e, numTOC);
                }
                else
                {
                    toolStripMenuItems[i].Visible = false;
                }
            }

            // Load all hashes in the program's directory
            string appDir = AppDomain.CurrentDomain.BaseDirectory;
            string? recentHashes = settings._recentHashes;

            foreach (string file in Directory.GetFiles(appDir))
            {
                string fileName = Path.GetFileName(file);

                if (fileName.StartsWith("hashes_", StringComparison.OrdinalIgnoreCase) ||
                    fileName.Equals("hashes.txt", StringComparison.OrdinalIgnoreCase))
                {
                    var existingItem = hashesToolStripMenuItem.DropDownItems
                        .OfType<ToolStripMenuItem>()
                        .FirstOrDefault(item => item.Text.Equals(fileName, StringComparison.OrdinalIgnoreCase));

                    if (existingItem != null)
                    {
                        hashesToolStripMenuItem.DropDownItems.Remove(existingItem);
                    }

                    var menuItem = new ToolStripMenuItem(fileName)
                    {
                        CheckOnClick = true
                    };

                    menuItem.Click += HashesMenu_Click;

                    hashesToolStripMenuItem.DropDownItems.Add(menuItem);

                    if (hashesToolStripMenuItem.DropDownItems
                        .OfType<ToolStripMenuItem>()
                        .All(item => !item.Checked))
                    {
                        menuItem.Checked = true;
                        settings._recentHashes = menuItem.Text;
                    }

                    if (recentHashes != null && recentHashes.Equals(fileName, StringComparison.OrdinalIgnoreCase))
                    {
                        foreach (ToolStripMenuItem item in hashesToolStripMenuItem.DropDownItems)
                        {
                            item.Checked = false;
                        }

                        menuItem.Checked = true;
                        settings._recentHashes = fileName;
                    }

                    // Save the settings
                    settingsWindow.SaveSettings(settings);
                }
            }
        }
        private void HashesMenu_Click(object? sender, EventArgs e)
        {
            if (_toc != null)
            {
                var f = MessageBox.Show("Do you want to change hashes? TOC will be reloaded and all unsaved progress will be lost.", "Warning", MessageBoxButtons.YesNo);

                if (f == DialogResult.Yes)
                {
                    SaveRecentHashesSetting(sender);

                    Process.Start(Application.ExecutablePath, $"none \"{_tocPath}\" -skipMostRecentTOC");
                    Application.Exit();
                    Dispose();
                }
            }
            else
            {
                SaveRecentHashesSetting(sender);
            }
        }

        private void SaveRecentHashesSetting(object? sender)
        {
            foreach (ToolStripMenuItem item in hashesToolStripMenuItem.DropDownItems)
            {
                if (item == sender)
                {
                    item.Checked = true;
                    settings._recentHashes = item.Text;
                }
                else
                {
                    item.Checked = false;
                }
            }

            settingsWindow.SaveSettings(settings);
        }

        // Recent TXT handle
        private void SaveRecentTXT(string path)
        {
            // Available setting slots
            string[] recentTOC = new string[]
            {
                settings._recentTOC1,
                settings._recentTOC2,
                settings._recentTOC3,
                settings._recentTOC4,
                settings._recentTOC5
            };

            int existingIndex = Array.IndexOf(recentTOC, path);

            if (existingIndex != -1)
            {
                for (int i = existingIndex; i > 0; i--)
                {
                    recentTOC[i] = recentTOC[i - 1];
                }
            }
            else
            {
                for (int i = recentTOC.Length - 1; i > 0; i--)
                {
                    recentTOC[i] = recentTOC[i - 1];
                }
            }

            recentTOC[0] = path;

            UpdateSettings(settings, recentTOC);
            settingsWindow.SaveSettings(settings);
        }
        private void UpdateSettings(AppSettings settings, string[] recentTOC)
        {
            settings._recentTOC1 = recentTOC[0];
            settings._recentTOC2 = recentTOC[1];
            settings._recentTOC3 = recentTOC[2];
            settings._recentTOC4 = recentTOC[3];
            settings._recentTOC5 = recentTOC[4];
        }

        #endregion

        #region Tick
        // Load Ticks
        //------------------------------------------------------------------------------------------
        private void StartTickThread()
        {
            _tickThread = new Thread(TickThread)
            {
                IsBackground = true
            };
            _tickThread.Start();
        }
        private bool isRunning = true;

        private void TickThread()
        {
            try
            {
                while (true)
                {
                    Thread.Sleep(16);
                    Tick();
                }
            }
            catch (ThreadInterruptedException)
            { } // Do nothing
            catch
            { } // Do nothing
        }
        private void Tick()
        {
            List<Thread> threadsToRemove = new();
            foreach (var thread in _taskThreads)
            {
                if (!thread.IsAlive)
                {
                    threadsToRemove.Add(thread);
                }
            }
        }

        #endregion

        #region LoadTOC

        //-----------------------------------------------------------------------------------------
        //  Start loading the TOC
        //-----------------------------------------------------------------------------------------
        public void StartLoadTOCThread(string path)
        {
            // Restart application with new TOC
            if (_toc != null)
            {
                var f = MessageBox.Show("Are you sure you want to open a new TOC? All unsaved progress will be lost.",
                                        "Warning",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Warning);

                if (f == DialogResult.Yes)
                {
                    Process.Start(Application.ExecutablePath, $"none \"{path}\" -skipMostRecentTOC");
                    Application.Exit();
                    Dispose();
                }
                else
                {
                    return;
                }
            }

            SaveRecentTXT(path);
            //LoadRecentMenus();

            var tocPath = path;
            _tocPath = path;

            // Clear existing fields and lists
            _assets.Clear();
            _replacedAssets.Clear();
            _addedAssets.Clear();
            _assetsByPath.Clear();

            TreeView_Assets.Nodes.Clear();
            dataGridView_Files.Rows.Clear();

            // Set home environment
            SetEnvironment.Home();

            // Load original TOC file (toc.BAK) created by Overstrike
            if (!settings._loadtocModded)
            {
                string gameFolder = Path.GetDirectoryName(path);
                string backupTOC = Path.Combine(gameFolder, "toc.BAK");

                if (File.Exists(backupTOC))
                {
                    tocPath = backupTOC;
                }
                else
                {
                    tocPath = path;
                }
            }

            // Verify file exists
            if (!File.Exists(tocPath))
            {
                MessageBox.Show($"TOC file \"{tocPath}\" not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //-------------------------------------------------------------------------------------
            // Start a new thread for TOC loading
            //-------------------------------------------------------------------------------------
            Thread thread = new(() =>
            {
                try
                {
                    LoadTOC(tocPath);

                    Invoke(() =>
                    {
                        // Set Modding Tool environment
                        menuStrip1.Visible = true;
                        SetEnvironment.ModdingTool();
                    });
                }
                catch (Exception ex)
                {
                    try
                    {
                        this.Invoke(() =>
                        {
                            MessageBox.Show($"An error occurred while loading the TOC: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        });
                    }
                    catch { }

                }
            });

            // Add thread
            _taskThreads.Add(thread);
            thread.Start();
        }

        //-----------------------------------------------------------------------------------------
        // Load TOC file method
        //-----------------------------------------------------------------------------------------
        private void LoadTOC(string path)
        {
            // Start loading and set environment
            this.Invoke(() =>
            {
                OverlayHeaderLabel.Text = $"Loading '{Path.GetFileName(path)}'...";
                OverlayOperationLabel.Text = "-";

                menuStrip1.Visible = false;
            });

            // Identify TOC
            _toc = LoadTOCFile(path);
            if (_toc == null) return;

            // List archive names
            var archiveNames = new List<string>();
            for (uint i = 0; i < _toc.GetArchivesCount(); ++i)
            {
                var fn = _toc.GetArchiveFilename(i);

                if (_toc is TOC_I29 && fn.StartsWith("d\\"))
                {
                    fn = fn.Substring(2); // Clean up for readability
                }

                archiveNames.Add(fn);
            }

            //-------------------------------------------------------------------------------------
            // Start getting assets
            //-------------------------------------------------------------------------------------
            int progress = 0;
            int progressTotal = _toc.AssetIdsSection.Values.Count;
            byte spanIndex = 0;

            foreach (var span in _toc.SpansSection.Values)
            {
                for (int i = (int)span.AssetIndex; i < span.AssetIndex + span.Count; ++i)
                {
                    bool hasHeader = (spanIndex % 8 == 0);
                    if (hasHeader && _toc is TOC_I29)
                    {
                        hasHeader = (((TOC_I29)_toc).SizesSection.Values[i].HeaderOffset != -1);
                    }

                    _assets.Add(new Asset
                    {
                        Span = spanIndex,
                        Id = _toc.AssetIdsSection.Values[i],
                        Size = (uint)_toc.GetSizeInArchiveByAssetIndex(i),
                        HasHeader = hasHeader,
                        Name = "",
                        Archive = archiveNames[(int)_toc.GetArchiveIndexByAssetIndex(i)]
                    });

                    ++progress;
                    if (progress % 1000 == 0)
                    {
                        this.Invoke(() =>
                        {
                            OverlayHeaderLabel.Text = $"Loading '{Path.GetFileName(path)}'...";
                            OverlayOperationLabel.Text = $"{progress}/{progressTotal} assets";
                        });
                    }
                }
                ++spanIndex;
            }

            this.Invoke(() => OverlayOperationLabel.Text = "-");

            //-------------------------------------------------------------------------------------
            // Load known hashes
            //-------------------------------------------------------------------------------------
            var appdir = AppDomain.CurrentDomain.BaseDirectory;
            var selectedHashes = hashesToolStripMenuItem.DropDownItems
                                    .OfType<ToolStripMenuItem>()
                                    .FirstOrDefault(item => item.Checked)?.Text;

            _selectedHashes = selectedHashes;

            // Default to hashes.txt if selected is null
            if (selectedHashes == null)
            {
                selectedHashes = "hashes.txt";
            }

            // Build hashes path and use it
            var hashes_fn = Path.Combine(appdir, selectedHashes);
            var knownHashes = new Dictionary<ulong, string>();

            knownHashes.Clear();

            if (File.Exists(hashes_fn))
            {
                var lines = File.ReadLines(hashes_fn);
                progress = 0;
                progressTotal = lines.Count();

                foreach (var line in lines)
                {
                    try
                    {
                        var firstComma = line.IndexOf(',');
                        if (firstComma == -1) continue;

                        var lastComma = line.LastIndexOf(',');
                        var assetPath = (lastComma == -1 ? line.Substring(firstComma + 1) : line.Substring(firstComma + 1, lastComma - firstComma - 1));
                        var assetId = ulong.Parse(line.Substring(0, firstComma), NumberStyles.HexNumber);

                        if (assetPath.Trim().Length > 0)
                        {
                            knownHashes.Add(assetId, assetPath);
                        }
                    }
                    catch { }

                    ++progress;
                    if (progress % 1000 == 0)
                    {
                        this.Invoke(() =>
                        {
                            OverlayHeaderLabel.Text = $"Loading '{selectedHashes}'...";
                            OverlayOperationLabel.Text = $"{progress}/{progressTotal} hashes";
                        });
                    }
                }
            }

            this.Invoke(() => OverlayOperationLabel.Text = "-");

            //-------------------------------------------------------------------------------------
            // Add paths to build the tree
            //-------------------------------------------------------------------------------------
            var root = new TreeNode("Root");
            root.Nodes.Clear();

            void AddPath(string dir, int assetIndex, bool makeFullPath = false)
            {
                if (dir == null) dir = "";
                if (makeFullPath)
                    _assets[assetIndex].FullPath = Path.Combine(dir, _assets[assetIndex].Name);

                if (dir == "") dir = "/";
                var parts = dir.Split('\\');
                var currentNode = root;

                foreach (var part in parts)
                {
                    var childNode = currentNode.Nodes[part] ?? currentNode.Nodes.Add(part, part);
                    currentNode = childNode;
                }

                if (!_assetsByPath.ContainsKey(dir))
                {
                    _assetsByPath[dir] = new();
                }

                _assetsByPath[dir].Add(assetIndex);
            }

            var usedHashes = new Dictionary<ulong, string>();
            usedHashes.Clear();

            for (var i = 0; i < _assets.Count; ++i)
            {
                var asset = _assets[i];
                var assetId = asset.Id;

                if (knownHashes.ContainsKey(assetId))
                {
                    var assetPath = Utils.Normalize(knownHashes[assetId]);
                    usedHashes[assetId] = assetPath;
                    asset.Name = Path.GetFileName(assetPath);
                    AddPath(Path.GetDirectoryName(assetPath), i, true);
                }

                ++progress;
                if (progress % 1000 == 0)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        OverlayHeaderLabel.Text = "Building tree...";
                        OverlayOperationLabel.Text = "-";

                        TreeView_Assets.Nodes.Clear();
                    });
                }
            }

            //-------------------------------------------------------------------------------------
            // Sort all nodes
            //-------------------------------------------------------------------------------------
            this.Invoke((MethodInvoker)delegate
            {
                if (root != null)
                {
                    SortNodesRecursively(root);
                }
            });

            void SortNodesRecursively(TreeNode node)
            {
                var sortedChildNodes = node.Nodes.Cast<TreeNode>()
                                               .OrderBy(childNode => childNode.Text)
                                               .ToList();

                node.Nodes.Clear();
                node.Nodes.AddRange(sortedChildNodes.ToArray());

                foreach (TreeNode child in node.Nodes)
                {
                    SortNodesRecursively(child);
                }
            }

            //-------------------------------------------------------------------------------------
            // Handle UNKNOWN and WEM assets
            //-------------------------------------------------------------------------------------
            var unknown = root.Nodes["[UNKNOWN]"];
            var wems = root.Nodes["[WEM]"];

            for (var i = 0; i < _assets.Count; ++i)
            {
                var asset = _assets[i];
                if (asset.Name != "") continue;

                var assetId = asset.Id;
                var isWem = ((assetId & 0xFFFFFFFF00000000) == 0xE000000000000000);

                if (isWem)
                {
                    var wemNumber = assetId & 0xFFFFFFFF;
                    asset.Name = $"{wemNumber}.wem";
                    AddPath($"[WEM]\\{asset.Archive}", i);
                }
                else
                {
                    asset.Name = $"{assetId:X016}";
                    AddPath($"[UNKNOWN]\\{asset.Archive}", i);
                }
            }

            //-------------------------------------------------------------------------------------
            // Populate TreeView
            //-------------------------------------------------------------------------------------
            this.Invoke(() =>
            {
                TreeView_Assets.Nodes.Clear();

                TreeView_Assets.Nodes.Add(root);

                TreeView_Assets.CollapseAll();

                foreach (TreeNode rootNode in TreeView_Assets.Nodes)
                {
                    if (rootNode.Text == "Root")
                    {
                        rootNode.Expand();
                    }
                }

                OverlayHeaderLabel.Text = "";
                OverlayOperationLabel.Text = "";
            });
        }

        //------------------------------------------------------------------------------------------
        // Identify TOC file
        //------------------------------------------------------------------------------------------
        private static TOCBase? LoadTOCFile(string tocPath)
        {
            // RCRA, MSM2
            TOC_I29 toc_i29 = new();
            if (toc_i29.Load(tocPath))
            {
                return toc_i29;
            }

            // MSMR, MSMM
            TOC_I20 toc_i20 = new();
            if (toc_i20.Load(tocPath))
            {
                return toc_i20;
            }

            return null;
        }

        #endregion

        #region Handle tree view

        //------------------------------------------------------------------------------------------
        //
        // Show assets from folder in Data Grid
        //
        //------------------------------------------------------------------------------------------
        private void TreeView_Assets_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var selectedNode = e.Node;

            // Check if the clicked node is the selected node
            if (TreeView_Assets.SelectedNode == null || TreeView_Assets.SelectedNode != selectedNode)
            {
                return;
            }

            string path = selectedNode.FullPath;
            string fullPath = path.Replace("Root\\", "");

            if (selectedNode != null)
            {
                dataGridView_Files.Rows.Clear();
                PopulateDataGridForNode(fullPath);
            }

            // Update status bar
            if (_assetsByPath.ContainsKey(fullPath))
            {
                string numAssets = "- " + _assetsByPath[fullPath].Count.ToString() + " assets";
                OverlayOperationLabel.Text = numAssets;
            }
            else
            {
                OverlayOperationLabel.Text = "";
            }

            OverlayHeaderLabel.Text = "Current directory: " + fullPath;
        }

        //------------------------------------------------------------------------------------------
        // Populate the grid view
        //------------------------------------------------------------------------------------------
        private void PopulateDataGridForNode(string folderPath)
        {
            dataGridView_Files.SuspendLayout();

            dataGridView_Files.Rows.Clear();

            if (_assetsByPath.ContainsKey(folderPath))
            {
                // Loop through the assets under the selected folder
                foreach (var assetName in _assetsByPath[folderPath])
                {
                    var asset = _assets[assetName];
                    var archive = asset.Archive;
                    var span = asset.Span.ToString();
                    var size = asset.Size;

                    dataGridView_Files.Rows.Add(asset.Name, asset.SizeFormatted, archive, span, asset.Id, asset.FullPath, asset.RefPath, asset.HasHeader);
                }
            }

            dataGridView_Files.ResumeLayout();
            dataGridView_Files.ClearSelection();
        }

        #endregion

        #region User Input
        //------------------------------------------------------------------------------------------
        // 
        // Handle user's input across the Main Window form
        //
        //------------------------------------------------------------------------------------------
        private void ToolStrip_GeneralSettings_MouseEnter(object sender, EventArgs e)
        {
            int replacedAssetsCount = _replacedAssets.Count;
            int addedAssetsCount = _addedAssets.Count;

            // Assets
            menuItem_ReplacedAssets.Text = $"{replacedAssetsCount} replaced, {addedAssetsCount} new";

            // WWProject
            bool hasAssets = replacedAssetsCount > 0 || addedAssetsCount > 0;

            menuItem_ClearAll.Enabled = hasAssets;
            menuItem_WWPROJ_Handle.Text = hasAssets ? "Save project as..." : "Open project...";

            // Stages
            string stagesPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "stages");
            bool stagesExists = Directory.Exists(stagesPath);

            menuItem_AddFromStage.Enabled = stagesExists;

            // TOC loaded
            bool isTocLoaded = _toc != null;

            ToolStrip_Search.Enabled = isTocLoaded;
            ToolStrip_JumpTo.Enabled = isTocLoaded;

            // Experimental features
            bool isExperimentalEnabled = settings._experimentalFeatures;

            //menuItem_WWPROJ_Handle.Visible = isExperimentalEnabled;
            //menuItem_WWPROJ_Handle.Enabled = isExperimentalEnabled;

            // Temporarily disabled until a better solution for WWPROJ is found
            menuItem_WWPROJ_Handle.Visible = false;
            menuItem_WWPROJ_Handle.Enabled = false;

            toolStripMenuItem1.Visible = isExperimentalEnabled;
        }

        // Load TOC menu item, Ctrl + O
        //------------------------------------------------------------------------------------------
        private void ToolStrip_LoadToc_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All files (*.*)|*.*";
                openFileDialog.Title = "Open TOC File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    StartLoadTOCThread(filePath);
                }
            }
        }

        // Additional menu item buttons
        //------------------------------------------------------------------------------------------
        private void ToolStrip_Settings_Click(object sender, EventArgs e)
        { SetEnvironment.Settings(); }
        private void ToolStrip_Search_Click(object sender, EventArgs e)
        { SetEnvironment.Search(); }
        private void ToolStrip_JumpTo_Click(object sender, EventArgs e)
        { SetEnvironment.JumpTo(); }
        private void ToolStrip_Home_Click(object sender, EventArgs e)
        { SetEnvironment.Home(); }
        private void ToolStrip_Information_Click(object sender, EventArgs e)
        { SetEnvironment.Information(); }

        // Extract
        private void ToolStrip_ExtractToStage_Click(object sender, EventArgs e)
        { ExtractionMethods.ExtractToStage(); }
        private void ToolStrip_ExtractAsAscii_Click(object sender, EventArgs e)
        { ExtractionMethods.ExtractAsASCII(); }
        private void ToolStrip_ExtractAsDDS_Click(object sender, EventArgs e)
        { ExtractionMethods.ExtractAsDDS(); }

        // Copy
        private void ToolStrip_CopyPath_Click(object sender, EventArgs e)
        { ToolUtils.copyToClipboard(GetCurrentAssets.Paths()); }
        private void ToolStrip_CopyHash_Click(object sender, EventArgs e)
        { ToolUtils.copyToClipboard(GetCurrentAssets.Hashes()); }

        // Replace
        private void ToolStrip_ReplaceAsset_Click(object sender, EventArgs e)
        {
            var selected = GetCurrentAssets.IDs().Count();
            if (selected != 1) return;

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select file to replace asset with...";
            dialog.Multiselect = false;
            dialog.RestoreDirectory = true;
            dialog.Filter = "All files(*.*) | *.*";

            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string path = dialog.FileName;

            Asset asset = GetCurrentAssets.Assets()[0];

            var existingAsset = _replacedAssets.FirstOrDefault(a => a.Key.Id == asset.Id && a.Key.Span == asset.Span);

            if (existingAsset.Key != null)
            {
                // Update the existing asset
                _replacedAssets[existingAsset.Key] = path;
            }
            else
            {
                // Add the new asset
                _replacedAssets.Set(asset, path);
            }
        }

        // Extract all selected asset rows
        //--------------------------------------------------------------------------------------
        private void ToolStrip_ExtractSelected_Click(object sender, EventArgs e)
        {
            var dataGridView = GetCurrentAssets.DataGridView();
            var selected = dataGridView.SelectedRows.Count;

            if (selected == 1)
            {
                var asset = GetCurrentAssets.Assets()[0];
                ExtractOneAssetDialog(asset.Name, asset.Span, asset.Id);
            }
            else if (selected > 1)
            {
                ExtractMultipleAssetsDialog(GetCurrentAssets.Names(), GetCurrentAssets.Spans(), GetCurrentAssets.IDs());
            }
        }

        // Menu Item
        //--------------------------------------------------------------------------------------
        private void menuItem_PackAsStage_Click(object sender, EventArgs e)
        {
            var window = new PackStageWindow(_replacedAssets, _addedAssets, _toc);
            window.ShowDialog();
        }
        private void menuItem_ClearAll_Click(object sender, EventArgs e)
        {
            _replacedAssets.Clear();
            _addedAssets.Clear();
        }
        private void menuItem_AddFromStage_Click(object sender, EventArgs e)
        {
            var window = new StageSelectorWindow();
            window.OnlyExisting = true;
            window.ShowDialog();

            if (window.Stage == null) return;

            var cwd = Directory.GetCurrentDirectory();
            var path = Path.Combine(cwd, "stages");
            var stagePath = Path.Combine(path, window.Stage);

            for (var spanIndex = 0; spanIndex < 256; ++spanIndex)
            {
                var spanDir = Path.Combine(stagePath, $"{spanIndex}");
                if (!Directory.Exists(spanDir)) continue;

                var files = Directory.GetFiles(spanDir, "*", SearchOption.AllDirectories);
                foreach (var file in files)
                {
                    var relpath = Path.GetRelativePath(spanDir, file);
                    string fullpath = null;
                    ulong assetId;
                    if (Regex.IsMatch(relpath, "^[0-9A-Fa-f]{16}$"))
                    {
                        assetId = ulong.Parse(relpath, NumberStyles.HexNumber);
                    }
                    else
                    {
                        assetId = CRC64.Hash(relpath);
                        fullpath = relpath;
                    }

                    var assetIndex = _toc.FindAssetIndex((byte)spanIndex, assetId);
                    if (assetIndex != -1)
                    {
                        var asset = _assets[assetIndex];
                        _replacedAssets.Set(asset, file);
                        continue;
                    }

                    // record to _addedAssets, updating the record if it's already present
                    Asset newAsset = null;

                    foreach (var addedAsset in _addedAssets.Keys)
                    {
                        if (addedAsset.Span == spanIndex && addedAsset.Id == assetId)
                        {
                            newAsset = addedAsset;
                            break;
                        }
                    }

                    var adding = (newAsset == null);
                    if (adding) newAsset = new Asset();

                    newAsset.Span = (byte)spanIndex;
                    newAsset.Id = assetId;
                    newAsset.Size = 0; // TODO?
                    newAsset.HasHeader = true;
                    newAsset.Name = Path.GetFileName(relpath);
                    newAsset.Archive = "-";
                    newAsset.FullPath = fullpath;

                    if (adding)
                    {
                        _addedAssets.Add(newAsset, file);
                    }
                    else
                    {
                        _addedAssets.Set(newAsset, file);
                    }
                }
            }
        }
        private void SaveAsWWPROJ()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "WWProj Files (*.wwproj)|*.wwproj",
                DefaultExt = ".wwproj",
                AddExtension = true
            };

            // Show the dialog and check if the user selected a file
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                WWProj.Write(filePath);
            }
        }
        private void AddFromWWPROJ()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "WWProj Files (*.wwproj)|*.wwproj",
                DefaultExt = ".wwproj",
                AddExtension = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                WWProj.Read(filePath);
            }
        }
        private void menuItem_ModWWPROJ_Click(object sender, EventArgs e)
        {
            if (_replacedAssets.Count > 0 || _addedAssets.Count > 0)
            {
                SaveAsWWPROJ();
            }
            else
            {
                AddFromWWPROJ();
            }
        }
        private void discordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://discord.gg/Dg5fdVhJUs",
                UseShellExecute = true
            });
        }


        // Handle right click and commands for context menu
        //------------------------------------------------------------------------------------------
        public void OpenContextMenu(object sender, MouseEventArgs e)
        {
            var dataGridView = GetCurrentAssets.DataGridView();

            int selectedRows = dataGridView.SelectedRows.Count;
            var hitTestInfo = dataGridView.HitTest(e.X, e.Y);

            ToolStrip_ExtractAsAscii.Visible = false;
            ToolStrip_ExtractAsDDS.Visible = false;

            if (e.Button == MouseButtons.Right && hitTestInfo.RowIndex >= 0 && hitTestInfo.ColumnIndex >= 0)
            {
                if (selectedRows == 0)
                {
                    dataGridView.ClearSelection();
                    dataGridView.Rows[hitTestInfo.RowIndex].Selected = true;
                    selectedRows = 1;
                }

                if (selectedRows != 1)
                {
                    ToolStrip_ReplaceAsset.Visible = false;
                }
                else
                {
                    ToolStrip_ReplaceAsset.Visible = true;
                }

                dataGridView.CurrentCell = dataGridView[hitTestInfo.ColumnIndex, hitTestInfo.RowIndex];

                string assetType = Path.GetExtension(dataGridView.CurrentCell.Value?.ToString() ?? string.Empty);

                ToolStrip_ExtractAsAscii.Visible = assetType == ".model";
                ToolStrip_ExtractAsDDS.Visible = assetType == ".texture";

                ToolStrip_AssetsSelected.Text = selectedRows > 1
                    ? $"{selectedRows} assets selected"
                    : $"{selectedRows} asset selected";

                ToolStrip_CopyPath.Text = selectedRows > 1 ? "Copy paths" : "Copy path";
                ToolStrip_CopyHash.Text = selectedRows > 1 ? "Copy hashes" : "Copy hash";

                contextMenuStrip1.Show(dataGridView, new Point(e.X, e.Y));
            }
        }
        public void CommandsDataGrid(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.R)
            {
                ToolStrip_ReplaceAsset_Click(sender, e);
            }

            if (e.Control && e.KeyCode == Keys.E)
            {
                ToolStrip_ExtractSelected_Click(sender, e);
            }
        }

        #region Open additional tools

        // Open Tools
        //------------------------------------------------------------------------------------------
        private void ToolStrip_HashTool_Click(object sender, EventArgs e)
        { SetEnvironment.HashTool(); }
        private void ToolStrip_SpandexTool_Click(object sender, EventArgs e)
        { SetEnvironment.Spandex(); }
        private void ToolStrip_SilkTextureTool_Click(object sender, EventArgs e)
        { SetEnvironment.SilkTexture(); }
        private void ToolStrip_ModdingTool_Click(object sender, EventArgs e)
        { SetEnvironment.ModdingTool(); }

        // Open with file
        private void ToolStrip_OpenAsset_Click(object sender, EventArgs e)
        {
            using (var f = new OpenFileDialog())
            {
                f.Filter = "Supported Assets|*.texture;*.material;*.config;*.json";
                f.Title = "Open asset...";

                if (f.ShowDialog() == DialogResult.OK)
                {
                    string filePath = f.FileName;
                    ReadFile(filePath);
                }
                else
                { }
            }
        }

        #endregion

        #endregion

        #region Extraction dialogs
        // Extract a single asset dialog
        //------------------------------------------------------------------------------------------
        private void ExtractOneAssetDialog(string assetpath, byte span, ulong assetID)
        {
            // Build the dialog
            SaveFileDialog dialog = new SaveFileDialog
            {
                Title = "Extract asset...",
                RestoreDirectory = true,
                Filter = "All files (*.*)|*.*",
                FileName = Path.GetFileName(assetpath)  // Set the initial file name based on assetpath
            };

            // If OK, continue
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string selectedPath = dialog.FileName;

                ExtractionMethods.ExtractAsset(assetID, span, selectedPath, _toc);
            }
        }

        // Extract multiple assets dialog
        //------------------------------------------------------------------------------------------
        private void ExtractMultipleAssetsDialog(string[] assets, byte[] spans, ulong[] assetIDs)
        {
            // Build folder dialog
            FolderBrowserDialog dialog = new FolderBrowserDialog
            {
                ShowNewFolderButton = true
            };

            Activate();

            // If OK, continue
            if (dialog.ShowDialog() != DialogResult.OK) return;

            var path = dialog.SelectedPath;

            if (!Directory.Exists(path)) return;

            // Extract assets with corresponding span
            for (int i = 0; i < assets.Length; i++)
            {
                string assetPath = assets[i];
                ulong assetID = assetIDs[i];
                byte span = spans[i];
                string outputPath = Path.Combine(path, Path.GetFileName(assetPath));

                ExtractionMethods.ExtractAsset(assetID, span, outputPath, _toc);
            }
        }

        #endregion

        #region Misc
        public void JumpTo(string path)
        {
            string folderToOpen = null;
            bool openAssetById = false;
            byte assetSpanToOpen = 0;
            ulong assetIdToOpen = 0;
            bool openAssetByName = false;
            string assetNameToOpen = null;

            if (Regex.IsMatch(path, "^[0-9]+/[0-9a-fA-F]{16}$"))
            { // ref
                var i = path.IndexOf('/');
                var span = path.Substring(0, i);
                var assetId = path.Substring(++i);

                try
                {
                    var spanIndex = byte.Parse(span);
                    var id = ulong.Parse(assetId, NumberStyles.HexNumber);
                    var assetIndex = _toc.FindAssetIndex(spanIndex, id);
                    if (assetIndex != -1)
                    {
                        var asset = _assets[assetIndex];

                        folderToOpen = Path.GetDirectoryName(asset.FullPath);
                        openAssetById = true;
                        assetSpanToOpen = spanIndex;
                        assetIdToOpen = id;

                        if (folderToOpen == null)
                        {
                            foreach (var dirname in _assetsByPath.Keys)
                            {
                                if (_assetsByPath[dirname].Contains(assetIndex))
                                {
                                    folderToOpen = dirname;
                                    break;
                                }
                            }
                        }
                    }
                }
                catch { }
            }
            else
            {
                if (path != "/") path = path.Replace('/', '\\');

                folderToOpen = path;
                openAssetByName = true;
                assetNameToOpen = Path.GetFileName(path);
            }

            if (folderToOpen != null)
            {
                PopulateDataGridForNode(Path.GetDirectoryName(folderToOpen));

                #region Find tree node
                string targetPath;

                if (openAssetByName)
                {
                    targetPath = "Root\\" + Path.GetDirectoryName(folderToOpen)?.Replace(Path.DirectorySeparatorChar, '\\');
                }
                else
                {
                    targetPath = "Root\\" + folderToOpen.Replace(Path.DirectorySeparatorChar, '\\');
                }

                TreeNode FindNodeByPath(TreeNodeCollection nodes, string path)
                {
                    foreach (TreeNode node in nodes)
                    {
                        if (node.FullPath.Equals(path, StringComparison.OrdinalIgnoreCase))
                        { return node; }

                        TreeNode foundNode = FindNodeByPath(node.Nodes, path);
                        if (foundNode != null)
                        { return foundNode; }
                    }
                    return null;
                }

                TreeNode nodeToSelect = FindNodeByPath(TreeView_Assets.Nodes, targetPath);

                if (nodeToSelect != null)
                {
                    nodeToSelect.EnsureVisible();
                    TreeView_Assets.SelectedNode = nodeToSelect;
                    TreeView_Assets.Focus();
                }
                #endregion

                if (openAssetById)
                {
                    foreach (DataGridViewRow assetItem in GetCurrentAssets.DataGridView().Rows)
                    {
                        byte assetSpan = assetItem.Cells[3]?.Value is byte span ? span : default;
                        ulong assetId = assetItem.Cells[4]?.Value is ulong id ? id : default;

                        if (assetSpan == assetSpanToOpen && assetId == assetIdToOpen)
                        {
                            assetItem.Selected = true;
                            GetCurrentAssets.DataGridView().FirstDisplayedScrollingRowIndex = assetItem.Index;
                            break;
                        }
                    }
                }
                else if (openAssetByName)
                {
                    foreach (DataGridViewRow assetItem in GetCurrentAssets.DataGridView().Rows)
                    {
                        string assetName = assetItem.Cells[0]?.Value.ToString();

                        if (assetName == assetNameToOpen)
                        {
                            assetItem.Selected = true;
                            GetCurrentAssets.DataGridView().FirstDisplayedScrollingRowIndex = assetItem.Index;
                            break;
                        }
                    }
                }
            }
        }

        bool skipHome = false;
        private void ReadFile(string filePath)
        {
            string type = Path.GetExtension(filePath);

            switch (type)
            {
                case ".wwproj":
                    WWProj.Read(filePath);
                    break;

                case ".texture":
                    SetEnvironment.SilkTexture();
                    SetEnvironment.silkTextureForm?.Open(filePath);
                    skipHome = true;
                    break;

                case ".material":
                    SetEnvironment.Spandex();
                    SetEnvironment.spandexForm?.Open(filePath);
                    skipHome = true;
                    break;

                case ".config":
                case ".json":
                    SetEnvironment.ConfigWeaver();
                    SetEnvironment.configWeaver?.Open(filePath);
                    skipHome = true;
                    break;

                default: break;
            }
        }

        #endregion

        // Handle form closing and loading
        //------------------------------------------------------------------------------------------
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            LoadPreferences();

            if (!skipHome)
            {
                SetEnvironment.Home();
            }
        }

        private void ToolStrip_ModelToolGUI_Click(object sender, EventArgs e)
        {
            SetEnvironment.ModelToolGUI();
        }

        private void ToolStrip_ConfigWeaver_Click(object sender, EventArgs e)
        {
            SetEnvironment.ConfigWeaver();
        }

        private void ToolStrip_SpideyAtmos_Click(object sender, EventArgs e)
        {
            SetEnvironment.SpideyAtmos();
        }
    }
}
