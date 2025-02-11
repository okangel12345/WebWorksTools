using DAT1;
using Newtonsoft.Json.Linq;
using Spiderman;
using WebWorks;
using WebWorks.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using MessageBox = System.Windows.Forms.MessageBox;

namespace WebWorks.Windows
{
    public partial class PackStageWindow : Form
    {
        //------------------------------------------------------------------------------------------
        private bool _initializing = true;
        private Dictionary<Asset, string> _mainWindowReplacedAssets;
        private Dictionary<Asset, string> _mainWindowAddedAssets;

        private string _modName;
        private string _author;
        private string _gameId;

        private List<Game> _games = new();
        private BindingList<AssetReplace> _assets = new BindingList<AssetReplace>();

        //------------------------------------------------------------------------------------------
        class Game
        {
            public string Name { get; set; }
            public string Id;
        }

        class AssetReplace
        {
            public Asset Asset;
            public bool IsNew = false;

            public string OriginalAssetName { get => (IsNew ? $"new ({Asset.RefPath})" : Asset.Name); }
            public string OriginalAssetNameToolTip { get => (Asset.FullPath == null ? "" : $"Path: {Asset.FullPath}\n") + $"ID: {Asset.Id:X016}\nSpan: {Asset.Span}\nArchive: {Asset.Archive}"; }

            public string ReplacingFileName { get; set; }
            public string ReplacingFileNameToolTip { get; set; }
        }

        //------------------------------------------------------------------------------------------
        public PackStageWindow(Dictionary<Asset, string> replacedAssets, Dictionary<Asset, string> addedAssets, TOCBase toc)
        {
            InitializeComponent();
            ToolUtils.ApplyStyle(this, Handle);

            _initializing = false;

            SettingsWindow sets = new SettingsWindow();
            AppSettings settings = sets.LoadSettings();

            string defaultAuthorName = settings._authorName;
            int preferredGame = settings._preferredGameIndex;

            if (defaultAuthorName != null)
            {
                _author = defaultAuthorName;
                AuthorTextBox.Text = defaultAuthorName;
            }


            MakeGamesSelector(toc);

            if (preferredGame > 0)
            {
                GameComboBox.SelectedIndex = preferredGame - 1;
            }

            _mainWindowReplacedAssets = replacedAssets;
            _mainWindowAddedAssets = addedAssets;
            UpdateAssetsList();
        }

        //------------------------------------------------------------------------------------------
        private void MakeGamesSelector(TOCBase toc)
        {
            _games.Clear();
            _games.Add(new Game() { Name = "Marvel's Spider-Man Remastered", Id = "MSMR" });
            _games.Add(new Game() { Name = "Marvel's Spider-Man: Miles Morales", Id = "MM" });
            _games.Add(new Game() { Name = "Ratchet & Clank: Rift Apart", Id = "RCRA" });
            _games.Add(new Game() { Name = "Marvel's Spider-Man 2", Id = "MSM2" });
            _games.Add(new Game() { Name = "i30", Id = "i30" });
            _games.Add(new Game() { Name = "i33", Id = "i33" });

            GameComboBox.DataSource = _games;
            GameComboBox.DisplayMember = "Name";

            var selected = _games[0];

            if (toc is TOC_I29)
            {
                selected = _games[3];
            }

            _gameId = selected.Id;
            GameComboBox.SelectedItem = selected;
        }
        //------------------------------------------------------------------------------------------
        private void UpdateAssetsList()
        {
            _assets.Clear();

            foreach (var asset in _mainWindowReplacedAssets.Keys)
            {
                var path = _mainWindowReplacedAssets[asset];
                _assets.Add(new AssetReplace
                {
                    Asset = asset,
                    ReplacingFileName = Path.GetFileName(path),
                    ReplacingFileNameToolTip = path
                });
            }

            foreach (var asset in _mainWindowAddedAssets.Keys)
            {
                var path = _mainWindowAddedAssets[asset];
                _assets.Add(new AssetReplace
                {
                    Asset = asset,
                    IsNew = true,
                    ReplacingFileName = Path.GetFileName(path),
                    ReplacingFileNameToolTip = path
                });
            }

            AssetsList.DataSource = _assets;
        }

