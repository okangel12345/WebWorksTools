namespace WebWorks
{
    partial class SettingsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsWindow));
            btn_Save = new Button();
            textBox_AuthorName = new TextBox();
            check_AutoLoadToc = new CheckBox();
            label1 = new Label();
            check_LoadModToc = new CheckBox();
            check_ExperimentalFeatures = new CheckBox();
            comboBox_PreferredGame = new ComboBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // btn_Save
            // 
            btn_Save.Location = new Point(337, 133);
            btn_Save.Name = "btn_Save";
            btn_Save.Size = new Size(129, 30);
            btn_Save.TabIndex = 1;
            btn_Save.Text = "Save";
            btn_Save.UseVisualStyleBackColor = true;
            btn_Save.Click += btn_Save_Click_1;
            // 
            // textBox_AuthorName
            // 
            textBox_AuthorName.BackColor = Color.FromArgb(22, 22, 22);
            textBox_AuthorName.BorderStyle = BorderStyle.FixedSingle;
            textBox_AuthorName.ForeColor = SystemColors.Control;
            textBox_AuthorName.Location = new Point(109, 12);
            textBox_AuthorName.Name = "textBox_AuthorName";
            textBox_AuthorName.PlaceholderText = "Your name...";
            textBox_AuthorName.Size = new Size(357, 23);
            textBox_AuthorName.TabIndex = 2;
            // 
            // check_AutoLoadToc
            // 
            check_AutoLoadToc.AutoSize = true;
            check_AutoLoadToc.Checked = true;
            check_AutoLoadToc.CheckState = CheckState.Checked;
            check_AutoLoadToc.ForeColor = SystemColors.Control;
            check_AutoLoadToc.Location = new Point(12, 144);
            check_AutoLoadToc.Name = "check_AutoLoadToc";
            check_AutoLoadToc.Size = new Size(171, 19);
            check_AutoLoadToc.TabIndex = 3;
            check_AutoLoadToc.Text = "Auto-load most recent TOC";
            check_AutoLoadToc.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(80, 15);
            label1.TabIndex = 4;
            label1.Text = "Author name:";
            // 
            // check_LoadModToc
            // 
            check_LoadModToc.AutoSize = true;
            check_LoadModToc.Checked = true;
            check_LoadModToc.CheckState = CheckState.Checked;
            check_LoadModToc.ForeColor = SystemColors.Control;
            check_LoadModToc.Location = new Point(12, 94);
            check_LoadModToc.Name = "check_LoadModToc";
            check_LoadModToc.Size = new Size(130, 19);
            check_LoadModToc.TabIndex = 5;
            check_LoadModToc.Text = "Load modded TOCs";
            check_LoadModToc.UseVisualStyleBackColor = true;
            // 
            // check_ExperimentalFeatures
            // 
            check_ExperimentalFeatures.AutoSize = true;
            check_ExperimentalFeatures.Checked = true;
            check_ExperimentalFeatures.CheckState = CheckState.Checked;
            check_ExperimentalFeatures.ForeColor = SystemColors.Control;
            check_ExperimentalFeatures.Location = new Point(12, 119);
            check_ExperimentalFeatures.Name = "check_ExperimentalFeatures";
            check_ExperimentalFeatures.Size = new Size(178, 19);
            check_ExperimentalFeatures.TabIndex = 6;
            check_ExperimentalFeatures.Text = "Enable experimental features";
            check_ExperimentalFeatures.UseVisualStyleBackColor = true;
            // 
            // comboBox_PreferredGame
            // 
            comboBox_PreferredGame.BackColor = Color.FromArgb(12, 12, 12);
            comboBox_PreferredGame.FlatStyle = FlatStyle.Flat;
            comboBox_PreferredGame.ForeColor = SystemColors.Control;
            comboBox_PreferredGame.FormattingEnabled = true;
            comboBox_PreferredGame.Items.AddRange(new object[] { "Default", "Marvel's Spider-Man Remastered", "Marvel's Spider-Man: Miles Morales", "Ratchet & Clank: Rift Apart", "Marvel's Spider-Man 2", "i33" });
            comboBox_PreferredGame.Location = new Point(109, 42);
            comboBox_PreferredGame.Name = "comboBox_PreferredGame";
            comboBox_PreferredGame.Size = new Size(357, 23);
            comboBox_PreferredGame.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(12, 50);
            label2.Name = "label2";
            label2.Size = new Size(91, 15);
            label2.TabIndex = 8;
            label2.Text = "Preferred game:";
            // 
            // SettingsWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(12, 12, 12);
            ClientSize = new Size(478, 180);
            Controls.Add(label2);
            Controls.Add(comboBox_PreferredGame);
            Controls.Add(check_ExperimentalFeatures);
            Controls.Add(check_LoadModToc);
            Controls.Add(label1);
            Controls.Add(textBox_AuthorName);
            Controls.Add(check_AutoLoadToc);
            Controls.Add(btn_Save);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SettingsWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Settings";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btn_Save;
        private CheckBox check_AutoLoadToc;
        private TextBox textBox_AuthorName;
        private Label label1;
        private CheckBox check_LoadModToc;
        private CheckBox check_ExperimentalFeatures;
        private ComboBox comboBox_PreferredGame;
        private Label label2;
    }
}