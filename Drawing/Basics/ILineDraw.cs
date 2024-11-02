using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Numerics;
using Objects.Basics;

namespace Drawing.Basics
{
    public interface ILineDraw
    {
        public void DrawLine(Vector3 P1, Vector3 P2, DrawingBitmapData bitmapData);
        public void DrawLine(Vertex V1, Vertex V2, DrawingBitmapData bitmapData);
    }
}
