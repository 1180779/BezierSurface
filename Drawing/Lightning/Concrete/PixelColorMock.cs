using Objects.RotationAndTriangulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.Lightning.Concrete
{
    public class PixelColorMock : IPixelColor
    {
        public void ColorPixel(Point p, Triangle t, DrawingData bitmapData)
        {
            using Brush b = new SolidBrush(Color.Green);
            bitmapData.G.FillRectangle(b, new Rectangle(p.X, p.Y, 1, 1));
            //bitmapData.DBitmap.SetPixel(
            //    p.X + bitmapData.AdjX,
            //    p.Y + bitmapData.AdjY,
            //    Color.Green);
        }
    }
}
