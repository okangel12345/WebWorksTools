namespace WebWorks.Windows
{
    partial class StageSelectorWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StageSelectorWindow));
            WarningMessage = new Label();
            SelectButton = new Button();
            NameComboBox = new ComboBox();
            SuspendLayout();
            // 
            // WarningMessage
            // 
            WarningMessage.AutoSize = true;
            WarningMessage.ForeColor = SystemColors.Control;
            WarningMessage.Location = new Point(12, 40);
            WarningMessage.Name = "WarningMessage";
            WarningMessage.Size = new Size(38, 15);
            WarningMessage.TabIndex = 0;
            WarningMessage.Text = "label1";
            // 
            // SelectButton
            // 
            SelectButton.Location = new Point(249, 11);
            SelectButton.Name = "SelectButton";
            SelectButton.Size = new Size(77, 23);
            SelectButton.TabIndex = 1;
            SelectButton.Text = "Select";
            SelectButton.UseVisualStyleBackColor = true;
            SelectButton.Click += SelectButton_Click;
            // 
            // NameComboBox
            // 
            NameComboBox.BackColor = Color.FromArgb(22, 22, 22);
            NameComboBox.FlatStyle = FlatStyle.Flat;
            NameComboBox.ForeColor = SystemColors.Control;
            NameComboBox.FormattingEnabled = true;
            NameComboBox.Location = new Point(12, 12);
            NameComboBox.Name = "NameComboBox";
            NameComboBox.Size = new Size(231, 23);
            NameComboBox.TabIndex = 2;
            NameComboBox.TextChanged += NameComboBox_TextChanged;
            NameComboBox.KeyDown += NameComboBox_KeyDown;
            // 
            // StageSelectorWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(12, 12, 12);
            ClientSize = new Size(338, 61);
            Controls.Add(NameComboBox);
            Controls.Add(SelectButton);
            Controls.Add(WarningMessage);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "StageSelectorWindow";
            ShowIcon = false;
            Text = "Select stage...";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label WarningMessage;
        private Button SelectButton;
        private ComboBox NameComboBox;
    }
}