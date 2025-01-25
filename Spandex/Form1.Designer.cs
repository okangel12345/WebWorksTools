namespace Spandex
{
    partial class Form1
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
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle16 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle22 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle23 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle24 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle17 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle18 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle19 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle20 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle21 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            openbutton = new Button();
            savebutton = new Button();
            stringGrid = new DataGridView();
            IDdisplay = new DataGridViewTextBoxColumn();
            InternalValue = new DataGridViewTextBoxColumn();
            Value = new DataGridViewTextBoxColumn();
            TemplateValue = new DataGridViewTextBoxColumn();
            spanDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            iDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            iDdisplayDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            typeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            valueDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            internalValueDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            templateValueDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            stringGridEntryBindingSource = new BindingSource(components);
            bindingSource2 = new BindingSource(components);
            valueGrid = new DataGridView();
            iDdisplayDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            Type = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            valueDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            templateValueDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            valueGridBindingSource = new BindingSource(components);
            panel1 = new Panel();
            checkBox_Autocompletion = new CheckBox();
            label2 = new Label();
            label1 = new Label();
            checkBox_UniversalHeader = new CheckBox();
            textBox_FileLoaded = new TextBox();
            button1 = new Button();
            comboBox1 = new ComboBox();
            removeUndefInts = new CheckBox();
            removeUndefFloats = new CheckBox();
            removeUndefTextures = new CheckBox();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            statusLabel = new ToolStripStatusLabel();
            splitContainer1 = new SplitContainer();
            ((System.ComponentModel.ISupportInitialize)stringGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)stringGridEntryBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)valueGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)valueGridBindingSource).BeginInit();
            panel1.SuspendLayout();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // openbutton
            // 
            openbutton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            openbutton.BackColor = Color.FromArgb(64, 64, 64);
            openbutton.FlatAppearance.BorderColor = SystemColors.ActiveCaptionText;
            openbutton.FlatStyle = FlatStyle.Flat;
            openbutton.ForeColor = Color.White;
            openbutton.Location = new Point(867, 2);
            openbutton.Margin = new Padding(2);
            openbutton.Name = "openbutton";
            openbutton.Size = new Size(126, 24);
            openbutton.TabIndex = 0;
            openbutton.Text = "Load Material...";
            openbutton.UseVisualStyleBackColor = true;
            openbutton.Click += openbutton_Click;
            // 
            // savebutton
            // 
            savebutton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            savebutton.BackColor = Color.FromArgb(64, 64, 64);
            savebutton.Enabled = false;
            savebutton.FlatAppearance.BorderColor = Color.Black;
            savebutton.FlatStyle = FlatStyle.Flat;
            savebutton.ForeColor = SystemColors.Control;
            savebutton.Location = new Point(997, 3);
            savebutton.Margin = new Padding(2);
            savebutton.Name = "savebutton";
            savebutton.Size = new Size(126, 24);
            savebutton.TabIndex = 0;
            savebutton.Text = "Save Material As...";
            savebutton.UseVisualStyleBackColor = false;
            savebutton.Click += savebutton_Click;
            // 
            // stringGrid
            // 
            stringGrid.AllowUserToAddRows = false;
            stringGrid.AllowUserToDeleteRows = false;
            stringGrid.AllowUserToOrderColumns = true;
            stringGrid.AllowUserToResizeRows = false;
            stringGrid.AutoGenerateColumns = false;
            stringGrid.BackgroundColor = Color.FromArgb(17, 17, 17);
            stringGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            stringGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            stringGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            stringGrid.Columns.AddRange(new DataGridViewColumn[] { IDdisplay, InternalValue, Value, TemplateValue, spanDataGridViewTextBoxColumn, iDDataGridViewTextBoxColumn, iDdisplayDataGridViewTextBoxColumn1, typeDataGridViewTextBoxColumn, valueDataGridViewTextBoxColumn1, internalValueDataGridViewTextBoxColumn, templateValueDataGridViewTextBoxColumn1 });
            stringGrid.DataSource = stringGridEntryBindingSource;
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = Color.Black;
            dataGridViewCellStyle13.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle13.ForeColor = SystemColors.Control;
            dataGridViewCellStyle13.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = DataGridViewTriState.False;
            stringGrid.DefaultCellStyle = dataGridViewCellStyle13;
            stringGrid.Dock = DockStyle.Fill;
            stringGrid.EnableHeadersVisualStyles = false;
            stringGrid.GridColor = SystemColors.ActiveCaptionText;
            stringGrid.Location = new Point(0, 0);
            stringGrid.Margin = new Padding(9, 8, 9, 8);
            stringGrid.MinimumSize = new Size(636, 119);
            stringGrid.Name = "stringGrid";
            dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = Color.Black;
            dataGridViewCellStyle14.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle14.ForeColor = SystemColors.Window;
            dataGridViewCellStyle14.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = DataGridViewTriState.True;
            stringGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            stringGrid.RowHeadersVisible = false;
            stringGrid.RowHeadersWidth = 72;
            dataGridViewCellStyle15.BackColor = Color.Black;
            dataGridViewCellStyle15.ForeColor = Color.White;
            stringGrid.RowsDefaultCellStyle = dataGridViewCellStyle15;
            stringGrid.RowTemplate.DefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            stringGrid.RowTemplate.DefaultCellStyle.ForeColor = Color.White;
            stringGrid.RowTemplate.Height = 37;
            stringGrid.Size = new Size(1121, 334);
            stringGrid.TabIndex = 1;
            stringGrid.CellBeginEdit += stringGrid_CellBeginEdit;
            stringGrid.CellContentClick += stringGrid_CellContentClick;
            stringGrid.CellValueChanged += stringGrid_CellValueChanged;
            stringGrid.DataBindingComplete += stringGrid_DataBindingComplete;
            // 
            // IDdisplay
            // 
            IDdisplay.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            IDdisplay.DataPropertyName = "IDdisplay";
            dataGridViewCellStyle2.BackColor = Color.FromArgb(21, 21, 21);
            dataGridViewCellStyle2.ForeColor = Color.White;
            IDdisplay.DefaultCellStyle = dataGridViewCellStyle2;
            IDdisplay.HeaderText = "ID";
            IDdisplay.MinimumWidth = 9;
            IDdisplay.Name = "IDdisplay";
            IDdisplay.ReadOnly = true;
            IDdisplay.Width = 42;
            // 
            // InternalValue
            // 
            InternalValue.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            InternalValue.DataPropertyName = "InternalValue";
            dataGridViewCellStyle3.BackColor = Color.FromArgb(21, 21, 21);
            dataGridViewCellStyle3.ForeColor = Color.White;
            InternalValue.DefaultCellStyle = dataGridViewCellStyle3;
            InternalValue.HeaderText = "Internal Shader";
            InternalValue.MinimumWidth = 9;
            InternalValue.Name = "InternalValue";
            InternalValue.Width = 101;
            // 
            // Value
            // 
            Value.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Value.DataPropertyName = "Value";
            dataGridViewCellStyle4.BackColor = Color.FromArgb(21, 21, 21);
            dataGridViewCellStyle4.ForeColor = Color.White;
            Value.DefaultCellStyle = dataGridViewCellStyle4;
            Value.HeaderText = "External Template Overrides";
            Value.MinimumWidth = 9;
            Value.Name = "Value";
            Value.Width = 161;
            // 
            // TemplateValue
            // 
            TemplateValue.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            TemplateValue.DataPropertyName = "TemplateValue";
            dataGridViewCellStyle5.BackColor = Color.FromArgb(21, 21, 21);
            dataGridViewCellStyle5.ForeColor = Color.RosyBrown;
            TemplateValue.DefaultCellStyle = dataGridViewCellStyle5;
            TemplateValue.HeaderText = "External Template Defaults";
            TemplateValue.MinimumWidth = 9;
            TemplateValue.Name = "TemplateValue";
            TemplateValue.ReadOnly = true;
            TemplateValue.Width = 155;
            // 
            // spanDataGridViewTextBoxColumn
            // 
            spanDataGridViewTextBoxColumn.DataPropertyName = "Span";
            dataGridViewCellStyle6.BackColor = Color.FromArgb(21, 21, 21);
            dataGridViewCellStyle6.ForeColor = Color.White;
            spanDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            spanDataGridViewTextBoxColumn.HeaderText = "Span";
            spanDataGridViewTextBoxColumn.Name = "spanDataGridViewTextBoxColumn";
            spanDataGridViewTextBoxColumn.Visible = false;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            dataGridViewCellStyle7.BackColor = Color.FromArgb(21, 21, 21);
            dataGridViewCellStyle7.ForeColor = Color.White;
            iDDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            iDDataGridViewTextBoxColumn.HeaderText = "ID";
            iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // iDdisplayDataGridViewTextBoxColumn1
            // 
            iDdisplayDataGridViewTextBoxColumn1.DataPropertyName = "IDdisplay";
            dataGridViewCellStyle8.BackColor = Color.FromArgb(21, 21, 21);
            dataGridViewCellStyle8.ForeColor = Color.White;
            iDdisplayDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle8;
            iDdisplayDataGridViewTextBoxColumn1.HeaderText = "IDdisplay";
            iDdisplayDataGridViewTextBoxColumn1.Name = "iDdisplayDataGridViewTextBoxColumn1";
            iDdisplayDataGridViewTextBoxColumn1.Visible = false;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            dataGridViewCellStyle9.BackColor = Color.FromArgb(21, 21, 21);
            dataGridViewCellStyle9.ForeColor = Color.White;
            typeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            typeDataGridViewTextBoxColumn.HeaderText = "Type";
            typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            typeDataGridViewTextBoxColumn.Visible = false;
            // 
            // valueDataGridViewTextBoxColumn1
            // 
            valueDataGridViewTextBoxColumn1.DataPropertyName = "Value";
            dataGridViewCellStyle10.BackColor = Color.FromArgb(21, 21, 21);
            dataGridViewCellStyle10.ForeColor = Color.White;
            valueDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle10;
            valueDataGridViewTextBoxColumn1.HeaderText = "Value";
            valueDataGridViewTextBoxColumn1.Name = "valueDataGridViewTextBoxColumn1";
            valueDataGridViewTextBoxColumn1.Visible = false;
            // 
            // internalValueDataGridViewTextBoxColumn
            // 
            internalValueDataGridViewTextBoxColumn.DataPropertyName = "InternalValue";
            dataGridViewCellStyle11.BackColor = Color.FromArgb(21, 21, 21);
            dataGridViewCellStyle11.ForeColor = Color.White;
            internalValueDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            internalValueDataGridViewTextBoxColumn.HeaderText = "InternalValue";
            internalValueDataGridViewTextBoxColumn.Name = "internalValueDataGridViewTextBoxColumn";
            internalValueDataGridViewTextBoxColumn.Visible = false;
            // 
            // templateValueDataGridViewTextBoxColumn1
            // 
            templateValueDataGridViewTextBoxColumn1.DataPropertyName = "TemplateValue";
            dataGridViewCellStyle12.BackColor = Color.FromArgb(21, 21, 21);
            dataGridViewCellStyle12.ForeColor = Color.White;
            templateValueDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle12;
            templateValueDataGridViewTextBoxColumn1.HeaderText = "TemplateValue";
            templateValueDataGridViewTextBoxColumn1.Name = "templateValueDataGridViewTextBoxColumn1";
            templateValueDataGridViewTextBoxColumn1.Visible = false;
            // 
            // stringGridEntryBindingSource
            // 
            stringGridEntryBindingSource.DataSource = typeof(GridEntry);
            // 
            // valueGrid
            // 
            valueGrid.AllowUserToAddRows = false;
            valueGrid.AllowUserToDeleteRows = false;
            valueGrid.AllowUserToResizeRows = false;
            valueGrid.AutoGenerateColumns = false;
            valueGrid.BackgroundColor = Color.FromArgb(17, 17, 17);
            valueGrid.BorderStyle = BorderStyle.None;
            valueGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
            valueGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle16.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle16.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle16.ForeColor = SystemColors.Window;
            dataGridViewCellStyle16.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = DataGridViewTriState.True;
            valueGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            valueGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            valueGrid.Columns.AddRange(new DataGridViewColumn[] { iDdisplayDataGridViewTextBoxColumn, Type, dataGridViewTextBoxColumn1, valueDataGridViewTextBoxColumn, templateValueDataGridViewTextBoxColumn });
            valueGrid.DataSource = valueGridBindingSource;
            dataGridViewCellStyle22.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle22.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle22.ForeColor = SystemColors.Control;
            dataGridViewCellStyle22.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = DataGridViewTriState.False;
            valueGrid.DefaultCellStyle = dataGridViewCellStyle22;
            valueGrid.Dock = DockStyle.Fill;
            valueGrid.EnableHeadersVisualStyles = false;
            valueGrid.GridColor = SystemColors.ActiveCaptionText;
            valueGrid.Location = new Point(0, 0);
            valueGrid.Margin = new Padding(9, 8, 9, 8);
            valueGrid.MinimumSize = new Size(338, 116);
            valueGrid.Name = "valueGrid";
            dataGridViewCellStyle23.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle23.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle23.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle23.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = DataGridViewTriState.True;
            valueGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle23;
            valueGrid.RowHeadersVisible = false;
            valueGrid.RowHeadersWidth = 72;
            dataGridViewCellStyle24.BackColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle24.ForeColor = Color.White;
            valueGrid.RowsDefaultCellStyle = dataGridViewCellStyle24;
            valueGrid.RowTemplate.DefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            valueGrid.RowTemplate.DefaultCellStyle.ForeColor = Color.White;
            valueGrid.RowTemplate.Height = 37;
            valueGrid.Size = new Size(1121, 370);
            valueGrid.TabIndex = 3;
            valueGrid.CellPainting += valueGrid_CellPainting;
            valueGrid.DataBindingComplete += valueGrid_DataBindingComplete;
            // 
            // iDdisplayDataGridViewTextBoxColumn
            // 
            iDdisplayDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            iDdisplayDataGridViewTextBoxColumn.DataPropertyName = "IDdisplay";
            dataGridViewCellStyle17.BackColor = Color.FromArgb(21, 21, 21);
            dataGridViewCellStyle17.ForeColor = Color.White;
            iDdisplayDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle17;
            iDdisplayDataGridViewTextBoxColumn.HeaderText = "ID";
            iDdisplayDataGridViewTextBoxColumn.MinimumWidth = 9;
            iDdisplayDataGridViewTextBoxColumn.Name = "iDdisplayDataGridViewTextBoxColumn";
            iDdisplayDataGridViewTextBoxColumn.ReadOnly = true;
            iDdisplayDataGridViewTextBoxColumn.Width = 42;
            // 
            // Type
            // 
            Type.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Type.DataPropertyName = "Type";
            dataGridViewCellStyle18.BackColor = Color.FromArgb(21, 21, 21);
            dataGridViewCellStyle18.ForeColor = Color.White;
            Type.DefaultCellStyle = dataGridViewCellStyle18;
            Type.HeaderText = "Type";
            Type.MinimumWidth = 9;
            Type.Name = "Type";
            Type.ReadOnly = true;
            Type.Width = 55;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewTextBoxColumn1.DataPropertyName = "InternalValue";
            dataGridViewCellStyle19.BackColor = Color.FromArgb(21, 21, 21);
            dataGridViewCellStyle19.ForeColor = Color.White;
            dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle19;
            dataGridViewTextBoxColumn1.HeaderText = "Internal Shader";
            dataGridViewTextBoxColumn1.MinimumWidth = 9;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 101;
            // 
            // valueDataGridViewTextBoxColumn
            // 
            valueDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            dataGridViewCellStyle20.BackColor = Color.FromArgb(21, 21, 21);
            dataGridViewCellStyle20.ForeColor = Color.White;
            valueDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle20;
            valueDataGridViewTextBoxColumn.HeaderText = "External Template Overrides";
            valueDataGridViewTextBoxColumn.MinimumWidth = 9;
            valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            valueDataGridViewTextBoxColumn.Width = 161;
            // 
            // templateValueDataGridViewTextBoxColumn
            // 
            templateValueDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            templateValueDataGridViewTextBoxColumn.DataPropertyName = "TemplateValue";
            dataGridViewCellStyle21.BackColor = Color.FromArgb(21, 21, 21);
            dataGridViewCellStyle21.ForeColor = SystemColors.ControlDark;
            templateValueDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle21;
            templateValueDataGridViewTextBoxColumn.HeaderText = "External Template Default";
            templateValueDataGridViewTextBoxColumn.MinimumWidth = 9;
            templateValueDataGridViewTextBoxColumn.Name = "templateValueDataGridViewTextBoxColumn";
            templateValueDataGridViewTextBoxColumn.ReadOnly = true;
            templateValueDataGridViewTextBoxColumn.Width = 150;
            // 
            // valueGridBindingSource
            // 
            valueGridBindingSource.DataSource = typeof(GridEntry);
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.BackColor = Color.FromArgb(12, 12, 12);
            panel1.Controls.Add(checkBox_Autocompletion);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(checkBox_UniversalHeader);
            panel1.Controls.Add(textBox_FileLoaded);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(removeUndefInts);
            panel1.Controls.Add(removeUndefFloats);
            panel1.Controls.Add(removeUndefTextures);
            panel1.Controls.Add(openbutton);
            panel1.Controls.Add(savebutton);
            panel1.Location = new Point(11, 11);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1125, 59);
            panel1.TabIndex = 4;
            // 
            // checkBox_Autocompletion
            // 
            checkBox_Autocompletion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkBox_Autocompletion.AutoSize = true;
            checkBox_Autocompletion.ForeColor = SystemColors.ActiveBorder;
            checkBox_Autocompletion.Location = new Point(867, 31);
            checkBox_Autocompletion.Margin = new Padding(2);
            checkBox_Autocompletion.Name = "checkBox_Autocompletion";
            checkBox_Autocompletion.Size = new Size(133, 19);
            checkBox_Autocompletion.TabIndex = 10;
            checkBox_Autocompletion.Text = "Autocomplete fields";
            checkBox_Autocompletion.UseVisualStyleBackColor = true;
            checkBox_Autocompletion.CheckedChanged += checkBox_Autocompletion_CheckedChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.ForeColor = Color.FromArgb(210, 210, 210);
            label2.Location = new Point(511, 32);
            label2.Name = "label2";
            label2.Size = new Size(141, 15);
            label2.TabIndex = 9;
            label2.Text = "Remove undefined (Red):";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.FromArgb(120, 120, 120);
            label1.Location = new Point(-2, 34);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 8;
            label1.Text = "120, 120, 120";
            label1.Visible = false;
            // 
            // checkBox_UniversalHeader
            // 
            checkBox_UniversalHeader.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkBox_UniversalHeader.AutoSize = true;
            checkBox_UniversalHeader.ForeColor = SystemColors.ActiveBorder;
            checkBox_UniversalHeader.Location = new Point(1008, 31);
            checkBox_UniversalHeader.Margin = new Padding(2);
            checkBox_UniversalHeader.Name = "checkBox_UniversalHeader";
            checkBox_UniversalHeader.Size = new Size(115, 19);
            checkBox_UniversalHeader.TabIndex = 7;
            checkBox_UniversalHeader.Text = "Universal Header";
            checkBox_UniversalHeader.UseVisualStyleBackColor = true;
            // 
            // textBox_FileLoaded
            // 
            textBox_FileLoaded.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_FileLoaded.BackColor = Color.FromArgb(22, 22, 22);
            textBox_FileLoaded.BorderStyle = BorderStyle.FixedSingle;
            textBox_FileLoaded.ForeColor = Color.FromArgb(120, 120, 120);
            textBox_FileLoaded.Location = new Point(1, 3);
            textBox_FileLoaded.Name = "textBox_FileLoaded";
            textBox_FileLoaded.ReadOnly = true;
            textBox_FileLoaded.Size = new Size(861, 23);
            textBox_FileLoaded.TabIndex = 6;
            textBox_FileLoaded.Text = "Load a material first...";
            // 
            // button1
            // 
            button1.AccessibleName = "folderButton";
            button1.BackColor = Color.FromArgb(64, 64, 64);
            button1.FlatAppearance.BorderColor = Color.Black;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(60, 212);
            button1.Name = "button1";
            button1.Size = new Size(160, 23);
            button1.TabIndex = 5;
            button1.Text = "Batch Convert to Game";
            button1.UseVisualStyleBackColor = false;
            button1.Click += folderButton_Click;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = Color.FromArgb(26, 26, 26);
            comboBox1.ForeColor = SystemColors.Window;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(10, 158);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(257, 23);
            comboBox1.TabIndex = 4;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // removeUndefInts
            // 
            removeUndefInts.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            removeUndefInts.AutoSize = true;
            removeUndefInts.ForeColor = SystemColors.ActiveBorder;
            removeUndefInts.Location = new Point(791, 31);
            removeUndefInts.Margin = new Padding(2);
            removeUndefInts.Name = "removeUndefInts";
            removeUndefInts.Size = new Size(68, 19);
            removeUndefInts.TabIndex = 3;
            removeUndefInts.Text = "Integers";
            removeUndefInts.UseVisualStyleBackColor = true;
            // 
            // removeUndefFloats
            // 
            removeUndefFloats.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            removeUndefFloats.AutoSize = true;
            removeUndefFloats.ForeColor = SystemColors.ActiveBorder;
            removeUndefFloats.Location = new Point(730, 31);
            removeUndefFloats.Margin = new Padding(2);
            removeUndefFloats.Name = "removeUndefFloats";
            removeUndefFloats.Size = new Size(57, 19);
            removeUndefFloats.TabIndex = 3;
            removeUndefFloats.Text = "Floats";
            removeUndefFloats.UseVisualStyleBackColor = true;
            // 
            // removeUndefTextures
            // 
            removeUndefTextures.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            removeUndefTextures.AutoSize = true;
            removeUndefTextures.ForeColor = SystemColors.ActiveBorder;
            removeUndefTextures.Location = new Point(657, 31);
            removeUndefTextures.Margin = new Padding(2);
            removeUndefTextures.Name = "removeUndefTextures";
            removeUndefTextures.Size = new Size(69, 19);
            removeUndefTextures.TabIndex = 3;
            removeUndefTextures.Text = "Textures";
            removeUndefTextures.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = Color.FromArgb(20, 20, 20);
            statusStrip1.ImageScalingSize = new Size(28, 28);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, statusLabel });
            statusStrip1.Location = new Point(0, 753);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 8, 0);
            statusStrip1.Size = new Size(1148, 37);
            statusStrip1.TabIndex = 5;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Font = new Font("Segoe UI", 9F);
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(0, 32);
            // 
            // statusLabel
            // 
            statusLabel.Image = Properties.Resources.ok;
            statusLabel.Margin = new Padding(8, 5, 0, 4);
            statusLabel.Name = "statusLabel";
            statusLabel.Padding = new Padding(10, 0, 0, 0);
            statusLabel.Size = new Size(38, 28);
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(12, 42);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(valueGrid);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(stringGrid);
            splitContainer1.Size = new Size(1121, 708);
            splitContainer1.SplitterDistance = 370;
            splitContainer1.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.FromArgb(12, 12, 12);
            ClientSize = new Size(1148, 790);
            Controls.Add(splitContainer1);
            Controls.Add(panel1);
            Controls.Add(statusStrip1);
            ForeColor = SystemColors.Control;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            MinimumSize = new Size(701, 389);
            Name = "Form1";
            Text = "Spandex Luna";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)stringGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)stringGridEntryBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource2).EndInit();
            ((System.ComponentModel.ISupportInitialize)valueGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)valueGridBindingSource).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button openbutton;
        private Button savebutton;
        private DataGridView stringGrid;
        private BindingSource bindingSource1;
        private DataGridViewTextBoxColumn sourceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn assetPathDataGridViewTextBoxColumn;
        private BindingSource bindingSource2;
        private BindingSource stringGridEntryBindingSource;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridView valueGrid;
        private BindingSource valueGridBindingSource;
        private DataGridViewTextBoxColumn templateTypeDataGridViewTextBoxColumn;
        private Panel panel1;
        private CheckBox removeUndefInts;
        private CheckBox removeUndefFloats;
        private CheckBox removeUndefTextures;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel statusLabel;
        private DataGridViewTextBoxColumn iDdisplayDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn Type;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn templateValueDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn IDdisplay;
        private DataGridViewTextBoxColumn InternalValue;
        private DataGridViewTextBoxColumn Value;
        private DataGridViewTextBoxColumn TemplateValue;
        private DataGridViewTextBoxColumn spanDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn iDdisplayDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn internalValueDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn templateValueDataGridViewTextBoxColumn1;
        private ComboBox comboBox1;
        private Button button1;
        private SplitContainer splitContainer1;
        private TextBox textBox_FileLoaded;
        private CheckBox checkBox_UniversalHeader;
        private Label label1;
        private Label label2;
        private CheckBox checkBox_Autocompletion;
    }
}
