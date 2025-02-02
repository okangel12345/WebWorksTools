namespace SpideyAtmos
{
    partial class SpideyAtmosForm
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
            AtmosphereValues_grid.Location = new Point(12, 41);
            AtmosphereValues_grid.Name = "AtmosphereValues_grid";
            AtmosphereValues_grid.Size = new Size(625, 554);
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
            textBox_AtmospherePath.Size = new Size(801, 23);
            textBox_AtmospherePath.TabIndex = 3;
            // 
            // AtmosphereHashes_grid
            // 
            AtmosphereHashes_grid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            AtmosphereHashes_grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            AtmosphereHashes_grid.Columns.AddRange(new DataGridViewColumn[] { Names_hashes, Hash_hashes, Extension_hashes, Address_hashes });
            AtmosphereHashes_grid.Location = new Point(643, 41);
            AtmosphereHashes_grid.Name = "AtmosphereHashes_grid";
            AtmosphereHashes_grid.Size = new Size(424, 554);
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
            // SpideyAtmosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(12, 12, 12);
            ClientSize = new Size(1079, 607);
            Controls.Add(AtmosphereHashes_grid);
            Controls.Add(textBox_AtmospherePath);
            Controls.Add(SaveAtmosphere_Button);
            Controls.Add(LoadAtmosphere_Button);
            Controls.Add(AtmosphereValues_grid);
            Name = "SpideyAtmosForm";
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
    }
}
