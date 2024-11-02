using Drawing.Basics;
using Objects.RotationAndTriangulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.RotationAndTriangulation.Concrete
{
    public class VertexDrawRotation : IVertexDraw
    {
        public IVector3Draw Vector3Draw;
        public VertexDrawRotation(IVector3Draw vector3Draw)
        {
            Vector3Draw = vector3Draw;
        }
        public void DrawVertex(Vertex v, DrawingBitmapData bitmapData)
        {
            Vector3Draw.DrawVector3(v.PR, bitmapData);
        }
    }
}
