namespace ModelToolsGUI
{
    partial class ModelToolGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModelToolGUI));
            groupBox1 = new GroupBox();
            label1 = new Label();
            AsciiToModel_StartButton = new Button();
            AsciiToModel_ComboBox = new ComboBox();
            AsciiToModel_ModelButton = new Button();
            AsciiToModel_MaterialsButton = new Button();
            AsciiToModel_AsciiButton = new Button();
            AsciiToModel_ModelTextBox = new TextBox();
            AsciiToModel_MaterialsTextBox = new TextBox();
            AsciiToModel_AsciiTextBox = new TextBox();
            groupBox2 = new GroupBox();
            label2 = new Label();
            ModelToAscii_StartButton = new Button();
            ModelToAscii_ComboBox = new ComboBox();
            ModelToAscii_AsciiButton = new Button();
            ModelToAscii_ModelButton = new Button();
            ModelToAscii_AsciiTextBox = new TextBox();
            ModelToAscii_ModelTextBox = new TextBox();
            groupBox3 = new GroupBox();
            RemoveHairStrands_StartButton = new Button();
            RemoveHairStrands_ModelButton = new Button();
            RemoveHairStrands_ModelTextBox = new TextBox();
            richTextBox1 = new RichTextBox();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(AsciiToModel_StartButton);
            groupBox1.Controls.Add(AsciiToModel_ComboBox);
            groupBox1.Controls.Add(AsciiToModel_ModelButton);
            groupBox1.Controls.Add(AsciiToModel_MaterialsButton);
            groupBox1.Controls.Add(AsciiToModel_AsciiButton);
            groupBox1.Controls.Add(AsciiToModel_ModelTextBox);
            groupBox1.Controls.Add(AsciiToModel_MaterialsTextBox);
            groupBox1.Controls.Add(AsciiToModel_AsciiTextBox);
            groupBox1.ForeColor = SystemColors.Control;
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(777, 148);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ascii to model";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(386, 118);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 9;
            label1.Text = "Game:";
            // 
            // AsciiToModel_StartButton
            // 
            AsciiToModel_StartButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            AsciiToModel_StartButton.ForeColor = SystemColors.ControlText;
            AsciiToModel_StartButton.Location = new Point(612, 109);
            AsciiToModel_StartButton.Name = "AsciiToModel_StartButton";
            AsciiToModel_StartButton.Size = new Size(159, 23);
            AsciiToModel_StartButton.TabIndex = 8;
            AsciiToModel_StartButton.Text = "Inject .ascii to .model";
            AsciiToModel_StartButton.UseVisualStyleBackColor = true;
            AsciiToModel_StartButton.Click += AsciiToModel_StartButton_Click;
            // 
            // AsciiToModel_ComboBox
            // 
            AsciiToModel_ComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            AsciiToModel_ComboBox.BackColor = Color.FromArgb(25, 25, 25);
            AsciiToModel_ComboBox.FlatStyle = FlatStyle.Flat;
            AsciiToModel_ComboBox.ForeColor = SystemColors.Control;
            AsciiToModel_ComboBox.FormattingEnabled = true;
            AsciiToModel_ComboBox.Items.AddRange(new object[] { "MSMR", "MSMM", "MSM2", "RCRA" });
            AsciiToModel_ComboBox.Location = new Point(433, 110);
            AsciiToModel_ComboBox.Name = "AsciiToModel_ComboBox";
            AsciiToModel_ComboBox.Size = new Size(173, 23);
            AsciiToModel_ComboBox.TabIndex = 7;
            // 
            // AsciiToModel_ModelButton
            // 
            AsciiToModel_ModelButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            AsciiToModel_ModelButton.ForeColor = SystemColors.ControlText;
            AsciiToModel_ModelButton.Location = new Point(612, 80);
            AsciiToModel_ModelButton.Name = "AsciiToModel_ModelButton";
            AsciiToModel_ModelButton.Size = new Size(159, 23);
            AsciiToModel_ModelButton.TabIndex = 6;
            AsciiToModel_ModelButton.Text = "Select .model...";
            AsciiToModel_ModelButton.UseVisualStyleBackColor = true;
            AsciiToModel_ModelButton.Click += AsciiToModel_ModelButton_Click;
            // 
            // AsciiToModel_MaterialsButton
            // 
            AsciiToModel_MaterialsButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            AsciiToModel_MaterialsButton.ForeColor = SystemColors.ControlText;
            AsciiToModel_MaterialsButton.Location = new Point(612, 51);
            AsciiToModel_MaterialsButton.Name = "AsciiToModel_MaterialsButton";
            AsciiToModel_MaterialsButton.Size = new Size(159, 23);
            AsciiToModel_MaterialsButton.TabIndex = 5;
            AsciiToModel_MaterialsButton.Text = "Select materials.txt...";
            AsciiToModel_MaterialsButton.UseVisualStyleBackColor = true;
            AsciiToModel_MaterialsButton.Click += AsciiToModel_MaterialsButton_Click;
            // 
            // AsciiToModel_AsciiButton
            // 
            AsciiToModel_AsciiButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            AsciiToModel_AsciiButton.ForeColor = SystemColors.ControlText;
            AsciiToModel_AsciiButton.Location = new Point(612, 22);
            AsciiToModel_AsciiButton.Name = "AsciiToModel_AsciiButton";
            AsciiToModel_AsciiButton.Size = new Size(159, 23);
            AsciiToModel_AsciiButton.TabIndex = 4;
            AsciiToModel_AsciiButton.Text = "Select .ascii...";
            AsciiToModel_AsciiButton.UseVisualStyleBackColor = true;
            AsciiToModel_AsciiButton.Click += AsciiToModel_AsciiButton_Click;
            // 
            // AsciiToModel_ModelTextBox
            // 
            AsciiToModel_ModelTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            AsciiToModel_ModelTextBox.BackColor = Color.FromArgb(30, 30, 30);
            AsciiToModel_ModelTextBox.BorderStyle = BorderStyle.None;
            AsciiToModel_ModelTextBox.ForeColor = SystemColors.Control;
            AsciiToModel_ModelTextBox.Location = new Point(6, 80);
            AsciiToModel_ModelTextBox.Name = "AsciiToModel_ModelTextBox";
            AsciiToModel_ModelTextBox.PlaceholderText = "path/to/file.model";
            AsciiToModel_ModelTextBox.Size = new Size(600, 16);
            AsciiToModel_ModelTextBox.TabIndex = 3;
            // 
            // AsciiToModel_MaterialsTextBox
            // 
            AsciiToModel_MaterialsTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            AsciiToModel_MaterialsTextBox.BackColor = Color.FromArgb(30, 30, 30);
            AsciiToModel_MaterialsTextBox.BorderStyle = BorderStyle.None;
            AsciiToModel_MaterialsTextBox.ForeColor = SystemColors.Control;
            AsciiToModel_MaterialsTextBox.Location = new Point(6, 51);
            AsciiToModel_MaterialsTextBox.Name = "AsciiToModel_MaterialsTextBox";
            AsciiToModel_MaterialsTextBox.PlaceholderText = "path/to/file_materials.txt";
            AsciiToModel_MaterialsTextBox.Size = new Size(600, 16);
            AsciiToModel_MaterialsTextBox.TabIndex = 2;
            // 
            // AsciiToModel_AsciiTextBox
            // 
            AsciiToModel_AsciiTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            AsciiToModel_AsciiTextBox.BackColor = Color.FromArgb(30, 30, 30);
            AsciiToModel_AsciiTextBox.BorderStyle = BorderStyle.None;
            AsciiToModel_AsciiTextBox.ForeColor = SystemColors.Control;
            AsciiToModel_AsciiTextBox.Location = new Point(6, 22);
            AsciiToModel_AsciiTextBox.Name = "AsciiToModel_AsciiTextBox";
            AsciiToModel_AsciiTextBox.PlaceholderText = "path/to/file.ascii";
            AsciiToModel_AsciiTextBox.Size = new Size(600, 16);
            AsciiToModel_AsciiTextBox.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(ModelToAscii_StartButton);
            groupBox2.Controls.Add(ModelToAscii_ComboBox);
            groupBox2.Controls.Add(ModelToAscii_AsciiButton);
            groupBox2.Controls.Add(ModelToAscii_ModelButton);
            groupBox2.Controls.Add(ModelToAscii_AsciiTextBox);
            groupBox2.Controls.Add(ModelToAscii_ModelTextBox);
            groupBox2.ForeColor = SystemColors.Control;
            groupBox2.Location = new Point(12, 174);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(777, 119);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Model to ascii...";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(386, 84);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 10;
            label2.Text = "Game:";
            // 
            // ModelToAscii_StartButton
            // 
            ModelToAscii_StartButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ModelToAscii_StartButton.ForeColor = SystemColors.ControlText;
            ModelToAscii_StartButton.Location = new Point(612, 80);
            ModelToAscii_StartButton.Name = "ModelToAscii_StartButton";
            ModelToAscii_StartButton.Size = new Size(159, 23);
            ModelToAscii_StartButton.TabIndex = 8;
            ModelToAscii_StartButton.Text = "Extract .model as .ascii";
            ModelToAscii_StartButton.UseVisualStyleBackColor = true;
            ModelToAscii_StartButton.Click += ModelToAscii_StartButton_Click;
            // 
            // ModelToAscii_ComboBox
            // 
            ModelToAscii_ComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ModelToAscii_ComboBox.BackColor = Color.FromArgb(25, 25, 25);
            ModelToAscii_ComboBox.FlatStyle = FlatStyle.Flat;
            ModelToAscii_ComboBox.ForeColor = SystemColors.Control;
            ModelToAscii_ComboBox.FormattingEnabled = true;
            ModelToAscii_ComboBox.Items.AddRange(new object[] { "MSMR", "MSMM", "MSM2", "RCRA" });
            ModelToAscii_ComboBox.Location = new Point(433, 80);
            ModelToAscii_ComboBox.Name = "ModelToAscii_ComboBox";
            ModelToAscii_ComboBox.Size = new Size(173, 23);
            ModelToAscii_ComboBox.TabIndex = 7;
            // 
            // ModelToAscii_AsciiButton
            // 
            ModelToAscii_AsciiButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ModelToAscii_AsciiButton.ForeColor = SystemColors.ControlText;
            ModelToAscii_AsciiButton.Location = new Point(612, 51);
            ModelToAscii_AsciiButton.Name = "ModelToAscii_AsciiButton";
            ModelToAscii_AsciiButton.Size = new Size(159, 23);
            ModelToAscii_AsciiButton.TabIndex = 5;
            ModelToAscii_AsciiButton.Text = "Select .ascii output...";
            ModelToAscii_AsciiButton.UseVisualStyleBackColor = true;
            ModelToAscii_AsciiButton.Click += ModelToAscii_AsciiButton_Click;
            // 
            // ModelToAscii_ModelButton
            // 
            ModelToAscii_ModelButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ModelToAscii_ModelButton.ForeColor = SystemColors.ControlText;
            ModelToAscii_ModelButton.Location = new Point(612, 22);
            ModelToAscii_ModelButton.Name = "ModelToAscii_ModelButton";
            ModelToAscii_ModelButton.Size = new Size(159, 23);
            ModelToAscii_ModelButton.TabIndex = 4;
            ModelToAscii_ModelButton.Text = "Select .model...";
            ModelToAscii_ModelButton.UseVisualStyleBackColor = true;
            ModelToAscii_ModelButton.Click += ModelToAscii_ModelButton_Click;
            // 
            // ModelToAscii_AsciiTextBox
            // 
            ModelToAscii_AsciiTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ModelToAscii_AsciiTextBox.BackColor = Color.FromArgb(30, 30, 30);
            ModelToAscii_AsciiTextBox.BorderStyle = BorderStyle.None;
            ModelToAscii_AsciiTextBox.ForeColor = SystemColors.Control;
            ModelToAscii_AsciiTextBox.Location = new Point(6, 51);
            ModelToAscii_AsciiTextBox.Name = "ModelToAscii_AsciiTextBox";
            ModelToAscii_AsciiTextBox.PlaceholderText = "path/to/file.ascii";
            ModelToAscii_AsciiTextBox.Size = new Size(600, 16);
            ModelToAscii_AsciiTextBox.TabIndex = 2;
            // 
            // ModelToAscii_ModelTextBox
            // 
            ModelToAscii_ModelTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ModelToAscii_ModelTextBox.BackColor = Color.FromArgb(30, 30, 30);
            ModelToAscii_ModelTextBox.BorderStyle = BorderStyle.None;
            ModelToAscii_ModelTextBox.ForeColor = SystemColors.Control;
            ModelToAscii_ModelTextBox.Location = new Point(6, 22);
            ModelToAscii_ModelTextBox.Name = "ModelToAscii_ModelTextBox";
            ModelToAscii_ModelTextBox.PlaceholderText = "path/to/file.model";
            ModelToAscii_ModelTextBox.Size = new Size(600, 16);
            ModelToAscii_ModelTextBox.TabIndex = 1;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(RemoveHairStrands_StartButton);
            groupBox3.Controls.Add(RemoveHairStrands_ModelButton);
            groupBox3.Controls.Add(RemoveHairStrands_ModelTextBox);
            groupBox3.ForeColor = SystemColors.Control;
            groupBox3.Location = new Point(12, 307);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(777, 88);
            groupBox3.TabIndex = 10;
            groupBox3.TabStop = false;
            groupBox3.Text = "Remove hair strands";
            // 
            // RemoveHairStrands_StartButton
            // 
            RemoveHairStrands_StartButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            RemoveHairStrands_StartButton.ForeColor = SystemColors.ControlText;
            RemoveHairStrands_StartButton.Location = new Point(612, 51);
            RemoveHairStrands_StartButton.Name = "RemoveHairStrands_StartButton";
            RemoveHairStrands_StartButton.Size = new Size(159, 23);
            RemoveHairStrands_StartButton.TabIndex = 8;
            RemoveHairStrands_StartButton.Text = "Remove hair strands";
            RemoveHairStrands_StartButton.UseVisualStyleBackColor = true;
            RemoveHairStrands_StartButton.Click += RemoveHairStrands_StartButton_Click;
            // 
            // RemoveHairStrands_ModelButton
            // 
            RemoveHairStrands_ModelButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            RemoveHairStrands_ModelButton.ForeColor = SystemColors.ControlText;
            RemoveHairStrands_ModelButton.Location = new Point(612, 22);
            RemoveHairStrands_ModelButton.Name = "RemoveHairStrands_ModelButton";
            RemoveHairStrands_ModelButton.Size = new Size(159, 23);
            RemoveHairStrands_ModelButton.TabIndex = 4;
            RemoveHairStrands_ModelButton.Text = "Select .model...";
            RemoveHairStrands_ModelButton.UseVisualStyleBackColor = true;
            RemoveHairStrands_ModelButton.Click += RemoveHairStrands_ModelButton_Click;
            // 
            // RemoveHairStrands_ModelTextBox
            // 
            RemoveHairStrands_ModelTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            RemoveHairStrands_ModelTextBox.BackColor = Color.FromArgb(30, 30, 30);
            RemoveHairStrands_ModelTextBox.BorderStyle = BorderStyle.None;
            RemoveHairStrands_ModelTextBox.ForeColor = SystemColors.Control;
            RemoveHairStrands_ModelTextBox.Location = new Point(6, 22);
            RemoveHairStrands_ModelTextBox.Name = "RemoveHairStrands_ModelTextBox";
            RemoveHairStrands_ModelTextBox.PlaceholderText = "path/to/file.model";
            RemoveHairStrands_ModelTextBox.Size = new Size(600, 16);
            RemoveHairStrands_ModelTextBox.TabIndex = 1;
            // 
            // richTextBox1
            // 
            richTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox1.BackColor = Color.Black;
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.ForeColor = SystemColors.ActiveBorder;
            richTextBox1.Location = new Point(795, 34);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(361, 692);
            richTextBox1.TabIndex = 11;
            richTextBox1.Text = "";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pictureBox1.BackgroundImage = ResourcesModelTools.ModelToolsGUI;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(12, 401);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(777, 467);
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(792, 12);
            label3.Name = "label3";
            label3.Size = new Size(30, 15);
            label3.TabIndex = 13;
            label3.Text = "Log:";
            // 
            // ModelToolGUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(12, 12, 12);
            ClientSize = new Size(1168, 738);
            Controls.Add(label3);
            Controls.Add(pictureBox1);
            Controls.Add(richTextBox1);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            ForeColor = SystemColors.Control;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ModelToolGUI";
            Text = "Model Tools GUI";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Button AsciiToModel_ModelButton;
        private Button AsciiToModel_MaterialsButton;
        private Button AsciiToModel_AsciiButton;
        private ComboBox AsciiToModel_ComboBox;
        private Button AsciiToModel_StartButton;
        private GroupBox groupBox2;
        private Button ModelToAscii_StartButton;
        private ComboBox ModelToAscii_ComboBox;
        private Button ModelToAscii_AsciiButton;
        private Button ModelToAscii_ModelButton;
        private TextBox ModelToAscii_AsciiTextBox;
        private TextBox ModelToAscii_ModelTextBox;
        private GroupBox groupBox3;
        private Button RemoveHairStrands_StartButton;
        private Button RemoveHairStrands_ModelButton;
        private TextBox RemoveHairStrands_ModelTextBox;
        private TextBox AsciiToModel_ModelTextBox;
        private TextBox AsciiToModel_MaterialsTextBox;
        private TextBox AsciiToModel_AsciiTextBox;
        public RichTextBox richTextBox1;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}
