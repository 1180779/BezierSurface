using Drawing.Bezier;
using Drawing.Filling;
using Drawing.RotationAndTriangulation;
using Objects.Bezier;
using Objects.RotationAndTriangulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.Bezier.Concrete
{
    public class TriangulatedBezierDrawLit : ITriangulatedBezierDraw
    {
        public IPolygonFill PolygonFill { get; set; }
        public TriangulatedBezierDrawLit(IPolygonFill polygonFill)
        {
            PolygonFill = polygonFill;
        }

        public void Draw(TriangulatedBezierSurface bs, DrawingData bitmapData)
        {
            foreach (var triangle in bs.Triangles)
            {
                PolygonFill.FillPolygon(triangle, bitmapData);
            }
        }
    }
}
