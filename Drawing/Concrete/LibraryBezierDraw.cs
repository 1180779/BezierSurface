using Objects.Basics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.Concrete
{
    public class LibraryBezierDraw : IBezierDraw
    {
        public IVector3Draw Vector3Draw;
        public ILineDraw LineDraw;
        public LibraryBezierDraw(IVector3Draw vector3Draw, ILineDraw lineDraw)
        {
            Vector3Draw = vector3Draw;
            LineDraw = lineDraw;
        }
        public void DrawBezier(BezierSufrace b, DrawingBitmapData bitmapData)
        {
            for (int i = 0; i < 4 - 1; ++i)
            {
                for (int j = 0; j < 4; j++)
                {
                    LineDraw.DrawLine(b[i, j], b[i + 1, j], bitmapData);
                }
            }

            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4 - 1; j++)
                {
                    LineDraw.DrawLine(b[i, j], b[i, j + 1], bitmapData);
                }
            }

            foreach (var point in b.Points)
            {
                Vector3Draw.DrawVector3(point, bitmapData);
            }
        }
    }
}
