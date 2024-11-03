using Objects.RotationAndTriangulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.Filling
{
    public interface IScanDraw
    {
        public void DrawScan(int X1, int X2, int y, Triangle t, DrawingBitmapData bitmapData);
    }
}
