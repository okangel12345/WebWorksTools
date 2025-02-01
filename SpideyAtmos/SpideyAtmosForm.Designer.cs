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
            EnvironmentLighting_grid = new DataGridView();
            Names = new DataGridViewTextBoxColumn();
            Value = new DataGridViewTextBoxColumn();
            Type = new DataGridViewTextBoxColumn();
            Description = new DataGridViewTextBoxColumn();
            LoadAtmosphere_Button = new Button();
            SaveAtmosphere_Button = new Button();
            textBox_AtmospherePath = new TextBox();
            ((System.ComponentModel.ISupportInitialize)EnvironmentLighting_grid).BeginInit();
            SuspendLayout();
            // 
            // EnvironmentLighting_grid
            // 
            EnvironmentLighting_grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            EnvironmentLighting_grid.Columns.AddRange(new DataGridViewColumn[] { Names, Value, Type, Description });
            EnvironmentLighting_grid.Location = new Point(12, 41);
            EnvironmentLighting_grid.Name = "EnvironmentLighting_grid";
            EnvironmentLighting_grid.Size = new Size(504, 554);
            EnvironmentLighting_grid.TabIndex = 0;
            // 
            // Names
            // 
            Names.HeaderText = "Names";
            Names.Name = "Names";
            // 
            // Value
            // 
            Value.HeaderText = "Value";
            Value.Name = "Value";
            // 
            // Type
            // 
            Type.HeaderText = "Type";
            Type.Name = "Type";
            // 
            // Description
            // 
            Description.HeaderText = "Description";
            Description.Name = "Description";
            // 
            // LoadAtmosphere_Button
            // 
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
            textBox_AtmospherePath.Location = new Point(12, 12);
            textBox_AtmospherePath.Name = "textBox_AtmospherePath";
            textBox_AtmospherePath.Size = new Size(801, 23);
            textBox_AtmospherePath.TabIndex = 3;
            // 
            // SpideyAtmosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(12, 12, 12);
            ClientSize = new Size(1079, 607);
            Controls.Add(textBox_AtmospherePath);
            Controls.Add(SaveAtmosphere_Button);
            Controls.Add(LoadAtmosphere_Button);
            Controls.Add(EnvironmentLighting_grid);
            Name = "SpideyAtmosForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)EnvironmentLighting_grid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView EnvironmentLighting_grid;
        private Button LoadAtmosphere_Button;
        private Button SaveAtmosphere_Button;
        private DataGridViewTextBoxColumn Names;
        private DataGridViewTextBoxColumn Value;
        private DataGridViewTextBoxColumn Type;
        private DataGridViewTextBoxColumn Description;
        private TextBox textBox_AtmospherePath;
    }
}
