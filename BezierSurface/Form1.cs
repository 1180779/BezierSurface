using System.Drawing;

using Drawing;
using Objects.Bezier;

namespace BezierSurface
{
    public partial class Form1 : Form
    {
        protected static class DrawingSelection
        {
            public static bool Controls { get; set; }
            public static bool Triangles { get; set; }
            public static bool Surface { get; set; }
        }

        private void InitializeDrawingSelection()
        {
            DrawingSelection.Controls = false;
            checkBoxDrawControls.Checked = false;

            DrawingSelection.Triangles = false;
            checkBoxDrawTriangles.Checked = false;

            DrawingSelection.Surface = true;
            checkBoxDrawSurface.Checked = true;
        }

        private Bitmap _lightColorBitmap;
        private Bitmap _surfaceColorBitmap;
        private DirectBitmap _dbitmap;
        private DrawingData _drawingData;
        private TriangulatedBezierSurface _surface;
        private readonly string _pointsFile = "./Points.txt";
        public Form1()
        {
            InitializeComponent();

            _dbitmap = new DirectBitmap(canvas.Width, canvas.Height);
            canvas.Image = _dbitmap.Bitmap;

            _drawingData = new(_dbitmap, canvas.Width / 2, canvas.Height / 2);
            _drawingData.Pen = Pens.Black;
            _drawingData.Brush = Brushes.Green;

            textBoxTrianglesN.Text = trackBarTrianglesN.Value.ToString();
            float alphaVal = (float)trackBarAlpha.Value / 4;
            textBoxAlpha.Text = alphaVal.ToString();
            float betaVal = (float)trackBarBeta.Value / 4;
            textBoxBeta.Text = betaVal.ToString();

            textBoxKD.Text = ((float)trackBarKD.Value / 100).ToString();
            textBoxKS.Text = ((float)trackBarKS.Value / 100).ToString();
            textBoxM.Text = trackBarM.Value.ToString();

            _surface = new(_pointsFile, trackBarTrianglesN.Value);
            _surface.Alpha = alphaVal / 360 * 2 * (float)Math.PI;
            _surface.Beta = betaVal / 360 * 2 * (float)Math.PI;

            InitializeDrawingSelection();

            CanvasRedraw();

            // select surface color
            _surfaceColorBitmap = new Bitmap(pictureBoxSurfaceColor.Width, pictureBoxSurfaceColor.Height);
            using (Graphics g = Graphics.FromImage(_surfaceColorBitmap))
            {
                g.Clear(_drawingData.SurfaceColor.Color);
            }
            pictureBoxSurfaceColor.Image = _surfaceColorBitmap;

            // select light color
            _lightColorBitmap = new Bitmap(pictureBoxLightColor.Width, pictureBoxLightColor.Height);
            using (Graphics g = Graphics.FromImage(_lightColorBitmap))
            {
                g.Clear(_drawingData.LightS.Color);
            }
            pictureBoxLightColor.Image = _lightColorBitmap;
        }

        private void CanvasRedraw()
        {
            using (Graphics g = Graphics.FromImage(_dbitmap.Bitmap))
            {
                g.ScaleTransform(1, -1);
                g.TranslateTransform(canvas.Width / 2, -canvas.Height / 2);
                _drawingData.G = g;

                g.Clear(Color.White);

                if (DrawingSelection.Surface)
                    DrawingObject.DrawSurface(_surface, _drawingData);
                if (DrawingSelection.Triangles)
                    DrawingObject.DrawTriangulatedBezier(_surface, _drawingData);
                if (DrawingSelection.Controls)
                    DrawingObject.DrawBezier(_surface, _drawingData);

                _drawingData.G = null;
            }
            canvas.Invalidate();
            canvas.Update();
        }

        private void trackBarTrianglesN_Scroll(object sender, EventArgs e)
        {
            _surface.N = trackBarTrianglesN.Value;
            textBoxTrianglesN.Text = trackBarTrianglesN.Value.ToString();
            CanvasRedraw();
        }

        private void trackBarAlpha_Scroll(object sender, EventArgs e)
        {
            float value = trackBarAlpha.Value / 4;
            _surface.Alpha = value / 360 * 2 * (float)Math.PI;
            textBoxAlpha.Text = value.ToString();
            CanvasRedraw();
        }

        private void trackBarBeta_Scroll(object sender, EventArgs e)
        {
            float value = trackBarBeta.Value / 4;
            _surface.Beta = value / 360 * 2 * (float)Math.PI;
            textBoxBeta.Text = value.ToString();
            CanvasRedraw();
        }

        private void trackBarKD_Scroll(object sender, EventArgs e)
        {
            float value = (float)trackBarKD.Value / 100;
            _drawingData.LightSParams.KD = value;
            textBoxKD.Text = value.ToString();
            CanvasRedraw();
        }

        private void trackBarKS_Scroll(object sender, EventArgs e)
        {
            float value = (float)trackBarKS.Value / 100;
            _drawingData.LightSParams.KS = value;
            textBoxKS.Text = value.ToString();
            CanvasRedraw();
        }

        private void trackBarM_Scroll(object sender, EventArgs e)
        {
            float value = trackBarM.Value;
            _drawingData.LightSParams.M = value;
            textBoxM.Text = value.ToString();
            CanvasRedraw();
        }

        private void checkBoxDrawControls_CheckedChanged(object sender, EventArgs e)
        {
            DrawingSelection.Controls = checkBoxDrawControls.Checked;
            CanvasRedraw();
        }

        private void checkBoxDrawTriangles_CheckedChanged(object sender, EventArgs e)
        {
            DrawingSelection.Triangles = checkBoxDrawTriangles.Checked;
            CanvasRedraw();
        }

        private void checkBoxDrawSurface_CheckedChanged(object sender, EventArgs e)
        {
            DrawingSelection.Surface = checkBoxDrawSurface.Checked;
            CanvasRedraw();
        }

        private void buttonSurfaceColor_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _drawingData.SurfaceColor.Color = dialog.Color;
                using (Graphics g = Graphics.FromImage(_surfaceColorBitmap))
                {
                    g.Clear(_drawingData.SurfaceColor.Color);
                }
                pictureBoxSurfaceColor.Invalidate();
                pictureBoxSurfaceColor.Update();
                CanvasRedraw();
            }
        }

        private void buttonLightColor_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _drawingData.LightS.Color = dialog.Color;
                using (Graphics g = Graphics.FromImage(_lightColorBitmap))
                {
                    g.Clear(_drawingData.LightS.Color);
                }
                pictureBoxLightColor.Invalidate();
                pictureBoxLightColor.Update();
                CanvasRedraw();
            }
        }
    }
}
