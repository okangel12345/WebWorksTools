namespace ConfigWeaver
{
    partial class ConfigWeaverForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigWeaverForm));
            InputFileButton = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            OutputFileButton = new Button();
            textBox_type = new TextBox();
            label1 = new Label();
            StartConversionButton = new Button();
            label2 = new Label();
            DetectedFileTypeLabel = new Label();
            richTextBox1 = new RichTextBox();
            SuspendLayout();
            // 
            // InputFileButton
            // 
            InputFileButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            InputFileButton.Location = new Point(916, 12);
            InputFileButton.Name = "InputFileButton";
            InputFileButton.Size = new Size(176, 23);
            InputFileButton.TabIndex = 0;
            InputFileButton.Text = "Select input file...";
            InputFileButton.UseVisualStyleBackColor = true;
            InputFileButton.Click += InputFileButton_Click;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.BackColor = Color.FromArgb(22, 22, 22);
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.ForeColor = SystemColors.Control;
            textBox1.Location = new Point(12, 12);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "File to convert...";
            textBox1.Size = new Size(898, 23);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox2.BackColor = Color.FromArgb(22, 22, 22);
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.ForeColor = SystemColors.Control;
            textBox2.Location = new Point(12, 41);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Output file...";
            textBox2.Size = new Size(898, 23);
            textBox2.TabIndex = 3;
            // 
            // OutputFileButton
            // 
            OutputFileButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            OutputFileButton.Location = new Point(916, 41);
            OutputFileButton.Name = "OutputFileButton";
            OutputFileButton.Size = new Size(176, 23);
            OutputFileButton.TabIndex = 2;
            OutputFileButton.Text = "Select output file...";
            OutputFileButton.UseVisualStyleBackColor = true;
            OutputFileButton.Click += OutputFileButton_Click;
            // 
            // textBox_type
            // 
            textBox_type.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox_type.BackColor = Color.FromArgb(22, 22, 22);
            textBox_type.BorderStyle = BorderStyle.None;
            textBox_type.Enabled = false;
            textBox_type.ForeColor = SystemColors.Control;
            textBox_type.Location = new Point(916, 123);
            textBox_type.Name = "textBox_type";
            textBox_type.PlaceholderText = "(e.g., VanityItemConfig)";
            textBox_type.ReadOnly = true;
            textBox_type.Size = new Size(139, 16);
            textBox_type.TabIndex = 4;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(916, 75);
            label1.Name = "label1";
            label1.Size = new Size(105, 15);
            label1.TabIndex = 5;
            label1.Text = "Detected File Type:";
            // 
            // StartConversionButton
            // 
            StartConversionButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            StartConversionButton.Location = new Point(916, 581);
            StartConversionButton.Name = "StartConversionButton";
            StartConversionButton.Size = new Size(176, 27);
            StartConversionButton.TabIndex = 6;
            StartConversionButton.Text = "Convert to...";
            StartConversionButton.UseVisualStyleBackColor = true;
            StartConversionButton.Visible = false;
            StartConversionButton.Click += StartConversionButton_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.ForeColor = Color.FromArgb(80, 80, 80);
            label2.Location = new Point(916, 105);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 7;
            label2.Text = "Config type:";
            // 
            // DetectedFileTypeLabel
            // 
            DetectedFileTypeLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            DetectedFileTypeLabel.AutoSize = true;
            DetectedFileTypeLabel.ForeColor = SystemColors.Control;
            DetectedFileTypeLabel.Location = new Point(916, 90);
            DetectedFileTypeLabel.Name = "DetectedFileTypeLabel";
            DetectedFileTypeLabel.Size = new Size(16, 15);
            DetectedFileTypeLabel.TabIndex = 8;
            DetectedFileTypeLabel.Text = "...";
            // 
            // richTextBox1
            // 
            richTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox1.BackColor = Color.Black;
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.ForeColor = Color.Gainsboro;
            richTextBox1.Location = new Point(12, 72);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(898, 536);
            richTextBox1.TabIndex = 9;
            richTextBox1.Text = "";
            // 
            // ConfigWeaverForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(22, 22, 22);
            ClientSize = new Size(1104, 620);
            Controls.Add(richTextBox1);
            Controls.Add(DetectedFileTypeLabel);
            Controls.Add(label2);
            Controls.Add(StartConversionButton);
            Controls.Add(label1);
            Controls.Add(textBox_type);
            Controls.Add(textBox2);
            Controls.Add(OutputFileButton);
            Controls.Add(textBox1);
            Controls.Add(InputFileButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ConfigWeaverForm";
            Text = "Config Weaver";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button InputFileButton;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button OutputFileButton;
        private TextBox textBox_type;
        private Label label1;
        private Button StartConversionButton;
        private Label label2;
        private Label DetectedFileTypeLabel;
        private RichTextBox richTextBox1;
    }
}
