using System.Drawing;

using Drawing;
using Objects.Basics;
using Objects.Triangulation;

namespace BezierSurface
{
    public partial class Form1 : Form
    {
        private DirectBitmap _dbitmap;
        private DrawingBitmapData _drawingData;
        private TriangulatedBezierSurface _surface;
        private readonly string _pointsFile = "./Points.txt";
        public Form1()
        {
            InitializeComponent();

            _dbitmap = new DirectBitmap(canvas.Width, canvas.Height);
            canvas.Image = _dbitmap.Bitmap;

            _drawingData = new(_dbitmap);
            _drawingData.Pen = Pens.Black;
            _drawingData.Brush = Brushes.Green;
            

            textBoxTrianglesN.Text = trackBarTrianglesN.Value.ToString();
            textBoxAlpha.Text = trackBarAlpha.Value.ToString();
            textBoxBeta.Text = trackBarBeta.Value.ToString();

            _surface = new(_pointsFile, trackBarTrianglesN.Value);

            using (Graphics g = Graphics.FromImage(canvas.Image))
            {
                _drawingData.G = g;

                g.ScaleTransform(1, -1);
                g.TranslateTransform(canvas.Width / 2, -canvas.Height / 2);

                g.Clear(Color.White);

                DrawingConfig.DrawBezier(_surface, _drawingData);
                DrawingConfig.DrawTriangulatedBezier(_surface, _drawingData);

                _drawingData.G = null;
            }

        }

        private void trackBarTrianglesN_Scroll(object sender, EventArgs e)
        {
            _surface.N = trackBarTrianglesN.Value;
            textBoxTrianglesN.Text = trackBarTrianglesN.Value.ToString();
            canvas.Invalidate();
        }

        private void trackBarAlpha_Scroll(object sender, EventArgs e)
        {
            textBoxAlpha.Text = trackBarAlpha.Value.ToString();
            canvas.Invalidate();
        }

        private void trackBarBeta_Scroll(object sender, EventArgs e)
        {
            textBoxBeta.Text = trackBarBeta.Value.ToString();
            canvas.Invalidate();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            using Graphics g = Graphics.FromImage(_dbitmap.Bitmap);
            g.ScaleTransform(1, -1);
            g.TranslateTransform(canvas.Width / 2, -canvas.Height / 2);
            _drawingData.G = g;

            g.Clear(Color.White);
            DrawingConfig.DrawTriangulatedBezier(_surface, _drawingData);

            _drawingData.G = null;
        }
    }
}
