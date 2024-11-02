using Drawing.Basics;
using Drawing.RotationAndTriangulation;
using Objects.RotationAndTriangulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.RotationAndTriangulation.Concrete
{
    public class TriangleDrawRotation : ITriangleDraw
    {
        public ILineDraw LineDraw { get; set; }
        public IVector3Draw Vector3Draw { get; set; }
        public TriangleDrawRotation(IVector3Draw vector3Draw, ILineDraw lineDraw)
        {
            LineDraw = lineDraw;
            Vector3Draw = vector3Draw;
        }
        public void DrawTriangle(Triangle t, DrawingBitmapData bitmapData)
        {
            LineDraw.DrawLine(t.A.PR, t.B.PR, bitmapData);
            LineDraw.DrawLine(t.A.PR, t.C.PR, bitmapData);
            LineDraw.DrawLine(t.B.PR, t.C.PR, bitmapData);

            Vector3Draw.DrawVector3(t.A.PR, bitmapData);
            Vector3Draw.DrawVector3(t.B.PR, bitmapData);
            Vector3Draw.DrawVector3(t.C.PR, bitmapData);
        }
    }
}
