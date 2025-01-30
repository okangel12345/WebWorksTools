namespace WebWorks.Windows
{
    partial class InformationWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InformationWindow));
            panel1 = new Panel();
            label1 = new Label();
            richTextBox1 = new RichTextBox();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.BackgroundImage = FormIcons.WebWorks_IconBlue;
            panel1.BackgroundImageLayout = ImageLayout.Center;
            panel1.Location = new Point(607, 68);
            panel1.Name = "panel1";
            panel1.Size = new Size(508, 544);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Xeroda", 42F);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(3, 9);
            label1.Name = "label1";
            label1.Size = new Size(273, 56);
            label1.TabIndex = 1;
            label1.Text = "WebWorks";
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.Black;
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Font = new Font("Segoe UI", 11F);
            richTextBox1.ForeColor = SystemColors.Control;
            richTextBox1.Location = new Point(12, 68);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(589, 544);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = FormIcons.Github;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Location = new Point(551, 618);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(50, 50);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = FormIcons.Cross;
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Cursor = Cursors.Hand;
            pictureBox2.Location = new Point(1095, 9);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(20, 19);
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // InformationWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1127, 681);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(richTextBox1);
            Controls.Add(label1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "InformationWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WebWorks - Information";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private RichTextBox richTextBox1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}