namespace WebWorks.Windows.Search
{
    partial class SearchWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchWindow));
            SearchTextBox = new TextBox();
            SearchButton = new Button();
            label_ResultCount = new Label();
            dataGridView_Files = new DataGridView();
            FileName = new DataGridViewTextBoxColumn();
            Size = new DataGridViewTextBoxColumn();
            Archive = new DataGridViewTextBoxColumn();
            Span = new DataGridViewTextBoxColumn();
            assetID = new DataGridViewTextBoxColumn();
            assetPath = new DataGridViewTextBoxColumn();
            assetRef = new DataGridViewTextBoxColumn();
            HasHeader = new DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView_Files).BeginInit();
            SuspendLayout();
            // 
            // SearchTextBox
            // 
            SearchTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            SearchTextBox.BackColor = Color.FromArgb(22, 22, 22);
            SearchTextBox.BorderStyle = BorderStyle.FixedSingle;
            SearchTextBox.ForeColor = SystemColors.Control;
            SearchTextBox.Location = new Point(12, 12);
            SearchTextBox.Name = "SearchTextBox";
            SearchTextBox.PlaceholderText = "Search...";
            SearchTextBox.Size = new Size(590, 23);
            SearchTextBox.TabIndex = 0;
            SearchTextBox.KeyUp += SearchTextBox_KeyUp;
            // 
            // SearchButton
            // 
            SearchButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SearchButton.Location = new Point(608, 12);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(104, 23);
            SearchButton.TabIndex = 1;
            SearchButton.Text = "Search";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += SearchButton_Click;
            // 
            // label_ResultCount
            // 
            label_ResultCount.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label_ResultCount.AutoSize = true;
            label_ResultCount.Location = new Point(662, 440);
            label_ResultCount.Name = "label_ResultCount";
            label_ResultCount.Size = new Size(50, 15);
            label_ResultCount.TabIndex = 2;
            label_ResultCount.Text = "0 results";
            // 
            // dataGridView_Files
            // 
            dataGridView_Files.AllowUserToAddRows = false;
            dataGridView_Files.AllowUserToDeleteRows = false;
            dataGridView_Files.AllowUserToResizeRows = false;
            dataGridView_Files.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView_Files.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_Files.Columns.AddRange(new DataGridViewColumn[] { FileName, Size, Archive, Span, assetID, assetPath, assetRef, HasHeader });
            dataGridView_Files.Location = new Point(12, 41);
            dataGridView_Files.Name = "dataGridView_Files";
            dataGridView_Files.RowHeadersVisible = false;
            dataGridView_Files.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_Files.Size = new Size(700, 396);
            dataGridView_Files.TabIndex = 3;
            dataGridView_Files.DoubleClick += dataGridView_Files_DoubleClick;
            dataGridView_Files.KeyDown += dataGridView_Files_KeyDown;
            dataGridView_Files.MouseClick += dataGridView_Files_MouseClick;
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
            // SearchWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(12, 12, 12);
            ClientSize = new Size(724, 464);
            Controls.Add(dataGridView_Files);
            Controls.Add(label_ResultCount);
            Controls.Add(SearchButton);
            Controls.Add(SearchTextBox);
            ForeColor = SystemColors.Control;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Name = "SearchWindow";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Search Window";
            KeyDown += SearchWindow_KeyDown;
            ((System.ComponentModel.ISupportInitialize)dataGridView_Files).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox SearchTextBox;
        private Button SearchButton;
        private Label label_ResultCount;
        private DataGridView dataGridView_Files;
        private DataGridViewTextBoxColumn FileName;
        private DataGridViewTextBoxColumn Size;
        private DataGridViewTextBoxColumn Archive;
        private DataGridViewTextBoxColumn Span;
        private DataGridViewTextBoxColumn assetID;
        private DataGridViewTextBoxColumn assetPath;
        private DataGridViewTextBoxColumn assetRef;
        private DataGridViewCheckBoxColumn HasHeader;
    }
}