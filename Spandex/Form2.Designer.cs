namespace Spandex
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            searchBox = new TextBox();
            resultlist = new ListBox();
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // searchBox
            // 
            searchBox.BackColor = Color.FromArgb(22, 22, 22);
            searchBox.BorderStyle = BorderStyle.FixedSingle;
            searchBox.ForeColor = SystemColors.Window;
            searchBox.Location = new Point(12, 12);
            searchBox.Name = "searchBox";
            searchBox.Size = new Size(776, 23);
            searchBox.TabIndex = 0;
            searchBox.TextChanged += searchBox_TextChanged;
            // 
            // resultlist
            // 
            resultlist.BackColor = Color.FromArgb(22, 22, 22);
            resultlist.BorderStyle = BorderStyle.None;
            resultlist.ForeColor = Color.FromArgb(210, 210, 210);
            resultlist.FormattingEnabled = true;
            resultlist.ItemHeight = 15;
            resultlist.Location = new Point(12, 60);
            resultlist.Name = "resultlist";
            resultlist.Size = new Size(776, 345);
            resultlist.TabIndex = 1;
            resultlist.SelectedIndexChanged += resultlist_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(684, 415);
            button1.Name = "button1";
            button1.Size = new Size(104, 27);
            button1.TabIndex = 2;
            button1.Text = "Ok";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(574, 415);
            button2.Name = "button2";
            button2.Size = new Size(104, 27);
            button2.TabIndex = 3;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ActiveBorder;
            label1.Location = new Point(10, 43);
            label1.Name = "label1";
            label1.Size = new Size(208, 15);
            label1.TabIndex = 4;
            label1.Text = "Available textures and materialgraphs:";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(12, 12, 12);
            ClientSize = new Size(800, 455);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(resultlist);
            Controls.Add(searchBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form2";
            Text = "Search";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private TextBox searchBox;
        private ListBox resultlist;
        private Button button1;
        private Button button2;
        private Label label1;
    }
}