namespace WebWorksCore.Updater
{
    partial class UpdateWindow
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
            Title_Label = new Label();
            label1 = new Label();
            richTextBox1 = new RichTextBox();
            button1 = new Button();
            label2 = new Label();
            button2 = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // Title_Label
            // 
            Title_Label.AutoSize = true;
            Title_Label.Font = new Font("Xeroda", 26.2499962F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Title_Label.ForeColor = SystemColors.Control;
            Title_Label.Location = new Point(0, 123);
            Title_Label.Name = "Title_Label";
            Title_Label.Size = new Size(265, 35);
            Title_Label.TabIndex = 0;
            Title_Label.Text = "Update Available!";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ButtonShadow;
            label1.Location = new Point(7, 158);
            label1.Name = "label1";
            label1.Size = new Size(435, 15);
            label1.TabIndex = 1;
            label1.Text = "New Version of WebWorks 1.x.x is Available. You currently have WebWorks v1.x.x.";
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.Black;
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.ForeColor = SystemColors.Control;
            richTextBox1.Location = new Point(7, 191);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(435, 195);
            richTextBox1.TabIndex = 2;
            richTextBox1.TabStop = false;
            richTextBox1.Text = "";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom;
            button1.Location = new Point(335, 392);
            button1.Name = "button1";
            button1.Size = new Size(101, 23);
            button1.TabIndex = 3;
            button1.Text = "Open in GitHub";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(7, 173);
            label2.Name = "label2";
            label2.Size = new Size(68, 15);
            label2.TabIndex = 4;
            label2.Text = "Changelog:";
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom;
            button2.Location = new Point(228, 392);
            button2.Name = "button2";
            button2.Size = new Size(101, 23);
            button2.TabIndex = 5;
            button2.Text = "Update Later";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.BackgroundImage = Properties.Resources.UpdateBanner;
            pictureBox1.BackgroundImageLayout = ImageLayout.Center;
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(448, 118);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // UpdateWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(448, 427);
            Controls.Add(pictureBox1);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(richTextBox1);
            Controls.Add(label1);
            Controls.Add(Title_Label);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UpdateWindow";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WebWorks Updater";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Title_Label;
        private Label label1;
        private RichTextBox richTextBox1;
        private Button button1;
        private Label label2;
        private Button button2;
        private PictureBox pictureBox1;
    }
}