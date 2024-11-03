using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Numerics;
using Objects.RotationAndTriangulation;

namespace Drawing.Basics
{
    public interface ILineDraw
    {
        public void DrawLine(Vector3 P1, Vector3 P2, DrawingBitmapData bitmapData);
        public void DrawLine(Point P1, Point P2, DrawingBitmapData bitmapData);
    }
}