        private void RefreshButton()
        {
            var isEmpty = (string s) => { return (s == null || s == ""); };

            SaveStageButton.Visible = (!isEmpty(_modName) && !isEmpty(_author));
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_initializing) return;
            _modName = NameTextBox.Text;
            RefreshButton();
        }

        private void AuthorTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_initializing) return;
            _author = AuthorTextBox.Text;
            RefreshButton();
        }

        private void DescriptionTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_initializing) return;
            //_description = DescriptionTextBox.Text;

            //DescriptionTextBox.ForeColor = Color.FromKnownColor(KnownColor.Control);

            RefreshButton();
        }

        private void GameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_initializing) return;
            _gameId = ((Game)GameComboBox.SelectedItem).Id;
        }

        private void SaveStageButton_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Title = "Save .stage...";
            dialog.Filter = "Stage (*.stage)|*.stage|All files (*.*)|*.*";
            dialog.DefaultExt = "*.stage";
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var stageFileName = dialog.FileName;
            try
            {
                using var f = new FileStream(stageFileName, FileMode.Create, FileAccess.Write, FileShare.None);
                using var zip = new ZipArchive(f, ZipArchiveMode.Create);

                void WriteAssets(Dictionary<Asset, string> assets)
                {
                    foreach (var asset in assets.Keys)
                    {
                        var path = assets[asset];
                        var bytes = File.ReadAllBytes(path);

                        var assetPath = asset.RefPath;
                        if (asset.FullPath != null)
                            assetPath = $"{asset.Span}/" + DAT1.Utils.Normalize(asset.FullPath);

                        var entry = zip.CreateEntry(assetPath);
                        using var ef = entry.Open();
                        ef.Write(bytes, 0, bytes.Length);
                    }
                }

                WriteAssets(_mainWindowReplacedAssets);
                WriteAssets(_mainWindowAddedAssets);

                {
                    JObject j = new()
                    {
                        ["game"] = _gameId,
                        ["name"] = _modName,
                        ["author"] = _author,
                        ["format_version"] = 2
                    };

                    var text = j.ToString();
                    var data = Encoding.UTF8.GetBytes(text);

                    var entry = zip.CreateEntry("info.json");
                    using var ef = entry.Open();
                    ef.Write(data, 0, data.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: failed to write '{stageFileName}'!", "Error", MessageBoxButtons.OK);
                MessageBox.Show(ex.ToString());
                return;
            }

            Close();

        }

        private void AssetsList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                foreach (DataGridViewRow row in AssetsList.SelectedRows)
                {
                    // Assuming the row is bound to an object of type AssetReplace
                    var assetReplace = row.DataBoundItem as AssetReplace;

                    if (assetReplace != null)
                    {
                        if (assetReplace.IsNew)
                        {
                            _mainWindowAddedAssets.Remove(assetReplace.Asset);
                        }
                        else
                        {
                            _mainWindowReplacedAssets.Remove(assetReplace.Asset);
                        }
                    }
                }
                UpdateAssetsList();
            }
        }

        private void ClearAllButton_Click(object sender, EventArgs e)
        {
            var f = MessageBox.Show("This will clear all replaced and added assets, are you sure you want to continue?",
                                    "Warning", MessageBoxButtons.YesNo);

            if (f == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in AssetsList.Rows)
                {
                    var assetReplace = row.DataBoundItem as AssetReplace;

                    if (assetReplace != null)
                    {
                        if (assetReplace.IsNew)
                        {
                            _mainWindowAddedAssets.Remove(assetReplace.Asset);
                        }
                        else
                        {
                            _mainWindowReplacedAssets.Remove(assetReplace.Asset);
                        }
                    }
                }
                UpdateAssetsList();
            }
        }

        private void PackStageWindow_KeyDown(object sender, KeyEventArgs e)
        {
            ToolUtils.CloseWithKeyboardShortcut(this, sender, e);
        }
    }
}
