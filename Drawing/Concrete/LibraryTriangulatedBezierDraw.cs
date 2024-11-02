using Objects.Triangulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.Concrete
{
    public class LibraryTriangulatedBezierDraw : ITriangulatedBezierDraw
    {
        public ITriangleDraw TriangleDraw { get; set; }
        public LibraryTriangulatedBezierDraw(ITriangleDraw triangleDraw)
        {
            TriangleDraw = triangleDraw;
        }

        public void DrawTriangulatedBezier(TriangulatedBezierSurface bs, DrawingBitmapData bitmapData)
        {
            foreach (var triangle in bs.Triangles)
            {
                TriangleDraw.DrawTriangle(triangle, bitmapData);
            }
        }
    }
}
