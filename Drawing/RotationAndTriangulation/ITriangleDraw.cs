using Objects.RotationAndTriangulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.RotationAndTriangulation
{
    public interface ITriangleDraw
    {
        public void DrawTriangle(Triangle t, DrawingBitmapData bitmapData);
    }
}
