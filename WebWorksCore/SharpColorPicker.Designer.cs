namespace SharpColorPicker
{
    partial class SharpColorPicker
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            H_Slider = new PictureBox();
            SV_Slider = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)H_Slider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SV_Slider).BeginInit();
            SuspendLayout();
            // 
            // H_Slider
            // 
            H_Slider.Location = new Point(0, 208);
            H_Slider.Margin = new Padding(4, 3, 4, 3);
            H_Slider.Name = "H_Slider";
            H_Slider.Size = new Size(248, 18);
            H_Slider.TabIndex = 3;
            H_Slider.TabStop = false;
            H_Slider.Paint += H_Slider_Paint;
            H_Slider.MouseMove += H_Slider_MouseMove;
            // 
            // SV_Slider
            // 
            SV_Slider.Location = new Point(0, 0);
            SV_Slider.Margin = new Padding(4, 3, 4, 3);
            SV_Slider.Name = "SV_Slider";
            SV_Slider.Size = new Size(248, 190);
            SV_Slider.TabIndex = 2;
            SV_Slider.TabStop = false;
            SV_Slider.Paint += SV_Slider_Paint;
            SV_Slider.MouseMove += SV_Slider_MouseMove;
            // 
            // SharpColorPicker
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(H_Slider);
            Controls.Add(SV_Slider);
            Margin = new Padding(4, 3, 4, 3);
            Name = "SharpColorPicker";
            Size = new Size(248, 226);
            ((System.ComponentModel.ISupportInitialize)H_Slider).EndInit();
            ((System.ComponentModel.ISupportInitialize)SV_Slider).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox H_Slider;
        private System.Windows.Forms.PictureBox SV_Slider;
    }
}
