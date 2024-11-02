using Objects.RotationAndTriangulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.Basics.Concrete
{
    public class LibraryLineDraw : ILineDraw
    {
        public void DrawLine(Vector3 P1, Vector3 P2, DrawingBitmapData bitmapData)
        {
            bitmapData.G!.DrawLine(bitmapData.Pen!, new Point((int)P1.X, (int)P1.Y), new Point((int)P2.X, (int)P2.Y));
        }
    }
}
