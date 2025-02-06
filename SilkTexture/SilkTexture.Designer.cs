namespace SpideyTextureScaler
{
    partial class SpideyTexture
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpideyTexture));
            sourcebutton = new Button();
            bindingSource1 = new BindingSource(components);
            ddsbutton = new Button();
            outputbutton = new Button();
            generatebutton = new Button();
            dataGridView1 = new DataGridView();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            readyDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            widthDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            heightDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            mipmapsDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            hDMipmapsDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            Images = new DataGridViewTextBoxColumn();
            BytesPerPixel = new DataGridViewTextBoxColumn();
            sizeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            hDSizeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            formatDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            texturestatsBindingSource = new BindingSource(components);
            statusgroup = new GroupBox();
            outputbox = new TextBox();
            sourcelabel = new Label();
            ddslabel = new Label();
            outputlabel = new Label();
            testmode = new CheckBox();
            saveddsbutton = new Button();
            groupBox1 = new GroupBox();
            ddsfilenamelabel = new Label();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            hdlabel = new Label();
            label1 = new Label();
            extrasdctl = new NumericUpDown();
            ignoreformat = new CheckBox();
            groupBox4 = new GroupBox();
            label3 = new Label();
            numericUpDown_batchExtrasd = new NumericUpDown();
            checkBox_batchIgnoreFormat = new CheckBox();
            btn_batchFolderChoose = new Button();
            textBox_batchDefaultPath = new Label();
            checkBox_batchAllowSD = new CheckBox();
            btn_batchInjectDDS = new Button();
            btn_batchExtractDDS = new Button();
            data_Batch = new DataGridView();
            batchTexturePath = new DataGridViewTextBoxColumn();
            batchDDSPath = new DataGridViewTextBoxColumn();
            batchOutputDir = new DataGridViewTextBoxColumn();
            btn_batchClearRow = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)texturestatsBindingSource).BeginInit();
            statusgroup.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)extrasdctl).BeginInit();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_batchExtrasd).BeginInit();
            ((System.ComponentModel.ISupportInitialize)data_Batch).BeginInit();
            SuspendLayout();
            // 
            // sourcebutton
            // 
            sourcebutton.Location = new Point(14, 20);
            sourcebutton.Margin = new Padding(2);
            sourcebutton.Name = "sourcebutton";
            sourcebutton.Size = new Size(159, 24);
            sourcebutton.TabIndex = 0;
            sourcebutton.Text = "Import original .texture";
            sourcebutton.UseVisualStyleBackColor = true;
            sourcebutton.Click += sourcebutton_Click;
            // 
            // bindingSource1
            // 
            bindingSource1.DataSource = typeof(Program);
            // 
            // ddsbutton
            // 
            ddsbutton.Location = new Point(14, 20);
            ddsbutton.Margin = new Padding(2);
            ddsbutton.Name = "ddsbutton";
            ddsbutton.Size = new Size(159, 24);
            ddsbutton.TabIndex = 2;
            ddsbutton.Text = "Choose modded .dds texture";
            ddsbutton.UseVisualStyleBackColor = true;
            ddsbutton.Click += ddsbutton_Click;
            // 
            // outputbutton
            // 
            outputbutton.Location = new Point(14, 17);
            outputbutton.Margin = new Padding(2);
            outputbutton.Name = "outputbutton";
            outputbutton.Size = new Size(159, 24);
            outputbutton.TabIndex = 4;
            outputbutton.Text = "Choose output filename";
            outputbutton.UseVisualStyleBackColor = true;
            outputbutton.Click += outputbutton_Click;
            // 
            // generatebutton
            // 
            generatebutton.Enabled = false;
            generatebutton.Location = new Point(14, 50);
            generatebutton.Margin = new Padding(2);
            generatebutton.Name = "generatebutton";
            generatebutton.Size = new Size(159, 36);
            generatebutton.TabIndex = 6;
            generatebutton.Text = "Generate";
            generatebutton.UseVisualStyleBackColor = true;
            generatebutton.Click += generatebutton_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { nameDataGridViewTextBoxColumn, readyDataGridViewCheckBoxColumn, widthDataGridViewTextBoxColumn, heightDataGridViewTextBoxColumn, mipmapsDataGridViewTextBoxColumn, hDMipmapsDataGridViewTextBoxColumn, Images, BytesPerPixel, sizeDataGridViewTextBoxColumn, hDSizeDataGridViewTextBoxColumn, formatDataGridViewTextBoxColumn });
            dataGridView1.DataSource = texturestatsBindingSource;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new Point(14, 372);
            dataGridView1.Margin = new Padding(2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 72;
            dataGridView1.RowTemplate.Height = 37;
            dataGridView1.ShowEditingIcon = false;
            dataGridView1.Size = new Size(843, 84);
            dataGridView1.TabIndex = 7;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "";
            nameDataGridViewTextBoxColumn.MinimumWidth = 9;
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.ReadOnly = true;
            nameDataGridViewTextBoxColumn.Width = 19;
            // 
            // readyDataGridViewCheckBoxColumn
            // 
            readyDataGridViewCheckBoxColumn.DataPropertyName = "Ready";
            readyDataGridViewCheckBoxColumn.HeaderText = "Ready";
            readyDataGridViewCheckBoxColumn.MinimumWidth = 9;
            readyDataGridViewCheckBoxColumn.Name = "readyDataGridViewCheckBoxColumn";
            readyDataGridViewCheckBoxColumn.ReadOnly = true;
            readyDataGridViewCheckBoxColumn.Width = 45;
            // 
            // widthDataGridViewTextBoxColumn
            // 
            widthDataGridViewTextBoxColumn.DataPropertyName = "Width";
            widthDataGridViewTextBoxColumn.HeaderText = "Width";
            widthDataGridViewTextBoxColumn.MinimumWidth = 9;
            widthDataGridViewTextBoxColumn.Name = "widthDataGridViewTextBoxColumn";
            widthDataGridViewTextBoxColumn.ReadOnly = true;
            widthDataGridViewTextBoxColumn.Width = 64;
            // 
            // heightDataGridViewTextBoxColumn
            // 
            heightDataGridViewTextBoxColumn.DataPropertyName = "Height";
            heightDataGridViewTextBoxColumn.HeaderText = "Height";
            heightDataGridViewTextBoxColumn.MinimumWidth = 9;
            heightDataGridViewTextBoxColumn.Name = "heightDataGridViewTextBoxColumn";
            heightDataGridViewTextBoxColumn.ReadOnly = true;
            heightDataGridViewTextBoxColumn.Width = 68;
            // 
            // mipmapsDataGridViewTextBoxColumn
            // 
            mipmapsDataGridViewTextBoxColumn.DataPropertyName = "Mipmaps";
            mipmapsDataGridViewTextBoxColumn.HeaderText = "Mipmaps";
            mipmapsDataGridViewTextBoxColumn.MinimumWidth = 9;
            mipmapsDataGridViewTextBoxColumn.Name = "mipmapsDataGridViewTextBoxColumn";
            mipmapsDataGridViewTextBoxColumn.ReadOnly = true;
            mipmapsDataGridViewTextBoxColumn.Width = 82;
            // 
            // hDMipmapsDataGridViewTextBoxColumn
            // 
            hDMipmapsDataGridViewTextBoxColumn.DataPropertyName = "HDMipmaps";
            hDMipmapsDataGridViewTextBoxColumn.HeaderText = "HDMipmaps";
            hDMipmapsDataGridViewTextBoxColumn.MinimumWidth = 9;
            hDMipmapsDataGridViewTextBoxColumn.Name = "hDMipmapsDataGridViewTextBoxColumn";
            hDMipmapsDataGridViewTextBoxColumn.ReadOnly = true;
            hDMipmapsDataGridViewTextBoxColumn.Width = 99;
            // 
            // Images
            // 
            Images.DataPropertyName = "Images";
            Images.HeaderText = "Images";
            Images.MinimumWidth = 9;
            Images.Name = "Images";
            Images.ReadOnly = true;
            Images.Width = 70;
            // 
            // BytesPerPixel
            // 
            BytesPerPixel.DataPropertyName = "BytesPerPixel";
            BytesPerPixel.HeaderText = "BytesPerPixel";
            BytesPerPixel.MinimumWidth = 9;
            BytesPerPixel.Name = "BytesPerPixel";
            BytesPerPixel.ReadOnly = true;
            BytesPerPixel.Width = 102;
            // 
            // sizeDataGridViewTextBoxColumn
            // 
            sizeDataGridViewTextBoxColumn.DataPropertyName = "Size";
            sizeDataGridViewTextBoxColumn.HeaderText = "Size";
            sizeDataGridViewTextBoxColumn.MinimumWidth = 9;
            sizeDataGridViewTextBoxColumn.Name = "sizeDataGridViewTextBoxColumn";
            sizeDataGridViewTextBoxColumn.ReadOnly = true;
            sizeDataGridViewTextBoxColumn.Width = 52;
            // 
            // hDSizeDataGridViewTextBoxColumn
            // 
            hDSizeDataGridViewTextBoxColumn.DataPropertyName = "HDSize";
            hDSizeDataGridViewTextBoxColumn.HeaderText = "HDSize";
            hDSizeDataGridViewTextBoxColumn.MinimumWidth = 9;
            hDSizeDataGridViewTextBoxColumn.Name = "hDSizeDataGridViewTextBoxColumn";
            hDSizeDataGridViewTextBoxColumn.ReadOnly = true;
            hDSizeDataGridViewTextBoxColumn.Width = 69;
            // 
            // formatDataGridViewTextBoxColumn
            // 
            formatDataGridViewTextBoxColumn.DataPropertyName = "Format";
            formatDataGridViewTextBoxColumn.HeaderText = "Format";
            formatDataGridViewTextBoxColumn.MinimumWidth = 9;
            formatDataGridViewTextBoxColumn.Name = "formatDataGridViewTextBoxColumn";
            formatDataGridViewTextBoxColumn.ReadOnly = true;
            formatDataGridViewTextBoxColumn.Width = 70;
            // 
            // texturestatsBindingSource
            // 
            texturestatsBindingSource.DataMember = "texturestats";
            texturestatsBindingSource.DataSource = bindingSource1;
            // 
            // statusgroup
            // 
            statusgroup.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            statusgroup.Controls.Add(outputbox);
            statusgroup.ForeColor = SystemColors.Control;
            statusgroup.Location = new Point(203, 45);
            statusgroup.Margin = new Padding(2);
            statusgroup.Name = "statusgroup";
            statusgroup.Padding = new Padding(2);
            statusgroup.Size = new Size(631, 146);
            statusgroup.TabIndex = 8;
            statusgroup.TabStop = false;
            statusgroup.Text = "Log";
            // 
            // outputbox
            // 
            outputbox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            outputbox.BackColor = Color.FromArgb(22, 22, 22);
            outputbox.BorderStyle = BorderStyle.None;
            outputbox.ForeColor = SystemColors.Window;
            outputbox.Location = new Point(9, 20);
            outputbox.Margin = new Padding(2);
            outputbox.Multiline = true;
            outputbox.Name = "outputbox";
            outputbox.ReadOnly = true;
            outputbox.ScrollBars = ScrollBars.Vertical;
            outputbox.Size = new Size(613, 114);
            outputbox.TabIndex = 0;
            // 
            // sourcelabel
            // 
            sourcelabel.AutoSize = true;
            sourcelabel.ForeColor = SystemColors.Control;
            sourcelabel.Location = new Point(203, 25);
            sourcelabel.Margin = new Padding(2, 0, 2, 0);
            sourcelabel.Name = "sourcelabel";
            sourcelabel.Size = new Size(84, 15);
            sourcelabel.TabIndex = 9;
            sourcelabel.Text = "Choose a file...";
            // 
            // ddslabel
            // 
            ddslabel.AutoSize = true;
            ddslabel.ForeColor = SystemColors.Control;
            ddslabel.Location = new Point(203, 25);
            ddslabel.Margin = new Padding(2, 0, 2, 0);
            ddslabel.Name = "ddslabel";
            ddslabel.Size = new Size(84, 15);
            ddslabel.TabIndex = 9;
            ddslabel.Text = "Choose a file...";
            // 
            // outputlabel
            // 
            outputlabel.AutoSize = true;
            outputlabel.ForeColor = SystemColors.Control;
            outputlabel.Location = new Point(203, 22);
            outputlabel.Margin = new Padding(2, 0, 2, 0);
            outputlabel.Name = "outputlabel";
            outputlabel.Size = new Size(84, 15);
            outputlabel.TabIndex = 9;
            outputlabel.Text = "Choose a file...";
            // 
            // testmode
            // 
            testmode.AutoSize = true;
            testmode.ForeColor = SystemColors.Control;
            testmode.Location = new Point(14, 95);
            testmode.Margin = new Padding(2);
            testmode.Name = "testmode";
            testmode.Size = new Size(113, 19);
            testmode.TabIndex = 10;
            testmode.Text = "Don't replace SD";
            testmode.TextAlign = ContentAlignment.MiddleCenter;
            testmode.UseVisualStyleBackColor = true;
            // 
            // saveddsbutton
            // 
            saveddsbutton.Enabled = false;
            saveddsbutton.Location = new Point(14, 52);
            saveddsbutton.Margin = new Padding(2);
            saveddsbutton.Name = "saveddsbutton";
            saveddsbutton.Size = new Size(159, 24);
            saveddsbutton.TabIndex = 0;
            saveddsbutton.Text = "Save as .dds";
            saveddsbutton.UseVisualStyleBackColor = true;
            saveddsbutton.Click += saveddsbutton_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(ddsfilenamelabel);
            groupBox1.Controls.Add(sourcelabel);
            groupBox1.Controls.Add(saveddsbutton);
            groupBox1.Controls.Add(sourcebutton);
            groupBox1.Location = new Point(14, 12);
            groupBox1.Margin = new Padding(2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2);
            groupBox1.Size = new Size(843, 84);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Source";
            // 
            // ddsfilenamelabel
            // 
            ddsfilenamelabel.AutoSize = true;
            ddsfilenamelabel.Location = new Point(203, 56);
            ddsfilenamelabel.Margin = new Padding(2, 0, 2, 0);
            ddsfilenamelabel.Name = "ddsfilenamelabel";
            ddsfilenamelabel.Size = new Size(0, 15);
            ddsfilenamelabel.TabIndex = 9;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(ddslabel);
            groupBox2.Controls.Add(ddsbutton);
            groupBox2.Location = new Point(14, 100);
            groupBox2.Margin = new Padding(2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(2);
            groupBox2.Size = new Size(843, 60);
            groupBox2.TabIndex = 12;
            groupBox2.TabStop = false;
            groupBox2.Text = "Modified Texture";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(hdlabel);
            groupBox3.Controls.Add(label1);
            groupBox3.Controls.Add(extrasdctl);
            groupBox3.Controls.Add(ignoreformat);
            groupBox3.Controls.Add(statusgroup);
            groupBox3.Controls.Add(testmode);
            groupBox3.Controls.Add(outputlabel);
            groupBox3.Controls.Add(generatebutton);
            groupBox3.Controls.Add(outputbutton);
            groupBox3.Location = new Point(14, 164);
            groupBox3.Margin = new Padding(2);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(2);
            groupBox3.Size = new Size(843, 204);
            groupBox3.TabIndex = 13;
            groupBox3.TabStop = false;
            groupBox3.Text = "Modified Output";
            // 
            // hdlabel
            // 
            hdlabel.AutoSize = true;
            hdlabel.ForeColor = SystemColors.Control;
            hdlabel.Location = new Point(14, 169);
            hdlabel.Margin = new Padding(2, 0, 2, 0);
            hdlabel.Name = "hdlabel";
            hdlabel.Size = new Size(41, 15);
            hdlabel.TabIndex = 13;
            hdlabel.Text = "(0 HD)";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(13, 151);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(82, 15);
            label1.TabIndex = 12;
            label1.Text = "+SD mipmaps";
            // 
            // extrasdctl
            // 
            extrasdctl.Enabled = false;
            extrasdctl.Location = new Point(99, 151);
            extrasdctl.Margin = new Padding(2);
            extrasdctl.Maximum = new decimal(new int[] { 0, 0, 0, 0 });
            extrasdctl.Name = "extrasdctl";
            extrasdctl.Size = new Size(71, 23);
            extrasdctl.TabIndex = 11;
            extrasdctl.ValueChanged += extrasdctl_ValueChanged;
            // 
            // ignoreformat
            // 
            ignoreformat.AutoSize = true;
            ignoreformat.ForeColor = SystemColors.Control;
            ignoreformat.Location = new Point(13, 120);
            ignoreformat.Margin = new Padding(2);
            ignoreformat.Name = "ignoreformat";
            ignoreformat.Size = new Size(157, 19);
            ignoreformat.TabIndex = 10;
            ignoreformat.Text = "Ignore Format difference";
            ignoreformat.TextAlign = ContentAlignment.MiddleCenter;
            ignoreformat.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox4.Controls.Add(label3);
            groupBox4.Controls.Add(numericUpDown_batchExtrasd);
            groupBox4.Controls.Add(checkBox_batchIgnoreFormat);
            groupBox4.Controls.Add(btn_batchFolderChoose);
            groupBox4.Controls.Add(textBox_batchDefaultPath);
            groupBox4.Controls.Add(checkBox_batchAllowSD);
            groupBox4.Controls.Add(btn_batchInjectDDS);
            groupBox4.Controls.Add(btn_batchExtractDDS);
            groupBox4.Controls.Add(data_Batch);
            groupBox4.Location = new Point(14, 461);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(843, 276);
            groupBox4.TabIndex = 14;
            groupBox4.TabStop = false;
            groupBox4.Text = "Batch conversion";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(188, 54);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(99, 15);
            label3.TabIndex = 14;
            label3.Text = "Add SD mipmaps";
            // 
            // numericUpDown_batchExtrasd
            // 
            numericUpDown_batchExtrasd.Location = new Point(292, 50);
            numericUpDown_batchExtrasd.Name = "numericUpDown_batchExtrasd";
            numericUpDown_batchExtrasd.Size = new Size(52, 23);
            numericUpDown_batchExtrasd.TabIndex = 8;
            // 
            // checkBox_batchIgnoreFormat
            // 
            checkBox_batchIgnoreFormat.AutoSize = true;
            checkBox_batchIgnoreFormat.ForeColor = SystemColors.Control;
            checkBox_batchIgnoreFormat.Location = new Point(93, 52);
            checkBox_batchIgnoreFormat.Name = "checkBox_batchIgnoreFormat";
            checkBox_batchIgnoreFormat.Size = new Size(99, 19);
            checkBox_batchIgnoreFormat.TabIndex = 7;
            checkBox_batchIgnoreFormat.Text = "Ignore format";
            checkBox_batchIgnoreFormat.UseVisualStyleBackColor = true;
            // 
            // btn_batchFolderChoose
            // 
            btn_batchFolderChoose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_batchFolderChoose.Location = new Point(718, 22);
            btn_batchFolderChoose.Name = "btn_batchFolderChoose";
            btn_batchFolderChoose.Size = new Size(116, 23);
            btn_batchFolderChoose.TabIndex = 6;
            btn_batchFolderChoose.Text = "Select a folder";
            btn_batchFolderChoose.UseVisualStyleBackColor = true;
            btn_batchFolderChoose.Click += btn_batchFolderChoose_Click;
            // 
            // textBox_batchDefaultPath
            // 
            textBox_batchDefaultPath.AutoSize = true;
            textBox_batchDefaultPath.ForeColor = SystemColors.Control;
            textBox_batchDefaultPath.Location = new Point(350, 26);
            textBox_batchDefaultPath.Name = "textBox_batchDefaultPath";
            textBox_batchDefaultPath.Size = new Size(200, 15);
            textBox_batchDefaultPath.TabIndex = 5;
            textBox_batchDefaultPath.Text = "Choose a common output diretory...";
            // 
            // checkBox_batchAllowSD
            // 
            checkBox_batchAllowSD.AutoSize = true;
            checkBox_batchAllowSD.ForeColor = SystemColors.Control;
            checkBox_batchAllowSD.Location = new Point(14, 52);
            checkBox_batchAllowSD.Name = "checkBox_batchAllowSD";
            checkBox_batchAllowSD.Size = new Size(73, 19);
            checkBox_batchAllowSD.TabIndex = 4;
            checkBox_batchAllowSD.Text = "Allow SD";
            checkBox_batchAllowSD.UseVisualStyleBackColor = true;
            // 
            // btn_batchInjectDDS
            // 
            btn_batchInjectDDS.Location = new Point(13, 22);
            btn_batchInjectDDS.Name = "btn_batchInjectDDS";
            btn_batchInjectDDS.Size = new Size(160, 23);
            btn_batchInjectDDS.TabIndex = 2;
            btn_batchInjectDDS.Text = "Inject DDS to texture";
            btn_batchInjectDDS.UseVisualStyleBackColor = true;
            btn_batchInjectDDS.Click += btn_batchInjectDDS_Click;
            // 
            // btn_batchExtractDDS
            // 
            btn_batchExtractDDS.Location = new Point(176, 22);
            btn_batchExtractDDS.Name = "btn_batchExtractDDS";
            btn_batchExtractDDS.Size = new Size(168, 23);
            btn_batchExtractDDS.TabIndex = 1;
            btn_batchExtractDDS.Text = "Extract DDS from texture";
            btn_batchExtractDDS.UseVisualStyleBackColor = true;
            btn_batchExtractDDS.Click += btn_batchExtractDDS_Click;
            // 
            // data_Batch
            // 
            data_Batch.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            data_Batch.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            data_Batch.Columns.AddRange(new DataGridViewColumn[] { batchTexturePath, batchDDSPath, batchOutputDir, btn_batchClearRow });
            data_Batch.Location = new Point(14, 81);
            data_Batch.Name = "data_Batch";
            data_Batch.Size = new Size(820, 189);
            data_Batch.TabIndex = 0;
            data_Batch.CellClick += data_Batch_CellClick;
            data_Batch.CellDoubleClick += data_Batch_CellDoubleClick;
            // 
            // batchTexturePath
            // 
            batchTexturePath.HeaderText = "Texture";
            batchTexturePath.Name = "batchTexturePath";
            batchTexturePath.Width = 240;
            // 
            // batchDDSPath
            // 
            batchDDSPath.HeaderText = "DDS file";
            batchDDSPath.Name = "batchDDSPath";
            batchDDSPath.Width = 240;
            // 
            // batchOutputDir
            // 
            batchOutputDir.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            batchOutputDir.HeaderText = "Custom output directory";
            batchOutputDir.Name = "batchOutputDir";
            // 
            // btn_batchClearRow
            // 
            btn_batchClearRow.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            btn_batchClearRow.DefaultCellStyle = dataGridViewCellStyle2;
            btn_batchClearRow.FlatStyle = FlatStyle.Flat;
            btn_batchClearRow.HeaderText = "Clear";
            btn_batchClearRow.Name = "btn_batchClearRow";
            btn_batchClearRow.ReadOnly = true;
            btn_batchClearRow.Text = "Clear";
            btn_batchClearRow.Width = 40;
            // 
            // SpideyTexture
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(22, 22, 22);
            ClientSize = new Size(869, 749);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(dataGridView1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            MinimumSize = new Size(640, 607);
            Name = "SpideyTexture";
            Text = "SpideyTextureScaler";
            Load += SpideyTexture_Load;
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)texturestatsBindingSource).EndInit();
            statusgroup.ResumeLayout(false);
            statusgroup.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)extrasdctl).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_batchExtrasd).EndInit();
            ((System.ComponentModel.ISupportInitialize)data_Batch).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button sourcebutton;
        private Button ddsbutton;
        private Button outputbutton;
        private Button generatebutton;
        private BindingSource bindingSource1;
        private DataGridView dataGridView1;
        private BindingSource texturestatsBindingSource;
        private GroupBox statusgroup;
        private TextBox outputbox;
        private Label sourcelabel;
        private Label ddslabel;
        private Label outputlabel;
        private CheckBox testmode;
        private Button saveddsbutton;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label ddsfilenamelabel;
        private CheckBox ignoreformat;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn readyDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn widthDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn heightDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn mipmapsDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn hDMipmapsDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn Images;
        private DataGridViewTextBoxColumn BytesPerPixel;
        private DataGridViewTextBoxColumn sizeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn hDSizeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn formatDataGridViewTextBoxColumn;
        private Label hdlabel;
        private Label label1;
        private NumericUpDown extrasdctl;
        private GroupBox groupBox4;
        private DataGridView data_Batch;
        private Button btn_batchExtractDDS;
        private Button btn_batchInjectDDS;
        private CheckBox checkBox_batchAllowSD;
        private Label textBox_batchDefaultPath;
        private DataGridViewTextBoxColumn batchTexturePath;
        private DataGridViewTextBoxColumn batchDDSPath;
        private DataGridViewTextBoxColumn batchOutputDir;
        private DataGridViewButtonColumn btn_batchClearRow;
        private Button btn_batchFolderChoose;
        private CheckBox checkBox_batchIgnoreFormat;
        private NumericUpDown numericUpDown_batchExtrasd;
        private Label label3;
    }
}
