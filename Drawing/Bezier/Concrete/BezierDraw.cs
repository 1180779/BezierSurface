using Drawing.Basics;
using Drawing.Bezier;
using Drawing.RotationAndTriangulation;
using Objects.Bezier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.Bezier.Concrete
{
    public class BezierDraw : IBezierDraw
    {
        public IVertexDraw VertexDraw;
        public ILineDraw LineDraw;
        public BezierDraw(IVertexDraw vertexDraw, ILineDraw lineDraw)
        {
            VertexDraw = vertexDraw;
            LineDraw = lineDraw;
        }
        public void DrawBezier(BezierSufrace b, DrawingData bitmapData)
        {
            for (int i = 0; i < 4 - 1; ++i)
            {
                for (int j = 0; j < 4; j++)
                {
                    LineDraw.DrawLine(b[i, j].P, b[i + 1, j].P, bitmapData);
                }
            }

            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4 - 1; j++)
                {
                    LineDraw.DrawLine(b[i, j].P, b[i, j + 1].P, bitmapData);
                }
            }

            foreach (var point in b.Points)
            {
                VertexDraw.DrawVertex(point, bitmapData);
            }
        }
    }
}
