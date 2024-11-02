using Objects.Basics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing
{
    public interface IBezierDraw
    {
        public void DrawBezier(BezierSufrace b, DrawingBitmapData bitmapData);
    }
}
