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
            groupBoxLight = new GroupBox();
            textBoxParameter = new TextBox();
            trackBarParameter = new TrackBar();
            pictureBoxLightColor = new PictureBox();
            buttonLightColor = new Button();
            groupBoxSurface = new GroupBox();
            pictureBoxSurfaceColor = new PictureBox();
            buttonSurfaceColor = new Button();
            checkBoxDrawSurface = new CheckBox();
            checkBoxDrawTriangles = new CheckBox();
            checkBoxDrawControls = new CheckBox();
            groupBoxM = new GroupBox();
            trackBarM = new TrackBar();
            textBoxM = new TextBox();
            groupBoxKS = new GroupBox();
            trackBarKS = new TrackBar();
            textBoxKS = new TextBox();
            groupBoxKD = new GroupBox();
            trackBarKD = new TrackBar();
            textBoxKD = new TextBox();
            groupBoxBeta = new GroupBox();
            trackBarBeta = new TrackBar();
            textBoxBeta = new TextBox();
            groupBoxAlpha = new GroupBox();
            trackBarAlpha = new TrackBar();
            textBoxAlpha = new TextBox();
            groupBox1 = new GroupBox();
            trackBarTrianglesN = new TrackBar();
            textBoxTrianglesN = new TextBox();
            ((System.ComponentModel.ISupportInitialize)canvas).BeginInit();
            groupBoxOptions.SuspendLayout();
            groupBoxLight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarParameter).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLightColor).BeginInit();
            groupBoxSurface.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSurfaceColor).BeginInit();
            groupBoxM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarM).BeginInit();
            groupBoxKS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarKS).BeginInit();
            groupBoxKD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarKD).BeginInit();
            groupBoxBeta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarBeta).BeginInit();
            groupBoxAlpha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarAlpha).BeginInit();
            groupBox1.SuspendLayout();
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
            // 
            // groupBoxOptions
            // 
            groupBoxOptions.Controls.Add(groupBoxLight);
            groupBoxOptions.Controls.Add(groupBoxSurface);
            groupBoxOptions.Controls.Add(groupBoxM);
            groupBoxOptions.Controls.Add(groupBoxKS);
            groupBoxOptions.Controls.Add(groupBoxKD);
            groupBoxOptions.Controls.Add(groupBoxBeta);
            groupBoxOptions.Controls.Add(groupBoxAlpha);
            groupBoxOptions.Controls.Add(groupBox1);
            groupBoxOptions.Location = new Point(670, 12);
            groupBoxOptions.Name = "groupBoxOptions";
            groupBoxOptions.Size = new Size(454, 547);
            groupBoxOptions.TabIndex = 1;
            groupBoxOptions.TabStop = false;
            groupBoxOptions.Text = "Opcje";
            // 
            // groupBoxLight
            // 
            groupBoxLight.Controls.Add(textBoxParameter);
            groupBoxLight.Controls.Add(trackBarParameter);
            groupBoxLight.Controls.Add(pictureBoxLightColor);
            groupBoxLight.Controls.Add(buttonLightColor);
            groupBoxLight.Location = new Point(6, 215);
            groupBoxLight.Name = "groupBoxLight";
            groupBoxLight.Size = new Size(186, 171);
            groupBoxLight.TabIndex = 22;
            groupBoxLight.TabStop = false;
            groupBoxLight.Text = "światło";
            // 
            // textBoxParameter
            // 
            textBoxParameter.Enabled = false;
            textBoxParameter.Location = new Point(8, 87);
            textBoxParameter.Name = "textBoxParameter";
            textBoxParameter.Size = new Size(50, 27);
            textBoxParameter.TabIndex = 10;
            // 
            // trackBarParameter
            // 
            trackBarParameter.Location = new Point(64, 87);
            trackBarParameter.Maximum = 100;
            trackBarParameter.Name = "trackBarParameter";
            trackBarParameter.Size = new Size(116, 56);
            trackBarParameter.TabIndex = 10;
            trackBarParameter.Value = 50;
            trackBarParameter.Scroll += trackBarParameter_Scroll;
            // 
            // pictureBoxLightColor
            // 
            pictureBoxLightColor.Location = new Point(126, 26);
            pictureBoxLightColor.Name = "pictureBoxLightColor";
            pictureBoxLightColor.Size = new Size(54, 55);
            pictureBoxLightColor.TabIndex = 5;
            pictureBoxLightColor.TabStop = false;
            // 
            // buttonLightColor
            // 
            buttonLightColor.Location = new Point(9, 26);
            buttonLightColor.Name = "buttonLightColor";
            buttonLightColor.Size = new Size(114, 55);
            buttonLightColor.TabIndex = 5;
            buttonLightColor.Text = "Zmień kolor";
            buttonLightColor.UseVisualStyleBackColor = true;
            buttonLightColor.Click += buttonLightColor_Click;
            // 
            // groupBoxSurface
            // 
            groupBoxSurface.Controls.Add(pictureBoxSurfaceColor);
            groupBoxSurface.Controls.Add(buttonSurfaceColor);
            groupBoxSurface.Controls.Add(checkBoxDrawSurface);
            groupBoxSurface.Controls.Add(checkBoxDrawTriangles);
            groupBoxSurface.Controls.Add(checkBoxDrawControls);
            groupBoxSurface.Location = new Point(6, 31);
            groupBoxSurface.Name = "groupBoxSurface";
            groupBoxSurface.Size = new Size(186, 178);
            groupBoxSurface.TabIndex = 21;
            groupBoxSurface.TabStop = false;
            groupBoxSurface.Text = "opcje powierzchni";
            // 
            // pictureBoxSurfaceColor
            // 
            pictureBoxSurfaceColor.Location = new Point(126, 116);
            pictureBoxSurfaceColor.Name = "pictureBoxSurfaceColor";
            pictureBoxSurfaceColor.Size = new Size(54, 55);
            pictureBoxSurfaceColor.TabIndex = 4;
            pictureBoxSurfaceColor.TabStop = false;
            // 
            // buttonSurfaceColor
            // 
            buttonSurfaceColor.Location = new Point(6, 116);
            buttonSurfaceColor.Name = "buttonSurfaceColor";
            buttonSurfaceColor.Size = new Size(114, 55);
            buttonSurfaceColor.TabIndex = 3;
            buttonSurfaceColor.Text = "Zmień kolor";
            buttonSurfaceColor.UseVisualStyleBackColor = true;
            buttonSurfaceColor.Click += buttonSurfaceColor_Click;
            // 
            // checkBoxDrawSurface
            // 
            checkBoxDrawSurface.AutoSize = true;
            checkBoxDrawSurface.Location = new Point(6, 86);
            checkBoxDrawSurface.Name = "checkBoxDrawSurface";
            checkBoxDrawSurface.Size = new Size(117, 24);
            checkBoxDrawSurface.TabIndex = 2;
            checkBoxDrawSurface.Text = "Powierzchnia";
            checkBoxDrawSurface.UseVisualStyleBackColor = true;
            checkBoxDrawSurface.CheckedChanged += checkBoxDrawSurface_CheckedChanged;
            // 
            // checkBoxDrawTriangles
            // 
            checkBoxDrawTriangles.AutoSize = true;
            checkBoxDrawTriangles.Location = new Point(6, 56);
            checkBoxDrawTriangles.Name = "checkBoxDrawTriangles";
            checkBoxDrawTriangles.Size = new Size(83, 24);
            checkBoxDrawTriangles.TabIndex = 1;
            checkBoxDrawTriangles.Text = "Trójkąty";
            checkBoxDrawTriangles.UseVisualStyleBackColor = true;
            checkBoxDrawTriangles.CheckedChanged += checkBoxDrawTriangles_CheckedChanged;
            // 
            // checkBoxDrawControls
            // 
            checkBoxDrawControls.AutoSize = true;
            checkBoxDrawControls.Location = new Point(6, 26);
            checkBoxDrawControls.Name = "checkBoxDrawControls";
            checkBoxDrawControls.Size = new Size(141, 24);
            checkBoxDrawControls.TabIndex = 0;
            checkBoxDrawControls.Text = "Punkty kontrolne";
            checkBoxDrawControls.UseVisualStyleBackColor = true;
            checkBoxDrawControls.CheckedChanged += checkBoxDrawControls_CheckedChanged;
            // 
            // groupBoxM
            // 
            groupBoxM.Controls.Add(trackBarM);
            groupBoxM.Controls.Add(textBoxM);
            groupBoxM.Location = new Point(198, 449);
            groupBoxM.Name = "groupBoxM";
            groupBoxM.Size = new Size(250, 80);
            groupBoxM.TabIndex = 20;
            groupBoxM.TabStop = false;
            groupBoxM.Text = "współczynnik m";
            // 
            // trackBarM
            // 
            trackBarM.Location = new Point(62, 24);
            trackBarM.Maximum = 100;
            trackBarM.Minimum = 1;
            trackBarM.Name = "trackBarM";
            trackBarM.Size = new Size(182, 56);
            trackBarM.TabIndex = 11;
            trackBarM.Value = 1;
            trackBarM.Scroll += trackBarM_Scroll;
            // 
            // textBoxM
            // 
            textBoxM.Enabled = false;
            textBoxM.Location = new Point(6, 26);
            textBoxM.Name = "textBoxM";
            textBoxM.Size = new Size(50, 27);
            textBoxM.TabIndex = 10;
            // 
            // groupBoxKS
            // 
            groupBoxKS.Controls.Add(trackBarKS);
            groupBoxKS.Controls.Add(textBoxKS);
            groupBoxKS.Location = new Point(198, 363);
            groupBoxKS.Name = "groupBoxKS";
            groupBoxKS.Size = new Size(250, 80);
            groupBoxKS.TabIndex = 19;
            groupBoxKS.TabStop = false;
            groupBoxKS.Text = "współczynnik ks";
            // 
            // trackBarKS
            // 
            trackBarKS.Location = new Point(62, 26);
            trackBarKS.Maximum = 100;
            trackBarKS.Name = "trackBarKS";
            trackBarKS.Size = new Size(182, 56);
            trackBarKS.TabIndex = 7;
            trackBarKS.Value = 50;
            trackBarKS.Scroll += trackBarKS_Scroll;
            // 
            // textBoxKS
            // 
            textBoxKS.Enabled = false;
            textBoxKS.Location = new Point(6, 26);
            textBoxKS.Name = "textBoxKS";
            textBoxKS.Size = new Size(50, 27);
            textBoxKS.TabIndex = 8;
            // 
            // groupBoxKD
            // 
            groupBoxKD.Controls.Add(trackBarKD);
            groupBoxKD.Controls.Add(textBoxKD);
            groupBoxKD.Location = new Point(198, 275);
            groupBoxKD.Name = "groupBoxKD";
            groupBoxKD.Size = new Size(250, 80);
            groupBoxKD.TabIndex = 18;
            groupBoxKD.TabStop = false;
            groupBoxKD.Text = "współczynnik kd";
            // 
            // trackBarKD
            // 
            trackBarKD.Location = new Point(62, 26);
            trackBarKD.Maximum = 100;
            trackBarKD.Name = "trackBarKD";
            trackBarKD.Size = new Size(182, 56);
            trackBarKD.TabIndex = 6;
            trackBarKD.Value = 50;
            trackBarKD.Scroll += trackBarKD_Scroll;
            // 
            // textBoxKD
            // 
            textBoxKD.Enabled = false;
            textBoxKD.Location = new Point(6, 26);
            textBoxKD.Name = "textBoxKD";
            textBoxKD.Size = new Size(50, 27);
            textBoxKD.TabIndex = 9;
            // 
            // groupBoxBeta
            // 
            groupBoxBeta.Controls.Add(trackBarBeta);
            groupBoxBeta.Controls.Add(textBoxBeta);
            groupBoxBeta.Location = new Point(198, 189);
            groupBoxBeta.Name = "groupBoxBeta";
            groupBoxBeta.Size = new Size(250, 80);
            groupBoxBeta.TabIndex = 17;
            groupBoxBeta.TabStop = false;
            groupBoxBeta.Text = "kąt beta";
            // 
            // trackBarBeta
            // 
            trackBarBeta.Location = new Point(62, 26);
            trackBarBeta.Maximum = 720;
            trackBarBeta.Name = "trackBarBeta";
            trackBarBeta.Size = new Size(182, 56);
            trackBarBeta.TabIndex = 3;
            trackBarBeta.Value = 180;
            trackBarBeta.Scroll += trackBarBeta_Scroll;
            // 
            // textBoxBeta
            // 
            textBoxBeta.Enabled = false;
            textBoxBeta.Location = new Point(6, 26);
            textBoxBeta.Name = "textBoxBeta";
            textBoxBeta.Size = new Size(50, 27);
            textBoxBeta.TabIndex = 5;
            // 
            // groupBoxAlpha
            // 
            groupBoxAlpha.Controls.Add(trackBarAlpha);
            groupBoxAlpha.Controls.Add(textBoxAlpha);
            groupBoxAlpha.Location = new Point(198, 103);
            groupBoxAlpha.Name = "groupBoxAlpha";
            groupBoxAlpha.Size = new Size(250, 80);
            groupBoxAlpha.TabIndex = 16;
            groupBoxAlpha.TabStop = false;
            groupBoxAlpha.Text = "kąt alfa";
            // 
            // trackBarAlpha
            // 
            trackBarAlpha.Location = new Point(62, 26);
            trackBarAlpha.Maximum = 720;
            trackBarAlpha.Minimum = -720;
            trackBarAlpha.Name = "trackBarAlpha";
            trackBarAlpha.Size = new Size(182, 56);
            trackBarAlpha.TabIndex = 2;
            trackBarAlpha.Value = 180;
            trackBarAlpha.Scroll += trackBarAlpha_Scroll;
            // 
            // textBoxAlpha
            // 
            textBoxAlpha.Enabled = false;
            textBoxAlpha.Location = new Point(6, 26);
            textBoxAlpha.Name = "textBoxAlpha";
            textBoxAlpha.Size = new Size(50, 27);
            textBoxAlpha.TabIndex = 4;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(trackBarTrianglesN);
            groupBox1.Controls.Add(textBoxTrianglesN);
            groupBox1.Location = new Point(198, 17);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(250, 80);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            groupBox1.Text = "liczba Trójkątów";
            // 
            // trackBarTrianglesN
            // 
            trackBarTrianglesN.Location = new Point(62, 24);
            trackBarTrianglesN.Maximum = 32;
            trackBarTrianglesN.Minimum = 1;
            trackBarTrianglesN.Name = "trackBarTrianglesN";
            trackBarTrianglesN.Size = new Size(182, 56);
            trackBarTrianglesN.TabIndex = 0;
            trackBarTrianglesN.Value = 16;
            trackBarTrianglesN.Scroll += trackBarTrianglesN_Scroll;
            // 
            // textBoxTrianglesN
            // 
            textBoxTrianglesN.Enabled = false;
            textBoxTrianglesN.Location = new Point(6, 26);
            textBoxTrianglesN.Name = "textBoxTrianglesN";
            textBoxTrianglesN.Size = new Size(50, 27);
            textBoxTrianglesN.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1136, 571);
            Controls.Add(groupBoxOptions);
            Controls.Add(canvas);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            Shown += Form1_Shown;
            ((System.ComponentModel.ISupportInitialize)canvas).EndInit();
            groupBoxOptions.ResumeLayout(false);
            groupBoxLight.ResumeLayout(false);
            groupBoxLight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarParameter).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLightColor).EndInit();
            groupBoxSurface.ResumeLayout(false);
            groupBoxSurface.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSurfaceColor).EndInit();
            groupBoxM.ResumeLayout(false);
            groupBoxM.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarM).EndInit();
            groupBoxKS.ResumeLayout(false);
            groupBoxKS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarKS).EndInit();
            groupBoxKD.ResumeLayout(false);
            groupBoxKD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarKD).EndInit();
            groupBoxBeta.ResumeLayout(false);
            groupBoxBeta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarBeta).EndInit();
            groupBoxAlpha.ResumeLayout(false);
            groupBoxAlpha.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarAlpha).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
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
        private GroupBox groupBox1;
        private TrackBar trackBarM;
        private TextBox textBoxM;
        private TextBox textBoxKD;
        private TextBox textBoxKS;
        private TrackBar trackBarKS;
        private TrackBar trackBarKD;
        private GroupBox groupBoxKS;
        private GroupBox groupBoxKD;
        private GroupBox groupBoxBeta;
        private GroupBox groupBoxAlpha;
        private GroupBox groupBoxLight;
        private GroupBox groupBoxSurface;
        private GroupBox groupBoxM;
        private CheckBox checkBoxDrawSurface;
        private CheckBox checkBoxDrawTriangles;
        private CheckBox checkBoxDrawControls;
        private PictureBox pictureBoxSurfaceColor;
        private Button buttonSurfaceColor;
        private PictureBox pictureBoxLightColor;
        private Button buttonLightColor;
        private TextBox textBoxParameter;
        private TrackBar trackBarParameter;
    }
}
