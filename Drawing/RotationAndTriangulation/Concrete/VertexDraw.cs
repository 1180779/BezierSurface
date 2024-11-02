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
    public class VertexDraw : IVertexDraw
    {
        public IVector3Draw Vector3Draw;
        public VertexDraw(IVector3Draw vector3Draw)
        {
            Vector3Draw = vector3Draw;
        }
        public void DrawVertex(Vertex v, DrawingBitmapData bitmapData)
        {
            Vector3Draw.DrawVector3(v.P, bitmapData);
        }
    }
}
