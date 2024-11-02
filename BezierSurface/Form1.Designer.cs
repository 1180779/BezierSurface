namespace BezierSurface
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
            canvas = new PictureBox();
            groupBoxOptions = new GroupBox();
            textBoxBeta = new TextBox();
            textBoxAlpha = new TextBox();
            trackBarBeta = new TrackBar();
            trackBarAlpha = new TrackBar();
            textBoxTrianglesN = new TextBox();
            trackBarTrianglesN = new TrackBar();
            ((System.ComponentModel.ISupportInitialize)canvas).BeginInit();
            groupBoxOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarBeta).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarAlpha).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarTrianglesN).BeginInit();
            SuspendLayout();
            // 
            // canvas
            // 
            canvas.Location = new Point(3, 3);
            canvas.Name = "canvas";
            canvas.Size = new Size(661, 444);
            canvas.TabIndex = 0;
            canvas.TabStop = false;
            canvas.Paint += canvas_Paint;
            // 
            // groupBoxOptions
            // 
            groupBoxOptions.Controls.Add(textBoxBeta);
            groupBoxOptions.Controls.Add(textBoxAlpha);
            groupBoxOptions.Controls.Add(trackBarBeta);
            groupBoxOptions.Controls.Add(trackBarAlpha);
            groupBoxOptions.Controls.Add(textBoxTrianglesN);
            groupBoxOptions.Controls.Add(trackBarTrianglesN);
            groupBoxOptions.Location = new Point(670, 3);
            groupBoxOptions.Name = "groupBoxOptions";
            groupBoxOptions.Size = new Size(238, 444);
            groupBoxOptions.TabIndex = 1;
            groupBoxOptions.TabStop = false;
            groupBoxOptions.Text = "Options";
            // 
            // textBoxBeta
            // 
            textBoxBeta.Enabled = false;
            textBoxBeta.Location = new Point(6, 150);
            textBoxBeta.Name = "textBoxBeta";
            textBoxBeta.Size = new Size(50, 27);
            textBoxBeta.TabIndex = 5;
            // 
            // textBoxAlpha
            // 
            textBoxAlpha.Enabled = false;
            textBoxAlpha.Location = new Point(6, 88);
            textBoxAlpha.Name = "textBoxAlpha";
            textBoxAlpha.Size = new Size(50, 27);
            textBoxAlpha.TabIndex = 4;
            // 
            // trackBarBeta
            // 
            trackBarBeta.Location = new Point(62, 150);
            trackBarBeta.Maximum = 720;
            trackBarBeta.Name = "trackBarBeta";
            trackBarBeta.Size = new Size(170, 56);
            trackBarBeta.TabIndex = 3;
            trackBarBeta.Value = 180;
            trackBarBeta.Scroll += trackBarBeta_Scroll;
            // 
            // trackBarAlpha
            // 
            trackBarAlpha.Location = new Point(62, 88);
            trackBarAlpha.Maximum = 720;
            trackBarAlpha.Minimum = -720;
            trackBarAlpha.Name = "trackBarAlpha";
            trackBarAlpha.Size = new Size(170, 56);
            trackBarAlpha.TabIndex = 2;
            trackBarAlpha.Value = 180;
            trackBarAlpha.Scroll += trackBarAlpha_Scroll;
            // 
            // textBoxTrianglesN
            // 
            textBoxTrianglesN.Enabled = false;
            textBoxTrianglesN.Location = new Point(6, 26);
            textBoxTrianglesN.Name = "textBoxTrianglesN";
            textBoxTrianglesN.Size = new Size(50, 27);
            textBoxTrianglesN.TabIndex = 1;
            // 
            // trackBarTrianglesN
            // 
            trackBarTrianglesN.Location = new Point(62, 26);
            trackBarTrianglesN.Maximum = 32;
            trackBarTrianglesN.Minimum = 8;
            trackBarTrianglesN.Name = "trackBarTrianglesN";
            trackBarTrianglesN.Size = new Size(170, 56);
            trackBarTrianglesN.TabIndex = 0;
            trackBarTrianglesN.Value = 16;
            trackBarTrianglesN.Scroll += trackBarTrianglesN_Scroll;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(912, 450);
            Controls.Add(groupBoxOptions);
            Controls.Add(canvas);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)canvas).EndInit();
            groupBoxOptions.ResumeLayout(false);
            groupBoxOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarBeta).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarAlpha).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarTrianglesN).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox canvas;
        private GroupBox groupBoxOptions;
        private TextBox textBoxTrianglesN;
        private TrackBar trackBarTrianglesN;
        private TrackBar trackBarBeta;
        private TrackBar trackBarAlpha;
        private TextBox textBoxBeta;
        private TextBox textBoxAlpha;
    }
}
