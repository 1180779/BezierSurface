using Drawing.Lightning;
using Drawing.Lightning.Concrete;
using Objects.RotationAndTriangulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.Filling.Concrete
{
    internal class ScanDrawMock : IScanDraw
    {
        public ScanDrawMock() { }
        public ScanDrawMock(IPixelColor pixelColor) { }
        public void DrawScan(int X1, int X2, int y, Triangle t, DrawingBitmapData bitmapData)
        {
            bitmapData.G.DrawLine(Pens.Green, new Point(X1, y), new Point(X2, y));
        }
    }
}
