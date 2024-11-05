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

        public CancellationTokenSource CTS { get; set; } = new();

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

            _drawingData = new(_dbitmap, canvas.Width / 2, canvas.Height / 2, _drawingDataLock, "./normalMap1.png");
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

            checkBoxLightMoving.Checked = _drawingData.LightS.IsMoving;

            checkBoxNormalBitmap.Checked = DrawingObject.NormalBitmapOn;
            checkBoxTexture.Checked = DrawingObject.TextureOn;

            //CanvasRedraw();

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
        private object _drawingDataLock = new();
        private Barrier _canvasUpdateBarrier = new(2);
        private void Form1_Shown(object sender, EventArgs e)
        {
            // TO DO: Create thread to update z slider
            new Thread((t) =>
            {
                CancellationToken token = (CancellationToken)t;
                while (!token.IsCancellationRequested)
                {
                    trackBarParameter.BeginInvoke((MethodInvoker)(() =>
                    {
                        trackBarParameter.Value = (int)(_drawingData.LightS.Parameter * 100);
                        textBoxParameter.Text = (_drawingData.LightS.Parameter * 2 * Math.PI).ToString();
                    }));
                    Thread.Sleep(250);
                }
            }).Start(CTS.Token);

            new Thread((t) =>
            {
                CancellationToken token = (CancellationToken)t;
                while (!token.IsCancellationRequested)
                {
                    lock (_drawingDataLock)
                    {
                        CanvasRedraw();
                    }
                    BeginInvoke((MethodInvoker)(() =>
                    {
                        DrawingThreadSync();
                    }));
                    _canvasUpdateBarrier.SignalAndWait();
                }
            }).Start(CTS.Token);
        }

        private void DrawingThreadSync()
        {
            canvas.Invalidate();
            canvas.Update();
            _canvasUpdateBarrier.SignalAndWait();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            CTS.Cancel();
            _drawingData.LightS.StopMoving();

            _canvasUpdateBarrier.SignalAndWait();
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
        }

        private void trackBarTrianglesN_Scroll(object sender, EventArgs e)
        {
            lock (_drawingDataLock)
            {
                _surface.N = trackBarTrianglesN.Value;
            }
            textBoxTrianglesN.Text = trackBarTrianglesN.Value.ToString();
        }

        private void trackBarAlpha_Scroll(object sender, EventArgs e)
        {
            float value = trackBarAlpha.Value / 4;
            lock (_drawingDataLock)
            {
                _surface.Alpha = value / 360 * 2 * (float)Math.PI;
            }
            textBoxAlpha.Text = value.ToString();
        }

        private void trackBarBeta_Scroll(object sender, EventArgs e)
        {
            float value = trackBarBeta.Value / 4;
            lock (_drawingDataLock)
            {
                _surface.Beta = value / 360 * 2 * (float)Math.PI;
            }
            textBoxBeta.Text = value.ToString();
        }

        private void trackBarKD_Scroll(object sender, EventArgs e)
        {
            float value = (float)trackBarKD.Value / 100;
            lock (_drawingDataLock)
            {
                _drawingData.LightSParams.KD = value;
            }
            textBoxKD.Text = value.ToString();
        }

        private void trackBarKS_Scroll(object sender, EventArgs e)
        {
            float value = (float)trackBarKS.Value / 100;
            lock (_drawingDataLock)
            {
                _drawingData.LightSParams.KS = value;
            }
            textBoxKS.Text = value.ToString();
        }

        private void trackBarM_Scroll(object sender, EventArgs e)
        {
            float value = trackBarM.Value;
            lock (_drawingDataLock)
            {
                _drawingData.LightSParams.M = value;
            }
            textBoxM.Text = value.ToString();
        }

        private void checkBoxDrawControls_CheckedChanged(object sender, EventArgs e)
        {
            DrawingSelection.Controls = checkBoxDrawControls.Checked;
        }

        private void checkBoxDrawTriangles_CheckedChanged(object sender, EventArgs e)
        {
            DrawingSelection.Triangles = checkBoxDrawTriangles.Checked;
        }

        private void checkBoxDrawSurface_CheckedChanged(object sender, EventArgs e)
        {
            DrawingSelection.Surface = checkBoxDrawSurface.Checked;
        }

        private void buttonSurfaceColor_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                lock (_drawingDataLock)
                {
                    _drawingData.SurfaceColor.Color = dialog.Color;
                }
                using (Graphics g = Graphics.FromImage(_surfaceColorBitmap))
                {
                    g.Clear(_drawingData.SurfaceColor.Color);
                }
                pictureBoxSurfaceColor.Invalidate();
            }
        }

        private void buttonLightColor_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                lock (_drawingDataLock)
                {
                    _drawingData.LightS.Color = dialog.Color;
                }
                using (Graphics g = Graphics.FromImage(_lightColorBitmap))
                {
                    g.Clear(_drawingData.LightS.Color);
                }
                pictureBoxLightColor.Invalidate();
            }
        }

        private void trackBarParameter_Scroll(object sender, EventArgs e)
        {
            float value = ((float)trackBarParameter.Value / 100);
            textBoxParameter.Text = (value * 2 * (float)Math.PI).ToString();
            lock (_drawingDataLock)
            {
                _drawingData.LightS.Parameter = value;
            }
        }

        private void checkBoxLightMoving_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxLightMoving.Checked)
            {
                _drawingData.LightS.StartMoving();
            }
            else
            {
                _drawingData.LightS.StopMoving();
            }
        }

        private void checkBoxNormalBitmap_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNormalBitmap.Checked)
            {
                DrawingObject.NormalBitmapOn = true;
            }
            else
            {
                DrawingObject.NormalBitmapOn = false;
            }
        }

        private void buttonChooseNormalMap_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                lock (_drawingDataLock)
                {
                    if (!_drawingData.ChangeNormalMap(dialog.FileName))
                        throw new Exception();
                }
            }
        }
        private void checkBoxTexture_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTexture.Checked)
            {
                DrawingObject.TextureOn = true;
            }
            else
            {
                DrawingObject.TextureOn = false;
            }
        }

        private void buttonTexture_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                lock (_drawingDataLock)
                {
                    if (!_drawingData.ChangeTexture(dialog.FileName))
                        throw new Exception();
                }
            }
        }

    }
}
