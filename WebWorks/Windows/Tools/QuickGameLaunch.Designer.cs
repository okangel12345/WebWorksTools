namespace WebWorks.Windows.Tools
{
    partial class QuickGameLaunch
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
            textBox_GamePath = new TextBox();
            BrowseButton = new Button();
            textBox_Args = new TextBox();
            textBox_Process = new TextBox();
            StartGameButton = new Button();
            EndGameButton = new Button();
            FullReloadButton = new Button();
            ParentWindowButton = new Button();
            panel1 = new Panel();
            label_TempProcess = new Label();
            richTextBox1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox_GamePath
            // 
            textBox_GamePath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_GamePath.BackColor = Color.FromArgb(22, 22, 22);
            textBox_GamePath.BorderStyle = BorderStyle.FixedSingle;
            textBox_GamePath.ForeColor = SystemColors.Control;
            textBox_GamePath.Location = new Point(12, 12);
            textBox_GamePath.Name = "textBox_GamePath";
            textBox_GamePath.PlaceholderText = "path/to/executable.exe";
            textBox_GamePath.Size = new Size(423, 23);
            textBox_GamePath.TabIndex = 0;
            // 
            // BrowseButton
            // 
            BrowseButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BrowseButton.Location = new Point(441, 12);
            BrowseButton.Name = "BrowseButton";
            BrowseButton.Size = new Size(92, 23);
            BrowseButton.TabIndex = 1;
            BrowseButton.Text = "Browse...";
            BrowseButton.UseVisualStyleBackColor = true;
            BrowseButton.Click += BrowseButton_Click;
            // 
            // textBox_Args
            // 
            textBox_Args.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox_Args.BackColor = Color.FromArgb(22, 22, 22);
            textBox_Args.BorderStyle = BorderStyle.FixedSingle;
            textBox_Args.ForeColor = SystemColors.Control;
            textBox_Args.Location = new Point(539, 12);
            textBox_Args.Name = "textBox_Args";
            textBox_Args.PlaceholderText = "-arguments";
            textBox_Args.Size = new Size(114, 23);
            textBox_Args.TabIndex = 2;
            // 
            // textBox_Process
            // 
            textBox_Process.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox_Process.BackColor = Color.FromArgb(22, 22, 22);
            textBox_Process.BorderStyle = BorderStyle.FixedSingle;
            textBox_Process.ForeColor = SystemColors.Control;
            textBox_Process.Location = new Point(659, 12);
            textBox_Process.Name = "textBox_Process";
            textBox_Process.PlaceholderText = "Process name";
            textBox_Process.Size = new Size(105, 23);
            textBox_Process.TabIndex = 3;
            // 
            // StartGameButton
            // 
            StartGameButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            StartGameButton.Location = new Point(770, 12);
            StartGameButton.Name = "StartGameButton";
            StartGameButton.Size = new Size(103, 23);
            StartGameButton.TabIndex = 4;
            StartGameButton.Text = "Start Game...";
            StartGameButton.UseVisualStyleBackColor = true;
            StartGameButton.Click += StartGameButton_Click;
            // 
            // EndGameButton
            // 
            EndGameButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            EndGameButton.Location = new Point(879, 12);
            EndGameButton.Name = "EndGameButton";
            EndGameButton.Size = new Size(89, 23);
            EndGameButton.TabIndex = 5;
            EndGameButton.Text = "End game...";
            EndGameButton.UseVisualStyleBackColor = true;
            EndGameButton.Click += EndGameButton_Click;
            // 
            // FullReloadButton
            // 
            FullReloadButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            FullReloadButton.Location = new Point(974, 12);
            FullReloadButton.Name = "FullReloadButton";
            FullReloadButton.Size = new Size(85, 23);
            FullReloadButton.TabIndex = 6;
            FullReloadButton.Text = "Reload...";
            FullReloadButton.UseVisualStyleBackColor = true;
            FullReloadButton.Click += FullReloadButton_Click;
            // 
            // ParentWindowButton
            // 
            ParentWindowButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ParentWindowButton.Location = new Point(1065, 12);
            ParentWindowButton.Name = "ParentWindowButton";
            ParentWindowButton.Size = new Size(88, 23);
            ParentWindowButton.TabIndex = 7;
            ParentWindowButton.Text = "Parent..";
            ParentWindowButton.UseVisualStyleBackColor = true;
            ParentWindowButton.Click += ParentWindowButton_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.Black;
            panel1.BackgroundImage = FormIcons.Wallpaper_Blank_Png;
            panel1.BackgroundImageLayout = ImageLayout.Zoom;
            panel1.Controls.Add(label_TempProcess);
            panel1.Controls.Add(richTextBox1);
            panel1.Location = new Point(0, 46);
            panel1.Name = "panel1";
            panel1.Size = new Size(1165, 561);
            panel1.TabIndex = 8;
            // 
            // label_TempProcess
            // 
            label_TempProcess.AutoSize = true;
            label_TempProcess.ForeColor = Color.Black;
            label_TempProcess.Location = new Point(12, 37);
            label_TempProcess.Name = "label_TempProcess";
            label_TempProcess.Size = new Size(96, 15);
            label_TempProcess.TabIndex = 1;
            label_TempProcess.Text = "Current Process..";
            // 
            // richTextBox1
            // 
            richTextBox1.AutoSize = true;
            richTextBox1.ForeColor = SystemColors.ActiveBorder;
            richTextBox1.Location = new Point(12, 9);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(0, 15);
            richTextBox1.TabIndex = 0;
            // 
            // QuickGameLaunch
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(12, 12, 12);
            ClientSize = new Size(1165, 607);
            Controls.Add(panel1);
            Controls.Add(ParentWindowButton);
            Controls.Add(FullReloadButton);
            Controls.Add(EndGameButton);
            Controls.Add(StartGameButton);
            Controls.Add(textBox_Process);
            Controls.Add(textBox_Args);
            Controls.Add(BrowseButton);
            Controls.Add(textBox_GamePath);
            Name = "QuickGameLaunch";
            Text = "QuickGameLaunch";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox_GamePath;
        private Button BrowseButton;
        private TextBox textBox_Args;
        private TextBox textBox_Process;
        private Button StartGameButton;
        private Button EndGameButton;
        private Button FullReloadButton;
        private Button ParentWindowButton;
        private Panel panel1;
        private Label richTextBox1;
        private Label label_TempProcess;
    }
}