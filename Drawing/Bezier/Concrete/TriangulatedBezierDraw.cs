using Drawing.Bezier;
using Drawing.RotationAndTriangulation;
using Objects.Bezier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.Bezier.Concrete
{
    public class TriangulatedBezierDraw : ITriangulatedBezierDraw
    {
        public ITriangleDraw TriangleDraw { get; set; }
        public TriangulatedBezierDraw(ITriangleDraw triangleDraw)
        {
            TriangleDraw = triangleDraw;
        }

        public void Draw(TriangulatedBezierSurface bs, DrawingData bitmapData)
        {
            foreach (var triangle in bs.Triangles)
            {
                TriangleDraw.DrawTriangle(triangle, bitmapData);
            }
        }
    }
}
