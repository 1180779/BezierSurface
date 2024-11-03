using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drawing.Bezier.Concrete;
using Objects.Bezier;

namespace Drawing.Bezier
{
    public interface ITriangulatedBezierDraw
    {
        public void Draw(TriangulatedBezierSurface bs, DrawingData bitmapData);
    }
}
