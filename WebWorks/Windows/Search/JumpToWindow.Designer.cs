namespace WebWorks.Windows.Search
{
    partial class JumpToWindow
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
            PathTextBox = new TextBox();
            JumpButton = new Button();
            SuspendLayout();
            // 
            // PathTextBox
            // 
            PathTextBox.BackColor = Color.FromArgb(22, 22, 22);
            PathTextBox.BorderStyle = BorderStyle.FixedSingle;
            PathTextBox.ForeColor = SystemColors.Control;
            PathTextBox.Location = new Point(12, 12);
            PathTextBox.Name = "PathTextBox";
            PathTextBox.PlaceholderText = "Hash or path...";
            PathTextBox.Size = new Size(438, 23);
            PathTextBox.TabIndex = 0;
            PathTextBox.KeyDown += PathTextBox_KeyDown;
            // 
            // JumpButton
            // 
            JumpButton.Location = new Point(456, 12);
            JumpButton.Name = "JumpButton";
            JumpButton.Size = new Size(67, 23);
            JumpButton.TabIndex = 1;
            JumpButton.Text = "Jump";
            JumpButton.UseVisualStyleBackColor = true;
            JumpButton.Click += JumpButton_Click;
            // 
            // JumpToWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(12, 12, 12);
            ClientSize = new Size(535, 46);
            Controls.Add(JumpButton);
            Controls.Add(PathTextBox);
            ForeColor = Color.FromArgb(12, 12, 12);
            KeyPreview = true;
            Name = "JumpToWindow";
            ShowIcon = false;
            Text = "Jump to...";
            KeyDown += JumpToWindow_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox PathTextBox;
        private Button JumpButton;
    }
}