using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Objects.RotationAndTriangulation;

namespace Drawing.Lightning
{
    public interface IPixelColor
    {
        public void ColorPixel(Point p, Triangle t, DrawingBitmapData bitmapData);
    }
}
