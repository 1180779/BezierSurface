using Drawing.Basics;
using Objects.Bezier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.Bezier
{
    public interface IBezierDraw
    {
        public void DrawBezier(BezierSufrace b, DrawingBitmapData bitmapData);
    }
}
