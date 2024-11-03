using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objects.Bezier;

namespace Drawing.Bezier
{
    public interface ITriangulatedBezierDraw
    {
        public void DrawTriangulatedBezier(TriangulatedBezierSurface bs, DrawingBitmapData bitmapData);
    }
}
