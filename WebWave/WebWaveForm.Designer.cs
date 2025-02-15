namespace WebWave
{
    partial class WebWaveForm
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
            LoadSounBank_Button = new Button();
            SoundBank_TextBox = new TextBox();
            SaveAsBnk_Button = new Button();
            EventNames_dataGridView = new DataGridView();
            EventName = new DataGridViewTextBoxColumn();
            ExtractWems_Button = new Button();
            WemNames_dataGridView = new DataGridView();
            WemNames = new DataGridViewTextBoxColumn();
            NewWems_dataGridView = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            AddFromFolder_button = new Button();
            splitContainer1 = new SplitContainer();
            label1 = new Label();
            Generate_Button = new Button();
            ((System.ComponentModel.ISupportInitialize)EventNames_dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)WemNames_dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NewWems_dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // LoadSounBank_Button
            // 
            LoadSounBank_Button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            LoadSounBank_Button.Location = new Point(908, 12);
            LoadSounBank_Button.Name = "LoadSounBank_Button";
            LoadSounBank_Button.Size = new Size(152, 23);
            LoadSounBank_Button.TabIndex = 0;
            LoadSounBank_Button.Text = "Load .soundbank";
            LoadSounBank_Button.UseVisualStyleBackColor = true;
            LoadSounBank_Button.Click += LoadSounBank_Button_Click;
            // 
            // SoundBank_TextBox
            // 
            SoundBank_TextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            SoundBank_TextBox.BackColor = Color.FromArgb(22, 22, 22);
            SoundBank_TextBox.BorderStyle = BorderStyle.FixedSingle;
            SoundBank_TextBox.ForeColor = SystemColors.Control;
            SoundBank_TextBox.Location = new Point(12, 12);
            SoundBank_TextBox.Name = "SoundBank_TextBox";
            SoundBank_TextBox.ReadOnly = true;
            SoundBank_TextBox.Size = new Size(890, 23);
            SoundBank_TextBox.TabIndex = 1;
            // 
            // SaveAsBnk_Button
            // 
            SaveAsBnk_Button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SaveAsBnk_Button.Location = new Point(749, 59);
            SaveAsBnk_Button.Name = "SaveAsBnk_Button";
            SaveAsBnk_Button.Size = new Size(310, 23);
            SaveAsBnk_Button.TabIndex = 2;
            SaveAsBnk_Button.Text = "Save as .bnk";
            SaveAsBnk_Button.UseVisualStyleBackColor = true;
            SaveAsBnk_Button.Click += SaveAsBnk_Button_Click;
            // 
            // EventNames_dataGridView
            // 
            EventNames_dataGridView.AllowUserToAddRows = false;
            EventNames_dataGridView.AllowUserToDeleteRows = false;
            EventNames_dataGridView.AllowUserToResizeColumns = false;
            EventNames_dataGridView.AllowUserToResizeRows = false;
            EventNames_dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            EventNames_dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            EventNames_dataGridView.Columns.AddRange(new DataGridViewColumn[] { EventName });
            EventNames_dataGridView.Location = new Point(749, 231);
            EventNames_dataGridView.Name = "EventNames_dataGridView";
            EventNames_dataGridView.RowHeadersVisible = false;
            EventNames_dataGridView.Size = new Size(319, 408);
            EventNames_dataGridView.TabIndex = 4;
            // 
            // EventName
            // 
            EventName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            EventName.HeaderText = "Event Names";
            EventName.Name = "EventName";
            EventName.ReadOnly = true;
            // 
            // ExtractWems_Button
            // 
            ExtractWems_Button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ExtractWems_Button.Location = new Point(749, 88);
            ExtractWems_Button.Name = "ExtractWems_Button";
            ExtractWems_Button.Size = new Size(153, 23);
            ExtractWems_Button.TabIndex = 5;
            ExtractWems_Button.Text = "Extract Wems";
            ExtractWems_Button.UseVisualStyleBackColor = true;
            ExtractWems_Button.Click += ExtractWems_Button_Click;
            // 
            // WemNames_dataGridView
            // 
            WemNames_dataGridView.AllowUserToAddRows = false;
            WemNames_dataGridView.AllowUserToDeleteRows = false;
            WemNames_dataGridView.AllowUserToResizeColumns = false;
            WemNames_dataGridView.AllowUserToResizeRows = false;
            WemNames_dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            WemNames_dataGridView.Columns.AddRange(new DataGridViewColumn[] { WemNames });
            WemNames_dataGridView.Dock = DockStyle.Fill;
            WemNames_dataGridView.Location = new Point(0, 0);
            WemNames_dataGridView.Name = "WemNames_dataGridView";
            WemNames_dataGridView.RowHeadersVisible = false;
            WemNames_dataGridView.Size = new Size(363, 598);
            WemNames_dataGridView.TabIndex = 6;
            // 
            // WemNames
            // 
            WemNames.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            WemNames.HeaderText = "Wem Names";
            WemNames.Name = "WemNames";
            WemNames.ReadOnly = true;
            // 
            // NewWems_dataGridView
            // 
            NewWems_dataGridView.AllowUserToAddRows = false;
            NewWems_dataGridView.AllowUserToDeleteRows = false;
            NewWems_dataGridView.AllowUserToResizeColumns = false;
            NewWems_dataGridView.AllowUserToResizeRows = false;
            NewWems_dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            NewWems_dataGridView.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1 });
            NewWems_dataGridView.Dock = DockStyle.Fill;
            NewWems_dataGridView.Location = new Point(0, 0);
            NewWems_dataGridView.Name = "NewWems_dataGridView";
            NewWems_dataGridView.RowHeadersVisible = false;
            NewWems_dataGridView.Size = new Size(364, 598);
            NewWems_dataGridView.TabIndex = 7;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn1.HeaderText = "Custom Wem Names";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // AddFromFolder_button
            // 
            AddFromFolder_button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            AddFromFolder_button.Location = new Point(908, 88);
            AddFromFolder_button.Name = "AddFromFolder_button";
            AddFromFolder_button.Size = new Size(151, 23);
            AddFromFolder_button.TabIndex = 8;
            AddFromFolder_button.Text = "Add from folder";
            AddFromFolder_button.UseVisualStyleBackColor = true;
            AddFromFolder_button.Click += AddFromFolder_button_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(12, 41);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(WemNames_dataGridView);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(NewWems_dataGridView);
            splitContainer1.Size = new Size(731, 598);
            splitContainer1.SplitterDistance = 363;
            splitContainer1.TabIndex = 9;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ActiveBorder;
            label1.Location = new Point(749, 41);
            label1.Name = "label1";
            label1.Size = new Size(101, 15);
            label1.TabIndex = 10;
            label1.Text = "Soundbank editor";
            // 
            // Generate_Button
            // 
            Generate_Button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Generate_Button.Location = new Point(749, 117);
            Generate_Button.Name = "Generate_Button";
            Generate_Button.Size = new Size(310, 23);
            Generate_Button.TabIndex = 11;
            Generate_Button.Text = "Generate custom .soundbank";
            Generate_Button.UseVisualStyleBackColor = true;
            Generate_Button.Click += Generate_Button_Click;
            // 
            // WebWaveForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(12, 12, 12);
            ClientSize = new Size(1072, 651);
            Controls.Add(Generate_Button);
            Controls.Add(label1);
            Controls.Add(AddFromFolder_button);
            Controls.Add(ExtractWems_Button);
            Controls.Add(splitContainer1);
            Controls.Add(EventNames_dataGridView);
            Controls.Add(SaveAsBnk_Button);
            Controls.Add(SoundBank_TextBox);
            Controls.Add(LoadSounBank_Button);
            Name = "WebWaveForm";
            Text = "WebWave";
            ((System.ComponentModel.ISupportInitialize)EventNames_dataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)WemNames_dataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)NewWems_dataGridView).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button LoadSounBank_Button;
        private TextBox SoundBank_TextBox;
        private Button SaveAsBnk_Button;
        private DataGridView EventNames_dataGridView;
        private DataGridViewTextBoxColumn EventName;
        private Button ExtractWems_Button;
        private DataGridView WemNames_dataGridView;
        private DataGridViewTextBoxColumn WemNames;
        private DataGridView NewWems_dataGridView;
        private Button AddFromFolder_button;
        private SplitContainer splitContainer1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private Label label1;
        private Button Generate_Button;
    }
}
