namespace WebWorks
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            statusStrip1 = new StatusStrip();
            OverlayHeaderLabel = new ToolStripStatusLabel();
            OverlayOperationLabel = new ToolStripStatusLabel();
            TreeView_Assets = new TreeView();
            dataGridView_Files = new DataGridView();
            FileName = new DataGridViewTextBoxColumn();
            Size = new DataGridViewTextBoxColumn();
            Archive = new DataGridViewTextBoxColumn();
            Span = new DataGridViewTextBoxColumn();
            assetID = new DataGridViewTextBoxColumn();
            assetPath = new DataGridViewTextBoxColumn();
            assetRef = new DataGridViewTextBoxColumn();
            HasHeader = new DataGridViewCheckBoxColumn();
            splitContainer1 = new SplitContainer();
            panel_Main = new Panel();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            ToolStrip_LoadToc = new ToolStripMenuItem();
            loadRecentToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripMenuItem();
            toolStripMenuItem5 = new ToolStripMenuItem();
            toolStripMenuItem6 = new ToolStripMenuItem();
            hashesToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem9 = new ToolStripMenuItem();
            menuItem_WWPROJ_Handle = new ToolStripMenuItem();
            ToolStrip_OpenAsset = new ToolStripMenuItem();
            toolStripMenuItem10 = new ToolStripMenuItem();
            ToolStrip_Settings = new ToolStripMenuItem();
            searchToolStripMenuItem = new ToolStripMenuItem();
            ToolStrip_Search = new ToolStripMenuItem();
            ToolStrip_JumpTo = new ToolStripMenuItem();
            modToolStripMenuItem = new ToolStripMenuItem();
            menuItem_ReplacedAssets = new ToolStripMenuItem();
            menuItem_ClearAll = new ToolStripMenuItem();
            toolStripMenuItem13 = new ToolStripMenuItem();
            menuItem_AddFromStage = new ToolStripMenuItem();
            menuItem_PackAsStage = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            ToolStrip_Home = new ToolStripMenuItem();
            ToolStrip_HashTool = new ToolStripMenuItem();
            toolStripMenuItem11 = new ToolStripMenuItem();
            ToolStrip_ModdingTool = new ToolStripMenuItem();
            ToolStrip_SpandexTool = new ToolStripMenuItem();
            ToolStrip_SilkTextureTool = new ToolStripMenuItem();
            ToolStrip_ConfigWeaver = new ToolStripMenuItem();
            ToolStrip_ModelToolGUI = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            ToolStrip_QuickGameLaunch = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            ToolStrip_Information = new ToolStripMenuItem();
            discordToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip1 = new ContextMenuStrip(components);
            ToolStrip_AssetsSelected = new ToolStripMenuItem();
            toolStripMenuItem7 = new ToolStripMenuItem();
            ToolStrip_ExtractSelected = new ToolStripMenuItem();
            ToolStrip_ExtractAsAscii = new ToolStripMenuItem();
            ToolStrip_ExtractAsDDS = new ToolStripMenuItem();
            ToolStrip_ExtractToStage = new ToolStripMenuItem();
            ToolStrip_ReplaceAsset = new ToolStripMenuItem();
            toolStripMenuItem8 = new ToolStripMenuItem();
            ToolStrip_CopyPath = new ToolStripMenuItem();
            ToolStrip_CopyHash = new ToolStripMenuItem();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_Files).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            menuStrip1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = Color.FromArgb(12, 12, 12);
            statusStrip1.Items.AddRange(new ToolStripItem[] { OverlayHeaderLabel, OverlayOperationLabel });
            statusStrip1.Location = new Point(0, 538);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(939, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // OverlayHeaderLabel
            // 
            OverlayHeaderLabel.Name = "OverlayHeaderLabel";
            OverlayHeaderLabel.Size = new Size(118, 17);
            OverlayHeaderLabel.Text = "toolStripStatusLabel1";
            // 
            // OverlayOperationLabel
            // 
            OverlayOperationLabel.Name = "OverlayOperationLabel";
            OverlayOperationLabel.Size = new Size(118, 17);
            OverlayOperationLabel.Text = "toolStripStatusLabel1";
            // 
            // TreeView_Assets
            // 
            TreeView_Assets.BackColor = Color.FromArgb(22, 22, 22);
            TreeView_Assets.BorderStyle = BorderStyle.FixedSingle;
            TreeView_Assets.Dock = DockStyle.Fill;
            TreeView_Assets.ForeColor = SystemColors.Control;
            TreeView_Assets.Location = new Point(0, 0);
            TreeView_Assets.Name = "TreeView_Assets";
            TreeView_Assets.Size = new Size(311, 508);
            TreeView_Assets.TabIndex = 1;
            TreeView_Assets.AfterSelect += TreeView_Assets_AfterSelect;
            // 
            // dataGridView_Files
            // 
            dataGridView_Files.AllowUserToAddRows = false;
            dataGridView_Files.AllowUserToDeleteRows = false;
            dataGridView_Files.AllowUserToResizeRows = false;
            dataGridView_Files.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_Files.Columns.AddRange(new DataGridViewColumn[] { FileName, Size, Archive, Span, assetID, assetPath, assetRef, HasHeader });
            dataGridView_Files.Dock = DockStyle.Fill;
            dataGridView_Files.Location = new Point(0, 0);
            dataGridView_Files.Name = "dataGridView_Files";
            dataGridView_Files.RowHeadersVisible = false;
            dataGridView_Files.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_Files.Size = new Size(624, 508);
            dataGridView_Files.TabIndex = 2;
            dataGridView_Files.KeyDown += CommandsDataGrid;
            dataGridView_Files.MouseClick += OpenContextMenu;
            // 
            // FileName
            // 
            FileName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            FileName.FillWeight = 45F;
            FileName.HeaderText = "Assets";
            FileName.MinimumWidth = 50;
            FileName.Name = "FileName";
            FileName.ReadOnly = true;
            // 
            // Size
            // 
            Size.FillWeight = 25F;
            Size.HeaderText = "Size";
            Size.Name = "Size";
            Size.ReadOnly = true;
            Size.Width = 75;
            // 
            // Archive
            // 
            Archive.FillWeight = 19F;
            Archive.HeaderText = "Archive";
            Archive.Name = "Archive";
            Archive.ReadOnly = true;
            // 
            // Span
            // 
            Span.FillWeight = 6F;
            Span.HeaderText = "Span";
            Span.Name = "Span";
            Span.ReadOnly = true;
            Span.Width = 75;
            // 
            // assetID
            // 
            assetID.HeaderText = "assetID";
            assetID.Name = "assetID";
            assetID.Visible = false;
            assetID.Width = 5;
            // 
            // assetPath
            // 
            assetPath.HeaderText = "assetPath";
            assetPath.Name = "assetPath";
            assetPath.Visible = false;
            // 
            // assetRef
            // 
            assetRef.HeaderText = "assetRef";
            assetRef.Name = "assetRef";
            assetRef.Visible = false;
            // 
            // HasHeader
            // 
            HasHeader.HeaderText = "HasHeader";
            HasHeader.Name = "HasHeader";
            HasHeader.Visible = false;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(0, 27);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(TreeView_Assets);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dataGridView_Files);
            splitContainer1.Size = new Size(939, 508);
            splitContainer1.SplitterDistance = 311;
            splitContainer1.TabIndex = 3;
            // 
            // panel_Main
            // 
            panel_Main.BackColor = Color.FromArgb(12, 12, 12);
            panel_Main.Location = new Point(891, 372);
            panel_Main.Name = "panel_Main";
            panel_Main.Size = new Size(21, 335);
            panel_Main.TabIndex = 5;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, searchToolStripMenuItem, modToolStripMenuItem, toolsToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(939, 24);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ToolStrip_LoadToc, loadRecentToolStripMenuItem, hashesToolStripMenuItem, toolStripMenuItem9, menuItem_WWPROJ_Handle, ToolStrip_OpenAsset, toolStripMenuItem10, ToolStrip_Settings });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            fileToolStripMenuItem.Click += ToolStrip_GeneralSettings_MouseEnter;
            fileToolStripMenuItem.MouseEnter += ToolStrip_GeneralSettings_MouseEnter;
            // 
            // ToolStrip_LoadToc
            // 
            ToolStrip_LoadToc.Image = Windows.MiscIcons.TocFile;
            ToolStrip_LoadToc.Name = "ToolStrip_LoadToc";
            ToolStrip_LoadToc.ShortcutKeyDisplayString = "";
            ToolStrip_LoadToc.ShortcutKeys = Keys.Control | Keys.L;
            ToolStrip_LoadToc.Size = new Size(212, 22);
            ToolStrip_LoadToc.Text = "Load TOC...";
            ToolStrip_LoadToc.Click += ToolStrip_LoadToc_Click;
            // 
            // loadRecentToolStripMenuItem
            // 
            loadRecentToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem2, toolStripMenuItem3, toolStripMenuItem4, toolStripMenuItem5, toolStripMenuItem6 });
            loadRecentToolStripMenuItem.Name = "loadRecentToolStripMenuItem";
            loadRecentToolStripMenuItem.Size = new Size(212, 22);
            loadRecentToolStripMenuItem.Text = "Load Recent...";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.ShortcutKeys = Keys.Control | Keys.Shift | Keys.T;
            toolStripMenuItem2.Size = new Size(152, 22);
            toolStripMenuItem2.Text = "1";
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(152, 22);
            toolStripMenuItem3.Text = "2";
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(152, 22);
            toolStripMenuItem4.Text = "3";
            // 
            // toolStripMenuItem5
            // 
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            toolStripMenuItem5.Size = new Size(152, 22);
            toolStripMenuItem5.Text = "4";
            // 
            // toolStripMenuItem6
            // 
            toolStripMenuItem6.Name = "toolStripMenuItem6";
            toolStripMenuItem6.Size = new Size(152, 22);
            toolStripMenuItem6.Text = "5";
            // 
            // hashesToolStripMenuItem
            // 
            hashesToolStripMenuItem.Image = Windows.MiscIcons.HashFile;
            hashesToolStripMenuItem.Name = "hashesToolStripMenuItem";
            hashesToolStripMenuItem.Size = new Size(212, 22);
            hashesToolStripMenuItem.Text = "Hashes...";
            // 
            // toolStripMenuItem9
            // 
            toolStripMenuItem9.Enabled = false;
            toolStripMenuItem9.Name = "toolStripMenuItem9";
            toolStripMenuItem9.Size = new Size(212, 22);
            toolStripMenuItem9.Text = "───────────────────────";
            // 
            // menuItem_WWPROJ_Handle
            // 
            menuItem_WWPROJ_Handle.Image = Windows.MiscIcons.AddFrom;
            menuItem_WWPROJ_Handle.Name = "menuItem_WWPROJ_Handle";
            menuItem_WWPROJ_Handle.Size = new Size(212, 22);
            menuItem_WWPROJ_Handle.Text = "Open project...";
            menuItem_WWPROJ_Handle.Click += menuItem_ModWWPROJ_Click;
            // 
            // ToolStrip_OpenAsset
            // 
            ToolStrip_OpenAsset.Name = "ToolStrip_OpenAsset";
            ToolStrip_OpenAsset.ShortcutKeys = Keys.Control | Keys.O;
            ToolStrip_OpenAsset.Size = new Size(212, 22);
            ToolStrip_OpenAsset.Text = "Open asset...";
            ToolStrip_OpenAsset.Click += ToolStrip_OpenAsset_Click;
            // 
            // toolStripMenuItem10
            // 
            toolStripMenuItem10.Enabled = false;
            toolStripMenuItem10.Name = "toolStripMenuItem10";
            toolStripMenuItem10.Size = new Size(212, 22);
            toolStripMenuItem10.Text = "───────────────────────";
            // 
            // ToolStrip_Settings
            // 
            ToolStrip_Settings.Image = Windows.MiscIcons.Settings;
            ToolStrip_Settings.Name = "ToolStrip_Settings";
            ToolStrip_Settings.ShortcutKeys = Keys.Control | Keys.P;
            ToolStrip_Settings.Size = new Size(212, 22);
            ToolStrip_Settings.Text = "Settings";
            ToolStrip_Settings.Click += ToolStrip_Settings_Click;
            // 
            // searchToolStripMenuItem
            // 
            searchToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ToolStrip_Search, ToolStrip_JumpTo });
            searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            searchToolStripMenuItem.Size = new Size(54, 20);
            searchToolStripMenuItem.Text = "Search";
            searchToolStripMenuItem.Click += ToolStrip_GeneralSettings_MouseEnter;
            searchToolStripMenuItem.MouseEnter += ToolStrip_GeneralSettings_MouseEnter;
            // 
            // ToolStrip_Search
            // 
            ToolStrip_Search.Image = Windows.MiscIcons.Search;
            ToolStrip_Search.Name = "ToolStrip_Search";
            ToolStrip_Search.ShortcutKeys = Keys.Control | Keys.S;
            ToolStrip_Search.Size = new Size(195, 22);
            ToolStrip_Search.Text = "Search...";
            ToolStrip_Search.Click += ToolStrip_Search_Click;
            // 
            // ToolStrip_JumpTo
            // 
            ToolStrip_JumpTo.Name = "ToolStrip_JumpTo";
            ToolStrip_JumpTo.Size = new Size(195, 22);
            ToolStrip_JumpTo.Text = "Jump to path or hash...";
            ToolStrip_JumpTo.Click += ToolStrip_JumpTo_Click;
            // 
            // modToolStripMenuItem
            // 
            modToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuItem_ReplacedAssets, menuItem_ClearAll, toolStripMenuItem13, menuItem_AddFromStage, menuItem_PackAsStage });
            modToolStripMenuItem.Name = "modToolStripMenuItem";
            modToolStripMenuItem.Size = new Size(44, 20);
            modToolStripMenuItem.Text = "Mod";
            modToolStripMenuItem.Click += ToolStrip_GeneralSettings_MouseEnter;
            modToolStripMenuItem.MouseEnter += ToolStrip_GeneralSettings_MouseEnter;
            // 
            // menuItem_ReplacedAssets
            // 
            menuItem_ReplacedAssets.Enabled = false;
            menuItem_ReplacedAssets.Name = "menuItem_ReplacedAssets";
            menuItem_ReplacedAssets.Size = new Size(225, 22);
            menuItem_ReplacedAssets.Text = "0 replaced, 0 new";
            // 
            // menuItem_ClearAll
            // 
            menuItem_ClearAll.Enabled = false;
            menuItem_ClearAll.Name = "menuItem_ClearAll";
            menuItem_ClearAll.Size = new Size(225, 22);
            menuItem_ClearAll.Text = "Clear all";
            menuItem_ClearAll.Click += menuItem_ClearAll_Click;
            // 
            // toolStripMenuItem13
            // 
            toolStripMenuItem13.Enabled = false;
            toolStripMenuItem13.Name = "toolStripMenuItem13";
            toolStripMenuItem13.Size = new Size(225, 22);
            toolStripMenuItem13.Text = "───────────────────────";
            // 
            // menuItem_AddFromStage
            // 
            menuItem_AddFromStage.Enabled = false;
            menuItem_AddFromStage.Name = "menuItem_AddFromStage";
            menuItem_AddFromStage.Size = new Size(225, 22);
            menuItem_AddFromStage.Text = "Add from stage...";
            menuItem_AddFromStage.Click += menuItem_AddFromStage_Click;
            // 
            // menuItem_PackAsStage
            // 
            menuItem_PackAsStage.Name = "menuItem_PackAsStage";
            menuItem_PackAsStage.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
            menuItem_PackAsStage.Size = new Size(225, 22);
            menuItem_PackAsStage.Text = "Pack as stage...";
            menuItem_PackAsStage.Click += menuItem_PackAsStage_Click;
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ToolStrip_Home, ToolStrip_HashTool, toolStripMenuItem11, ToolStrip_ModdingTool, ToolStrip_SpandexTool, ToolStrip_SilkTextureTool, ToolStrip_ConfigWeaver, ToolStrip_ModelToolGUI, toolStripMenuItem1, ToolStrip_QuickGameLaunch });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(46, 20);
            toolsToolStripMenuItem.Text = "Tools";
            toolsToolStripMenuItem.Click += ToolStrip_GeneralSettings_MouseEnter;
            toolsToolStripMenuItem.MouseEnter += ToolStrip_GeneralSettings_MouseEnter;
            // 
            // ToolStrip_Home
            // 
            ToolStrip_Home.Image = Windows.MiscIcons.Home;
            ToolStrip_Home.Name = "ToolStrip_Home";
            ToolStrip_Home.Size = new Size(221, 22);
            ToolStrip_Home.Text = "Home";
            ToolStrip_Home.Click += ToolStrip_Home_Click;
            // 
            // ToolStrip_HashTool
            // 
            ToolStrip_HashTool.Image = Windows.MiscIcons.HashTool;
            ToolStrip_HashTool.Name = "ToolStrip_HashTool";
            ToolStrip_HashTool.ShortcutKeys = Keys.Control | Keys.H;
            ToolStrip_HashTool.Size = new Size(221, 22);
            ToolStrip_HashTool.Text = "Calculate hash...    ";
            ToolStrip_HashTool.Click += ToolStrip_HashTool_Click;
            // 
            // toolStripMenuItem11
            // 
            toolStripMenuItem11.Enabled = false;
            toolStripMenuItem11.Name = "toolStripMenuItem11";
            toolStripMenuItem11.Size = new Size(221, 22);
            toolStripMenuItem11.Text = "Environment ────────────";
            // 
            // ToolStrip_ModdingTool
            // 
            ToolStrip_ModdingTool.Image = ApplicationIcons.WebWorks_PNG;
            ToolStrip_ModdingTool.Name = "ToolStrip_ModdingTool";
            ToolStrip_ModdingTool.ShortcutKeys = Keys.Control | Keys.D1;
            ToolStrip_ModdingTool.Size = new Size(221, 22);
            ToolStrip_ModdingTool.Text = "Modding Tool";
            ToolStrip_ModdingTool.Click += ToolStrip_ModdingTool_Click;
            // 
            // ToolStrip_SpandexTool
            // 
            ToolStrip_SpandexTool.Image = ApplicationIcons.Spandex_PNG;
            ToolStrip_SpandexTool.Name = "ToolStrip_SpandexTool";
            ToolStrip_SpandexTool.ShortcutKeys = Keys.Control | Keys.D2;
            ToolStrip_SpandexTool.Size = new Size(221, 22);
            ToolStrip_SpandexTool.Text = "Spandex";
            ToolStrip_SpandexTool.Click += ToolStrip_SpandexTool_Click;
            // 
            // ToolStrip_SilkTextureTool
            // 
            ToolStrip_SilkTextureTool.Image = ApplicationIcons.SilkTexture_PNG;
            ToolStrip_SilkTextureTool.Name = "ToolStrip_SilkTextureTool";
            ToolStrip_SilkTextureTool.ShortcutKeys = Keys.Control | Keys.D3;
            ToolStrip_SilkTextureTool.Size = new Size(221, 22);
            ToolStrip_SilkTextureTool.Text = "Silk Texture";
            ToolStrip_SilkTextureTool.Click += ToolStrip_SilkTextureTool_Click;
            // 
            // ToolStrip_ConfigWeaver
            // 
            ToolStrip_ConfigWeaver.Image = ApplicationIcons.ConfigWeaver_PNG;
            ToolStrip_ConfigWeaver.Name = "ToolStrip_ConfigWeaver";
            ToolStrip_ConfigWeaver.ShortcutKeys = Keys.Control | Keys.D4;
            ToolStrip_ConfigWeaver.Size = new Size(221, 22);
            ToolStrip_ConfigWeaver.Text = "Config Weaver";
            ToolStrip_ConfigWeaver.Click += ToolStrip_ConfigWeaver_Click;
            // 
            // ToolStrip_ModelToolGUI
            // 
            ToolStrip_ModelToolGUI.Image = ApplicationIcons.ModelTools_PNG;
            ToolStrip_ModelToolGUI.Name = "ToolStrip_ModelToolGUI";
            ToolStrip_ModelToolGUI.ShortcutKeys = Keys.Control | Keys.D5;
            ToolStrip_ModelToolGUI.Size = new Size(221, 22);
            ToolStrip_ModelToolGUI.Text = "Model Tools GUI";
            ToolStrip_ModelToolGUI.Click += ToolStrip_ModelToolGUI_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Enabled = false;
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(221, 22);
            toolStripMenuItem1.Text = "Experimental ────────────";
            // 
            // ToolStrip_QuickGameLaunch
            // 
            ToolStrip_QuickGameLaunch.Name = "ToolStrip_QuickGameLaunch";
            ToolStrip_QuickGameLaunch.ShortcutKeys = Keys.Control | Keys.D0;
            ToolStrip_QuickGameLaunch.Size = new Size(221, 22);
            ToolStrip_QuickGameLaunch.Text = "Quick Game Launch";
            ToolStrip_QuickGameLaunch.Click += ToolStrip_QuickGameLaunch_Click;
            ToolStrip_QuickGameLaunch.MouseEnter += ToolStrip_GeneralSettings_MouseEnter;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ToolStrip_Information, discordToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // ToolStrip_Information
            // 
            ToolStrip_Information.Image = Windows.MiscIcons.Info;
            ToolStrip_Information.Name = "ToolStrip_Information";
            ToolStrip_Information.ShortcutKeys = Keys.F11;
            ToolStrip_Information.Size = new Size(162, 22);
            ToolStrip_Information.Text = "Information";
            ToolStrip_Information.Click += ToolStrip_Information_Click;
            // 
            // discordToolStripMenuItem
            // 
            discordToolStripMenuItem.Image = Windows.MiscIcons.Discord;
            discordToolStripMenuItem.Name = "discordToolStripMenuItem";
            discordToolStripMenuItem.ShortcutKeys = Keys.F12;
            discordToolStripMenuItem.Size = new Size(162, 22);
            discordToolStripMenuItem.Text = "Discord";
            discordToolStripMenuItem.Click += discordToolStripMenuItem_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { ToolStrip_AssetsSelected, toolStripMenuItem7, ToolStrip_ExtractSelected, ToolStrip_ExtractAsAscii, ToolStrip_ExtractAsDDS, ToolStrip_ExtractToStage, ToolStrip_ReplaceAsset, toolStripMenuItem8, ToolStrip_CopyPath, ToolStrip_CopyHash });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(215, 224);
            // 
            // ToolStrip_AssetsSelected
            // 
            ToolStrip_AssetsSelected.BackColor = Color.Black;
            ToolStrip_AssetsSelected.ForeColor = SystemColors.Control;
            ToolStrip_AssetsSelected.Name = "ToolStrip_AssetsSelected";
            ToolStrip_AssetsSelected.Size = new Size(214, 22);
            ToolStrip_AssetsSelected.Text = "N assets selected";
            // 
            // toolStripMenuItem7
            // 
            toolStripMenuItem7.BackColor = Color.Black;
            toolStripMenuItem7.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripMenuItem7.Enabled = false;
            toolStripMenuItem7.ForeColor = SystemColors.Control;
            toolStripMenuItem7.Name = "toolStripMenuItem7";
            toolStripMenuItem7.Size = new Size(214, 22);
            toolStripMenuItem7.Text = "____________________________";
            // 
            // ToolStrip_ExtractSelected
            // 
            ToolStrip_ExtractSelected.BackColor = Color.Black;
            ToolStrip_ExtractSelected.ForeColor = SystemColors.Control;
            ToolStrip_ExtractSelected.Name = "ToolStrip_ExtractSelected";
            ToolStrip_ExtractSelected.ShortcutKeys = Keys.Control | Keys.E;
            ToolStrip_ExtractSelected.Size = new Size(214, 22);
            ToolStrip_ExtractSelected.Text = "Extract selected...";
            ToolStrip_ExtractSelected.Click += ToolStrip_ExtractSelected_Click;
            // 
            // ToolStrip_ExtractAsAscii
            // 
            ToolStrip_ExtractAsAscii.BackColor = Color.Black;
            ToolStrip_ExtractAsAscii.ForeColor = SystemColors.Control;
            ToolStrip_ExtractAsAscii.Name = "ToolStrip_ExtractAsAscii";
            ToolStrip_ExtractAsAscii.Size = new Size(214, 22);
            ToolStrip_ExtractAsAscii.Text = "Extract as .ascii...";
            ToolStrip_ExtractAsAscii.Click += ToolStrip_ExtractAsAscii_Click;
            // 
            // ToolStrip_ExtractAsDDS
            // 
            ToolStrip_ExtractAsDDS.BackColor = Color.Black;
            ToolStrip_ExtractAsDDS.ForeColor = SystemColors.Control;
            ToolStrip_ExtractAsDDS.Name = "ToolStrip_ExtractAsDDS";
            ToolStrip_ExtractAsDDS.Size = new Size(214, 22);
            ToolStrip_ExtractAsDDS.Text = "Extract as .dds...";
            ToolStrip_ExtractAsDDS.Click += ToolStrip_ExtractAsDDS_Click;
            // 
            // ToolStrip_ExtractToStage
            // 
            ToolStrip_ExtractToStage.BackColor = Color.Black;
            ToolStrip_ExtractToStage.ForeColor = SystemColors.Control;
            ToolStrip_ExtractToStage.Name = "ToolStrip_ExtractToStage";
            ToolStrip_ExtractToStage.Size = new Size(214, 22);
            ToolStrip_ExtractToStage.Text = "Extract to stage...";
            ToolStrip_ExtractToStage.Click += ToolStrip_ExtractToStage_Click;
            // 
            // ToolStrip_ReplaceAsset
            // 
            ToolStrip_ReplaceAsset.BackColor = Color.Black;
            ToolStrip_ReplaceAsset.ForeColor = SystemColors.Control;
            ToolStrip_ReplaceAsset.Name = "ToolStrip_ReplaceAsset";
            ToolStrip_ReplaceAsset.ShortcutKeys = Keys.Control | Keys.R;
            ToolStrip_ReplaceAsset.Size = new Size(214, 22);
            ToolStrip_ReplaceAsset.Text = "Replace selected...";
            ToolStrip_ReplaceAsset.Click += ToolStrip_ReplaceAsset_Click;
            // 
            // toolStripMenuItem8
            // 
            toolStripMenuItem8.BackColor = Color.Black;
            toolStripMenuItem8.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripMenuItem8.Enabled = false;
            toolStripMenuItem8.ForeColor = SystemColors.Control;
            toolStripMenuItem8.Name = "toolStripMenuItem8";
            toolStripMenuItem8.Size = new Size(214, 22);
            toolStripMenuItem8.Text = "____________________________";
            // 
            // ToolStrip_CopyPath
            // 
            ToolStrip_CopyPath.BackColor = Color.Black;
            ToolStrip_CopyPath.ForeColor = SystemColors.Control;
            ToolStrip_CopyPath.Name = "ToolStrip_CopyPath";
            ToolStrip_CopyPath.Size = new Size(214, 22);
            ToolStrip_CopyPath.Text = "Copy path";
            ToolStrip_CopyPath.Click += ToolStrip_CopyPath_Click;
            // 
            // ToolStrip_CopyHash
            // 
            ToolStrip_CopyHash.BackColor = Color.Black;
            ToolStrip_CopyHash.ForeColor = SystemColors.Control;
            ToolStrip_CopyHash.Name = "ToolStrip_CopyHash";
            ToolStrip_CopyHash.Size = new Size(214, 22);
            ToolStrip_CopyHash.Text = "Copy hash";
            ToolStrip_CopyHash.Click += ToolStrip_CopyHash_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(12, 12, 12);
            ClientSize = new Size(939, 560);
            Controls.Add(panel_Main);
            Controls.Add(splitContainer1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            ForeColor = SystemColors.Control;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "MainWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WebWorks";
            FormClosing += MainWindow_FormClosing;
            Load += MainWindow_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_Files).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        private ToolStripStatusLabel OverlayHeaderLabel;
        private ToolStripStatusLabel OverlayOperationLabel;
        private TreeView TreeView_Assets;
        private DataGridView dataGridView_Files;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem searchToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem ToolStrip_LoadToc;
        private ToolStripMenuItem loadRecentToolStripMenuItem;
        private ToolStripMenuItem hashesToolStripMenuItem;
        private ToolStripMenuItem hashestxtToolStripMenuItem;
        private ToolStripMenuItem hashesi30txtToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem ToolStrip_JumpTo;
        private ToolStripMenuItem modToolStripMenuItem;
        private ToolStripMenuItem ToolStrip_HashTool;
        private ToolStripMenuItem ToolStrip_Information;
        private ToolStripMenuItem discordToolStripMenuItem;
        public Panel panel_Main;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripMenuItem toolStripMenuItem6;
        private ToolStripMenuItem toolStripMenuItem8;
        private ToolStripMenuItem toolStripMenuItem7;
        private ToolStripMenuItem ToolStrip_SpandexTool;
        private ToolStripMenuItem ToolStrip_SilkTextureTool;
        private ToolStripMenuItem ToolStrip_ModdingTool;
        private ToolStripMenuItem ToolStrip_OpenAsset;
        private ToolStripMenuItem toolStripMenuItem9;
        private ToolStripMenuItem toolStripMenuItem11;
        private ToolStripMenuItem menuItem_ReplacedAssets;
        private ToolStripMenuItem menuItem_ClearAll;
        private ToolStripMenuItem menuItem_AddFromStage;
        private ToolStripMenuItem menuItem_PackAsStage;
        private ToolStripMenuItem ToolStrip_Settings;
        private ToolStripMenuItem toolStripMenuItem10;
        private ToolStripMenuItem toolStripMenuItem13;
        public ContextMenuStrip contextMenuStrip1;
        public ToolStripMenuItem ToolStrip_ExtractToStage;
        public ToolStripMenuItem ToolStrip_ReplaceAsset;
        public ToolStripMenuItem ToolStrip_CopyPath;
        public ToolStripMenuItem ToolStrip_CopyHash;
        public ToolStripMenuItem ToolStrip_ExtractSelected;
        public ToolStripMenuItem ToolStrip_ExtractAsAscii;
        public ToolStripMenuItem ToolStrip_ExtractAsDDS;
        public ToolStripMenuItem ToolStrip_AssetsSelected;
        public SplitContainer splitContainer1;
        private ToolStripMenuItem ToolStrip_Home;
        private ToolStripMenuItem ToolStrip_Search;
        private ToolStripMenuItem menuItem_WWPROJ_Handle;
        private ToolStripMenuItem ToolStrip_QuickGameLaunch;
        private ToolStripMenuItem toolStripMenuItem1;
        private DataGridViewTextBoxColumn FileName;
        private DataGridViewTextBoxColumn Size;
        private DataGridViewTextBoxColumn Archive;
        private DataGridViewTextBoxColumn Span;
        private DataGridViewTextBoxColumn assetID;
        private DataGridViewTextBoxColumn assetPath;
        private DataGridViewTextBoxColumn assetRef;
        private DataGridViewCheckBoxColumn HasHeader;
        private ToolStripMenuItem ToolStrip_ModelToolGUI;
        private ToolStripMenuItem ToolStrip_ConfigWeaver;
    }
}
