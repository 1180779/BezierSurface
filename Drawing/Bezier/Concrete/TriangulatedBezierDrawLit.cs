using Drawing.Basics;
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
        public ITriangleDraw TriangleDraw { get; set; }
        public IPolygonFill PolygonFill { get; set; }
        public TriangulatedBezierDrawLit(ITriangleDraw triangleDraw, IPolygonFill polygonFill)
        {
            TriangleDraw = triangleDraw;
            PolygonFill = polygonFill;
        }

        public void DrawTriangulatedBezier(TriangulatedBezierSurface bs, DrawingBitmapData bitmapData)
        {
            foreach (var triangle in bs.Triangles)
            {
                TriangleDraw.DrawTriangle(triangle, bitmapData);
                //PolygonFill.FillPolygon(triangle, bitmapData);
            }
            //Vertex B = new Vertex();
            //B.PR = new System.Numerics.Vector3(-100, 0, 513);
            //Vertex C = new Vertex();
            //C.PR = new System.Numerics.Vector3(0, 100, 111);
            //Triangle MockTriangle = new Triangle(new Vertex(), B, C);
            //PolygonFill.FillPolygon(MockTriangle, bitmapData);

            //Triangle t = bs.Triangles[0];
            Triangle t = new Triangle(bs.Points[1, 1], bs.Points[2, 1], bs.Points[2, 2]);
            PolygonFill.FillPolygon(t, bitmapData);
        }
    }
}
