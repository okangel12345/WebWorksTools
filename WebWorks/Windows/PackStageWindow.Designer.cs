namespace WebWorks.Windows
{
    partial class PackStageWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PackStageWindow));
            NameTextBox = new TextBox();
            AuthorTextBox = new TextBox();
            GameComboBox = new ComboBox();
            AssetsList = new DataGridView();
            OriginalAssetName = new DataGridViewTextBoxColumn();
            ReplacingFileName = new DataGridViewTextBoxColumn();
            OriginalAssetNameToolTip = new DataGridViewTextBoxColumn();
            ReplacingFileNameToolTip = new DataGridViewTextBoxColumn();
            SaveStageButton = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            ClearAllButton = new Button();
            ((System.ComponentModel.ISupportInitialize)AssetsList).BeginInit();
            SuspendLayout();
            // 
            // NameTextBox
            // 
            NameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            NameTextBox.BackColor = Color.FromArgb(22, 22, 22);
            NameTextBox.BorderStyle = BorderStyle.FixedSingle;
            NameTextBox.ForeColor = SystemColors.Control;
            NameTextBox.Location = new Point(60, 12);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(687, 23);
            NameTextBox.TabIndex = 1;
            NameTextBox.TextChanged += NameTextBox_TextChanged;
            // 
            // AuthorTextBox
            // 
            AuthorTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            AuthorTextBox.BackColor = Color.FromArgb(22, 22, 22);
            AuthorTextBox.BorderStyle = BorderStyle.FixedSingle;
            AuthorTextBox.ForeColor = SystemColors.Control;
            AuthorTextBox.Location = new Point(60, 41);
            AuthorTextBox.Name = "AuthorTextBox";
            AuthorTextBox.Size = new Size(687, 23);
            AuthorTextBox.TabIndex = 4;
            AuthorTextBox.TextChanged += AuthorTextBox_TextChanged;
            // 
            // GameComboBox
            // 
            GameComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            GameComboBox.BackColor = Color.FromArgb(22, 22, 22);
            GameComboBox.FlatStyle = FlatStyle.Flat;
            GameComboBox.ForeColor = SystemColors.Control;
            GameComboBox.FormattingEnabled = true;
            GameComboBox.Location = new Point(60, 70);
            GameComboBox.Name = "GameComboBox";
            GameComboBox.Size = new Size(687, 23);
            GameComboBox.TabIndex = 5;
            GameComboBox.SelectedIndexChanged += GameComboBox_SelectedIndexChanged;
            // 
            // AssetsList
            // 
            AssetsList.AllowUserToAddRows = false;
            AssetsList.AllowUserToDeleteRows = false;
            AssetsList.AllowUserToResizeColumns = false;
            AssetsList.AllowUserToResizeRows = false;
            AssetsList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            AssetsList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            AssetsList.Columns.AddRange(new DataGridViewColumn[] { OriginalAssetName, ReplacingFileName, OriginalAssetNameToolTip, ReplacingFileNameToolTip });
            AssetsList.Location = new Point(12, 128);
            AssetsList.Name = "AssetsList";
            AssetsList.RowHeadersVisible = false;
            AssetsList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            AssetsList.Size = new Size(735, 489);
            AssetsList.TabIndex = 6;
            AssetsList.KeyDown += AssetsList_KeyDown;
            // 
            // OriginalAssetName
            // 
            OriginalAssetName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            OriginalAssetName.DataPropertyName = "OriginalAssetName";
            OriginalAssetName.HeaderText = "Original Asset Name";
            OriginalAssetName.Name = "OriginalAssetName";
            // 
            // ReplacingFileName
            // 
            ReplacingFileName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ReplacingFileName.DataPropertyName = "ReplacingFileName";
            ReplacingFileName.HeaderText = "Replacing File Name";
            ReplacingFileName.Name = "ReplacingFileName";
            // 
            // OriginalAssetNameToolTip
            // 
            OriginalAssetNameToolTip.DataPropertyName = "OriginalAssetNameToolTip";
            OriginalAssetNameToolTip.HeaderText = "OriginalAssetNameToolTip";
            OriginalAssetNameToolTip.Name = "OriginalAssetNameToolTip";
            OriginalAssetNameToolTip.Visible = false;
            // 
            // ReplacingFileNameToolTip
            // 
            ReplacingFileNameToolTip.DataPropertyName = "ReplacingFileNameToolTip";
            ReplacingFileNameToolTip.HeaderText = "ReplacingFileNameToolTip";
            ReplacingFileNameToolTip.Name = "ReplacingFileNameToolTip";
            ReplacingFileNameToolTip.Visible = false;
            // 
            // SaveStageButton
            // 
            SaveStageButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SaveStageButton.Location = new Point(521, 99);
            SaveStageButton.Name = "SaveStageButton";
            SaveStageButton.Size = new Size(226, 23);
            SaveStageButton.TabIndex = 8;
            SaveStageButton.Text = "Save stage...";
            SaveStageButton.UseVisualStyleBackColor = true;
            SaveStageButton.Click += SaveStageButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ActiveBorder;
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 10;
            label1.Text = "Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ActiveBorder;
            label2.Location = new Point(12, 49);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 11;
            label2.Text = "Author:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ActiveBorder;
            label3.Location = new Point(12, 78);
            label3.Name = "label3";
            label3.Size = new Size(41, 15);
            label3.TabIndex = 12;
            label3.Text = "Game:";
            // 
            // button1
            // 
            button1.Location = new Point(128, 99);
            button1.Name = "button1";
            button1.Size = new Size(110, 23);
            button1.TabIndex = 15;
            button1.Text = "Add new asset...";
            button1.UseVisualStyleBackColor = true;
            button1.Visible = false;
            // 
            // ClearAllButton
            // 
            ClearAllButton.Location = new Point(12, 99);
            ClearAllButton.Name = "ClearAllButton";
            ClearAllButton.Size = new Size(110, 23);
            ClearAllButton.TabIndex = 16;
            ClearAllButton.Text = "Clear all..";
            ClearAllButton.UseVisualStyleBackColor = true;
            ClearAllButton.Click += ClearAllButton_Click;
            // 
            // PackStageWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(12, 12, 12);
            ClientSize = new Size(759, 629);
            Controls.Add(ClearAllButton);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(SaveStageButton);
            Controls.Add(AssetsList);
            Controls.Add(GameComboBox);
            Controls.Add(AuthorTextBox);
            Controls.Add(NameTextBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Name = "PackStageWindow";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Pack mod as stage";
            KeyDown += PackStageWindow_KeyDown;
            ((System.ComponentModel.ISupportInitialize)AssetsList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox NameTextBox;
        private TextBox AuthorTextBox;
        private ComboBox GameComboBox;
        private DataGridView AssetsList;
        private DataGridViewTextBoxColumn OriginalAssetName;
        private DataGridViewTextBoxColumn ReplacingFileName;
        private DataGridViewTextBoxColumn OriginalAssetNameToolTip;
        private DataGridViewTextBoxColumn ReplacingFileNameToolTip;
        private Button SaveStageButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private Button ClearAllButton;
    }
}