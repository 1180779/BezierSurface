using Drawing.Concrete;
using Objects.Basics;
using Objects.Triangulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing
{
    public static class DrawingConfig
    {
        static DrawingConfig() 
        {
            ILineDraw lineDraw = new LibraryLineDraw();

            BezierDraw = new LibraryBezierDraw(new LibraryVector3Draw(), lineDraw);
            TriangleDraw = new LibraryTriangleDraw(new LibraryVector3Draw(1), lineDraw);
            TriangulatedBezierDraw = new LibraryTriangulatedBezierDraw(TriangleDraw);
        }
        public static ITriangulatedBezierDraw TriangulatedBezierDraw { get; private set; }
        public static IBezierDraw BezierDraw { get; private set; }
        public static ITriangleDraw TriangleDraw { get; private set; }

        public static void DrawTriangulatedBezier(TriangulatedBezierSurface bs, DrawingBitmapData bitmapData)
            => TriangulatedBezierDraw.DrawTriangulatedBezier(bs, bitmapData);
        public static void DrawBezier(BezierSufrace b, DrawingBitmapData bitmapData) 
            => BezierDraw.DrawBezier(b, bitmapData);
        public static void DrawTriangle(Triangle t, DrawingBitmapData bitmapData) 
            => TriangleDraw.DrawTriangle(t, bitmapData);
    }
}
