using Drawing.Basics;
using Drawing.RotationAndTriangulation;
using Objects.Bezier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.Bezier.Concrete
{
    namespace Drawing.Bezier.Concrete
    {
        public class BezierDrawRotation : IBezierDraw
        {
            public IVertexDraw VertexDraw;
            public ILineDraw LineDraw;
            public BezierDrawRotation(IVertexDraw vertexDraw, ILineDraw lineDraw)
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
                        LineDraw.DrawLine(b[i, j].PR, b[i + 1, j].PR, bitmapData);
                    }
                }

                for (int i = 0; i < 4; ++i)
                {
                    for (int j = 0; j < 4 - 1; j++)
                    {
                        LineDraw.DrawLine(b[i, j].PR, b[i, j + 1].PR, bitmapData);
                    }
                }

                foreach (var point in b.Points)
                {
                    VertexDraw.DrawVertex(point, bitmapData);
                }
            }
        }
    }

}
