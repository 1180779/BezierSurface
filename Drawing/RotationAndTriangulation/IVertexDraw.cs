using Drawing.Basics;
using Objects.Basics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.RotationAndTriangulation
{
    public interface IVertexDraw
    {
        public void DrawVertex(Vertex v, DrawingBitmapData bitmapData);
    }
}
