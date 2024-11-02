using Objects.Triangulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing
{
    public interface IVertexDraw
    {
        public void DrawVertex(Vertex v, DrawingBitmapData bitmapData);
    }
}
