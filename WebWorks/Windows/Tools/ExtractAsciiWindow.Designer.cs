namespace WebWorks.Windows.Tools
{
    partial class ExtractAsciiWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExtractAsciiWindow));
            comboBox_OutputGame = new ComboBox();
            textBox_FilePath = new TextBox();
            label1 = new Label();
            label2 = new Label();
            textBox_FileHash = new TextBox();
            label3 = new Label();
            ExtractButton = new Button();
            richTextBox_Log = new RichTextBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // comboBox_OutputGame
            // 
            comboBox_OutputGame.BackColor = Color.FromArgb(12, 12, 12);
            comboBox_OutputGame.ForeColor = SystemColors.Control;
            comboBox_OutputGame.FormattingEnabled = true;
            comboBox_OutputGame.Items.AddRange(new object[] { "MSMR", "MSMM", "MSM2", "RCRA" });
            comboBox_OutputGame.Location = new Point(12, 74);
            comboBox_OutputGame.Name = "comboBox_OutputGame";
            comboBox_OutputGame.Size = new Size(133, 23);
            comboBox_OutputGame.TabIndex = 0;
            // 
            // textBox_FilePath
            // 
            textBox_FilePath.BackColor = Color.FromArgb(22, 22, 22);
            textBox_FilePath.BorderStyle = BorderStyle.FixedSingle;
            textBox_FilePath.ForeColor = Color.FromArgb(185, 185, 185);
            textBox_FilePath.Location = new Point(12, 27);
            textBox_FilePath.Name = "textBox_FilePath";
            textBox_FilePath.Size = new Size(346, 23);
            textBox_FilePath.TabIndex = 1;
            textBox_FilePath.Text = "Asset path";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(9, 9);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 2;
            label1.Text = "File path:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(9, 56);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 3;
            label2.Text = "Game:";
            // 
            // textBox_FileHash
            // 
            textBox_FileHash.BackColor = Color.FromArgb(22, 22, 22);
            textBox_FileHash.BorderStyle = BorderStyle.FixedSingle;
            textBox_FileHash.ForeColor = Color.FromArgb(185, 185, 185);
            textBox_FileHash.Location = new Point(364, 27);
            textBox_FileHash.Name = "textBox_FileHash";
            textBox_FileHash.Size = new Size(184, 23);
            textBox_FileHash.TabIndex = 4;
            textBox_FileHash.Text = "Asset hash";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(361, 9);
            label3.Name = "label3";
            label3.Size = new Size(37, 15);
            label3.TabIndex = 5;
            label3.Text = "Hash:";
            // 
            // ExtractButton
            // 
            ExtractButton.Location = new Point(364, 74);
            ExtractButton.Name = "ExtractButton";
            ExtractButton.Size = new Size(184, 23);
            ExtractButton.TabIndex = 6;
            ExtractButton.Text = "Extract .ascii";
            ExtractButton.UseVisualStyleBackColor = true;
            ExtractButton.Click += ExtractButton_Click;
            // 
            // richTextBox_Log
            // 
            richTextBox_Log.BackColor = Color.FromArgb(32, 32, 32);
            richTextBox_Log.BorderStyle = BorderStyle.None;
            richTextBox_Log.ForeColor = Color.Gainsboro;
            richTextBox_Log.Location = new Point(12, 129);
            richTextBox_Log.Name = "richTextBox_Log";
            richTextBox_Log.Size = new Size(536, 147);
            richTextBox_Log.TabIndex = 7;
            richTextBox_Log.Text = "";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(9, 111);
            label4.Name = "label4";
            label4.Size = new Size(30, 15);
            label4.TabIndex = 8;
            label4.Text = "Log:";
            // 
            // ExtractAsciiWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(12, 12, 12);
            ClientSize = new Size(560, 288);
            Controls.Add(label4);
            Controls.Add(richTextBox_Log);
            Controls.Add(ExtractButton);
            Controls.Add(label3);
            Controls.Add(textBox_FileHash);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox_FilePath);
            Controls.Add(comboBox_OutputGame);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ExtractAsciiWindow";
            Text = "Extract .ascii - ";
            KeyDown += ExtractAsciiWindow_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox_OutputGame;
        private TextBox textBox_FilePath;
        private Label label1;
        private Label label2;
        private TextBox textBox_FileHash;
        private Label label3;
        private Button ExtractButton;
        private RichTextBox richTextBox_Log;
        private Label label4;
    }
}