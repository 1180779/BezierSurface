using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Numerics;

namespace Drawing
{
    public interface ILineDraw
    {
        public void DrawLine(Vector3 P1, Vector3 P2, DrawingBitmapData bitmapData);
    }
}
