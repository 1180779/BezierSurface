using Drawing.Basics;
using Drawing.Lightning;
using Objects.RotationAndTriangulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.Filling.Concrete
{
    public class ScanDraw : IScanDraw
    {
        public IPixelColor PixelColor { get; set; }
        public ScanDraw(IPixelColor pixelColor)
        {
            PixelColor = pixelColor;
        }
        public void DrawScan(int X1, int X2, int y, Triangle t, DrawingBitmapData bitmapData)
        {
            Point p = new Point();
            if (X2 < X1)
                throw new InvalidOperationException();
            p.Y = y;
            for (int i = X1; i < X2; i++) 
            {
                p.X = i;
                PixelColor.ColorPixel(p, t, bitmapData);
            }
        }
    }
}
