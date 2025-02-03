namespace WeatherTuner
{
    partial class WeatherTunerForm
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
            AtmosphereValues_grid = new DataGridView();
            Names = new DataGridViewTextBoxColumn();
            Type = new DataGridViewTextBoxColumn();
            Value = new DataGridViewTextBoxColumn();
            Description = new DataGridViewTextBoxColumn();
            Offset = new DataGridViewTextBoxColumn();
            LoadAtmosphere_Button = new Button();
            SaveAtmosphere_Button = new Button();
            textBox_AtmospherePath = new TextBox();
            AtmosphereHashes_grid = new DataGridView();
            Names_hashes = new DataGridViewTextBoxColumn();
            Hash_hashes = new DataGridViewTextBoxColumn();
            Extension_hashes = new DataGridViewTextBoxColumn();
            Address_hashes = new DataGridViewTextBoxColumn();
            Search_Textbox = new TextBox();
            checkBox_Normalize = new CheckBox();
            label3 = new Label();
            textBox_Hash2 = new TextBox();
            label2 = new Label();
            textBox_Hash1 = new TextBox();
            label1 = new Label();
            textBox_Path1 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)AtmosphereValues_grid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AtmosphereHashes_grid).BeginInit();
            SuspendLayout();
            // 
            // AtmosphereValues_grid
            // 
            AtmosphereValues_grid.AllowUserToAddRows = false;
            AtmosphereValues_grid.AllowUserToDeleteRows = false;
            AtmosphereValues_grid.AllowUserToResizeRows = false;
            AtmosphereValues_grid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            AtmosphereValues_grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            AtmosphereValues_grid.Columns.AddRange(new DataGridViewColumn[] { Names, Type, Value, Description, Offset });
            AtmosphereValues_grid.Location = new Point(12, 70);
            AtmosphereValues_grid.Name = "AtmosphereValues_grid";
            AtmosphereValues_grid.Size = new Size(625, 525);
            AtmosphereValues_grid.TabIndex = 0;
            // 
            // Names
            // 
            Names.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Names.HeaderText = "Names";
            Names.Name = "Names";
            Names.ReadOnly = true;
            Names.Width = 200;
            // 
            // Type
            // 
            Type.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Type.HeaderText = "Type";
            Type.Name = "Type";
            Type.ReadOnly = true;
            Type.Width = 50;
            // 
            // Value
            // 
            Value.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Value.HeaderText = "Value";
            Value.Name = "Value";
            Value.Width = 125;
            // 
            // Description
            // 
            Description.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Description.HeaderText = "Description";
            Description.Name = "Description";
            Description.ReadOnly = true;
            // 
            // Offset
            // 
            Offset.HeaderText = "Offset";
            Offset.Name = "Offset";
            Offset.Visible = false;
            // 
            // LoadAtmosphere_Button
            // 
            LoadAtmosphere_Button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            LoadAtmosphere_Button.Location = new Point(819, 12);
            LoadAtmosphere_Button.Name = "LoadAtmosphere_Button";
            LoadAtmosphere_Button.Size = new Size(121, 23);
            LoadAtmosphere_Button.TabIndex = 1;
            LoadAtmosphere_Button.Text = "Load .atmosphere";
            LoadAtmosphere_Button.UseVisualStyleBackColor = true;
            LoadAtmosphere_Button.Click += LoadAtmosphere_Button_Click;
            // 
            // SaveAtmosphere_Button
            // 
            SaveAtmosphere_Button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SaveAtmosphere_Button.Location = new Point(946, 12);
            SaveAtmosphere_Button.Name = "SaveAtmosphere_Button";
            SaveAtmosphere_Button.Size = new Size(121, 23);
            SaveAtmosphere_Button.TabIndex = 2;
            SaveAtmosphere_Button.Text = "Save .atmosphere";
            SaveAtmosphere_Button.UseVisualStyleBackColor = true;
            SaveAtmosphere_Button.Click += SaveAtmosphere_Button_Click;
            // 
            // textBox_AtmospherePath
            // 
            textBox_AtmospherePath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_AtmospherePath.BackColor = Color.FromArgb(22, 22, 22);
            textBox_AtmospherePath.BorderStyle = BorderStyle.FixedSingle;
            textBox_AtmospherePath.ForeColor = SystemColors.ActiveBorder;
            textBox_AtmospherePath.Location = new Point(12, 12);
            textBox_AtmospherePath.Name = "textBox_AtmospherePath";
            textBox_AtmospherePath.PlaceholderText = "Atmosphere path...";
            textBox_AtmospherePath.Size = new Size(801, 23);
            textBox_AtmospherePath.TabIndex = 3;
            // 
            // AtmosphereHashes_grid
            // 
            AtmosphereHashes_grid.AllowUserToAddRows = false;
            AtmosphereHashes_grid.AllowUserToDeleteRows = false;
            AtmosphereHashes_grid.AllowUserToResizeRows = false;
            AtmosphereHashes_grid.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            AtmosphereHashes_grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            AtmosphereHashes_grid.Columns.AddRange(new DataGridViewColumn[] { Names_hashes, Hash_hashes, Extension_hashes, Address_hashes });
            AtmosphereHashes_grid.Location = new Point(643, 41);
            AtmosphereHashes_grid.Name = "AtmosphereHashes_grid";
            AtmosphereHashes_grid.RowHeadersVisible = false;
            AtmosphereHashes_grid.Size = new Size(424, 297);
            AtmosphereHashes_grid.TabIndex = 4;
            // 
            // Names_hashes
            // 
            Names_hashes.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Names_hashes.HeaderText = "Names";
            Names_hashes.Name = "Names_hashes";
            Names_hashes.Width = 150;
            // 
            // Hash_hashes
            // 
            Hash_hashes.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Hash_hashes.HeaderText = "Hashed Path";
            Hash_hashes.Name = "Hash_hashes";
            // 
            // Extension_hashes
            // 
            Extension_hashes.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Extension_hashes.HeaderText = "Hashed Extension";
            Extension_hashes.Name = "Extension_hashes";
            // 
            // Address_hashes
            // 
            Address_hashes.HeaderText = "Address_hashes";
            Address_hashes.Name = "Address_hashes";
            Address_hashes.Visible = false;
            // 
            // Search_Textbox
            // 
            Search_Textbox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Search_Textbox.BackColor = Color.FromArgb(22, 22, 22);
            Search_Textbox.BorderStyle = BorderStyle.FixedSingle;
            Search_Textbox.ForeColor = SystemColors.ActiveBorder;
            Search_Textbox.Location = new Point(12, 41);
            Search_Textbox.Name = "Search_Textbox";
            Search_Textbox.PlaceholderText = "Search...";
            Search_Textbox.Size = new Size(625, 23);
            Search_Textbox.TabIndex = 6;
            Search_Textbox.KeyUp += Search_Textbox_KeyUp;
            // 
            // checkBox_Normalize
            // 
            checkBox_Normalize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkBox_Normalize.AutoSize = true;
            checkBox_Normalize.Location = new Point(922, 388);
            checkBox_Normalize.Name = "checkBox_Normalize";
            checkBox_Normalize.Size = new Size(80, 19);
            checkBox_Normalize.TabIndex = 15;
            checkBox_Normalize.Text = "Normalize";
            checkBox_Normalize.UseVisualStyleBackColor = true;
            checkBox_Normalize.Visible = false;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ButtonShadow;
            label3.Location = new Point(641, 437);
            label3.Name = "label3";
            label3.Size = new Size(110, 15);
            label3.TabIndex = 14;
            label3.Text = "Hashed Extension...";
            label3.Visible = false;
            // 
            // textBox_Hash2
            // 
            textBox_Hash2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox_Hash2.BackColor = Color.FromArgb(22, 22, 22);
            textBox_Hash2.BorderStyle = BorderStyle.FixedSingle;
            textBox_Hash2.ForeColor = SystemColors.Window;
            textBox_Hash2.Location = new Point(644, 457);
            textBox_Hash2.Name = "textBox_Hash2";
            textBox_Hash2.ReadOnly = true;
            textBox_Hash2.Size = new Size(358, 23);
            textBox_Hash2.TabIndex = 13;
            textBox_Hash2.Visible = false;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ButtonShadow;
            label2.Location = new Point(641, 389);
            label2.Name = "label2";
            label2.Size = new Size(83, 15);
            label2.TabIndex = 12;
            label2.Text = "Hashed Path...";
            label2.Visible = false;
            // 
            // textBox_Hash1
            // 
            textBox_Hash1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox_Hash1.BackColor = Color.FromArgb(22, 22, 22);
            textBox_Hash1.BorderStyle = BorderStyle.FixedSingle;
            textBox_Hash1.ForeColor = SystemColors.Window;
            textBox_Hash1.Location = new Point(644, 409);
            textBox_Hash1.Name = "textBox_Hash1";
            textBox_Hash1.ReadOnly = true;
            textBox_Hash1.Size = new Size(358, 23);
            textBox_Hash1.TabIndex = 11;
            textBox_Hash1.Visible = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(641, 341);
            label1.Name = "label1";
            label1.Size = new Size(34, 15);
            label1.TabIndex = 10;
            label1.Text = "Path:";
            label1.Visible = false;
            // 
            // textBox_Path1
            // 
            textBox_Path1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox_Path1.BackColor = Color.FromArgb(22, 22, 22);
            textBox_Path1.BorderStyle = BorderStyle.FixedSingle;
            textBox_Path1.ForeColor = SystemColors.Window;
            textBox_Path1.Location = new Point(644, 361);
            textBox_Path1.Name = "textBox_Path1";
            textBox_Path1.PlaceholderText = "Path to .texture, .material, etc.";
            textBox_Path1.Size = new Size(424, 23);
            textBox_Path1.TabIndex = 9;
            textBox_Path1.Visible = false;
            textBox_Path1.TextChanged += textBox_Path1_TextChanged;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Location = new Point(1008, 409);
            button1.Name = "button1";
            button1.Size = new Size(60, 23);
            button1.TabIndex = 16;
            button1.Text = "Copy";
            button1.UseVisualStyleBackColor = true;
            button1.Visible = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.Location = new Point(1008, 457);
            button2.Name = "button2";
            button2.Size = new Size(60, 23);
            button2.TabIndex = 17;
            button2.Text = "Copy";
            button2.UseVisualStyleBackColor = true;
            button2.Visible = false;
            button2.Click += button2_Click;
            // 
            // WeatherTunerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(12, 12, 12);
            ClientSize = new Size(1079, 607);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(checkBox_Normalize);
            Controls.Add(label3);
            Controls.Add(textBox_Hash2);
            Controls.Add(label2);
            Controls.Add(textBox_Hash1);
            Controls.Add(label1);
            Controls.Add(textBox_Path1);
            Controls.Add(Search_Textbox);
            Controls.Add(AtmosphereHashes_grid);
            Controls.Add(textBox_AtmospherePath);
            Controls.Add(SaveAtmosphere_Button);
            Controls.Add(LoadAtmosphere_Button);
            Controls.Add(AtmosphereValues_grid);
            Name = "WeatherTunerForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)AtmosphereValues_grid).EndInit();
            ((System.ComponentModel.ISupportInitialize)AtmosphereHashes_grid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button LoadAtmosphere_Button;
        private Button SaveAtmosphere_Button;
        private TextBox textBox_AtmospherePath;
        public DataGridView AtmosphereValues_grid;
        private DataGridViewTextBoxColumn Names;
        private DataGridViewTextBoxColumn Type;
        private DataGridViewTextBoxColumn Value;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewTextBoxColumn Offset;
        public DataGridView AtmosphereHashes_grid;
        private DataGridViewTextBoxColumn Names_hashes;
        private DataGridViewTextBoxColumn Hash_hashes;
        private DataGridViewTextBoxColumn Extension_hashes;
        private DataGridViewTextBoxColumn Address_hashes;
        private TextBox Search_Textbox;
        private CheckBox checkBox_Normalize;
        private Label label3;
        private TextBox textBox_Hash2;
        private Label label2;
        private TextBox textBox_Hash1;
        private Label label1;
        private TextBox textBox_Path1;
        private Button button1;
        private Button button2;
    }
}
