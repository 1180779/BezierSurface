using Objects.Triangulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Numerics;

namespace Drawing.Basics
{
    public interface IVector3Draw
    {
        public int Radius { get; set; }
        public void DrawVector3(Vector3 v, DrawingBitmapData bitmapData);
    }
}
