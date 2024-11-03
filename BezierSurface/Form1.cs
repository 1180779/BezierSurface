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

        private DirectBitmap _dbitmap;
        private DrawingData _drawingData;
        private TriangulatedBezierSurface _surface;
        private readonly string _pointsFile = "./Points.txt";
        public Form1()
        {
            InitializeComponent();

            InitializeDrawingSelection();

            _dbitmap = new DirectBitmap(canvas.Width, canvas.Height);
            canvas.Image = _dbitmap.Bitmap;

            _drawingData = new(_dbitmap, canvas.Width / 2, canvas.Height / 2);
            _drawingData.Pen = Pens.Black;
            _drawingData.Brush = Brushes.Green;

            textBoxTrianglesN.Text = trackBarTrianglesN.Value.ToString();
            float alphaVal = trackBarAlpha.Value / 4;
            textBoxAlpha.Text = alphaVal.ToString();
            float betaVal = trackBarBeta.Value / 4;
            textBoxBeta.Text = betaVal.ToString();

            _surface = new(_pointsFile, trackBarTrianglesN.Value);
            _surface.Alpha = alphaVal / 360 * 2 * (float)Math.PI;
            _surface.Beta = betaVal / 360 * 2 * (float)Math.PI;

            using (Graphics g = Graphics.FromImage(canvas.Image))
            {
                _drawingData.G = g;

                g.ScaleTransform(1, -1);
                g.TranslateTransform(canvas.Width / 2, -canvas.Height / 2);

                g.Clear(Color.White);

                if (DrawingSelection.Controls)
                    DrawingObject.DrawBezier(_surface, _drawingData);
                if (DrawingSelection.Triangles)
                    DrawingObject.DrawTriangulatedBezier(_surface, _drawingData);
                if (DrawingSelection.Surface)
                    DrawingObject.DrawSurface(_surface, _drawingData);

                _drawingData.G = null;
            }
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            using Graphics g = Graphics.FromImage(_dbitmap.Bitmap);
            g.ScaleTransform(1, -1);
            g.TranslateTransform(canvas.Width / 2, -canvas.Height / 2);
            _drawingData.G = g;

            g.Clear(Color.White);
            if (DrawingSelection.Controls)
                DrawingObject.DrawBezier(_surface, _drawingData);
            if (DrawingSelection.Triangles)
                DrawingObject.DrawTriangulatedBezier(_surface, _drawingData);
            if (DrawingSelection.Surface)
                DrawingObject.DrawSurface(_surface, _drawingData);

            _drawingData.G = null;
        }

        private void trackBarTrianglesN_Scroll(object sender, EventArgs e)
        {
            _surface.N = trackBarTrianglesN.Value;
            textBoxTrianglesN.Text = trackBarTrianglesN.Value.ToString();
            canvas.Invalidate();
        }

        private void trackBarAlpha_Scroll(object sender, EventArgs e)
        {
            float value = trackBarAlpha.Value / 4;
            _surface.Alpha = value / 360 * 2 * (float)Math.PI;
            textBoxAlpha.Text = value.ToString();
            canvas.Invalidate();
        }

        private void trackBarBeta_Scroll(object sender, EventArgs e)
        {
            float value = trackBarBeta.Value / 4;
            _surface.Beta = value / 360 * 2 * (float)Math.PI;
            textBoxBeta.Text = value.ToString();
            canvas.Invalidate();
        }

        private void trackBarKD_Scroll(object sender, EventArgs e)
        {
            float value = (float)trackBarKD.Value / 100;
            _drawingData.LightSParams.kd = value;
            textBoxKD.Text = value.ToString();
            canvas.Invalidate();
        }

        private void trackBarKS_Scroll(object sender, EventArgs e)
        {
            float value = (float)trackBarKS.Value / 100;
            _drawingData.LightSParams.ks = value;
            textBoxKS.Text = value.ToString();
            canvas.Invalidate();
        }

        private void trackBarM_Scroll(object sender, EventArgs e)
        {
            float value = trackBarM.Value;
            _drawingData.LightSParams.m = value;
            textBoxM.Text = value.ToString();
            canvas.Invalidate();
        }

        private void checkBoxDrawControls_CheckedChanged(object sender, EventArgs e)
        {
            DrawingSelection.Controls = checkBoxDrawControls.Checked;
            canvas.Invalidate();
        }

        private void checkBoxDrawTriangles_CheckedChanged(object sender, EventArgs e)
        {
            DrawingSelection.Triangles = checkBoxDrawTriangles.Checked;
            canvas.Invalidate();
        }

        private void checkBoxDrawSurface_CheckedChanged(object sender, EventArgs e)
        {
            DrawingSelection.Surface = checkBoxDrawSurface.Checked;
            canvas.Invalidate();
        }
    }
}
