using Drawing.Basics;
using Drawing.Basics.Concrete;
using Drawing.Bezier;
using Drawing.Bezier.Concrete;
using Drawing.Bezier.Concrete.Drawing.Bezier.Concrete;
using Drawing.RotationAndTriangulation;
using Drawing.RotationAndTriangulation.Concrete;
using Objects.Bezier;
using Objects.RotationAndTriangulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Numerics;
using Drawing.Lightning;
using Drawing.Lightning.Concrete;
using Drawing.Filling.Concrete;

namespace Drawing
{
    public static class DrawingConfig
    {
        static DrawingConfig()
        {
            ILineDraw lineDraw = new LibraryLineDraw();

            LightSource = new LightSource(new Vector3(-800, -800, 0));

            BezierDraw = new BezierDrawRotation(
                new VertexDrawRotation(new LibraryVector3Draw()), 
                lineDraw);

            TriangleDraw = new TriangleDrawRotation(
                new LibraryVector3Draw(1), 
                lineDraw);

            TriangulatedBezierDraw = new TriangulatedBezierDrawLit(
                TriangleDraw, 
                new BucketPolygonFill(new ScanDraw(new PixelColor())));
        }
        public static ILightSource LightSource { get; private set; }
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
