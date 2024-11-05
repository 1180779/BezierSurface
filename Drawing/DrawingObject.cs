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
using Drawing.Filling;

namespace Drawing
{
    public static class DrawingObject
    {
        static DrawingObject()
        {
            ILineDraw lineDraw = new LibraryLineDraw();

            LightSource = new LightSource(new Vector3(-800, -800, 0));

            BezierDraw = new BezierDrawRotation(
                new VertexDrawRotation(new LibraryVector3Draw()), 
                lineDraw);

            TriangleDraw = new TriangleDrawRotation(
                new LibraryVector3Draw(1), 
                lineDraw);

            SurfaceTrianglesDraw = new TriangulatedBezierDraw(
                TriangleDraw);

            _surfaceDraw = new TriangulatedBezierDrawLit(
                new BucketPolygonFill(new ScanDraw(new PixelColor())));
            _surfaceDrawNormalMap = new TriangulatedBezierDrawLit(
                new BucketPolygonFill(new ScanDraw(new PixelColorNormalMap())));
            SurfaceDraw = _surfaceDraw;
        }
        private static ITriangulatedBezierDraw _surfaceDraw;
        private static ITriangulatedBezierDraw _surfaceDrawNormalMap;

        private static bool _normalBitmapOn = false;

        public static bool NormalBitmapOn
        {
            get { return _normalBitmapOn; }
            set 
            {
                if (_normalBitmapOn == value)
                    return;
                _normalBitmapOn = value;
                if (value)
                    SurfaceDraw = _surfaceDrawNormalMap;
                else
                    SurfaceDraw = _surfaceDraw;
            }

        }
        public static ILightSource LightSource { get; private set; }
        public static  ITriangulatedBezierDraw SurfaceDraw { get; private set; }
        public static ITriangulatedBezierDraw SurfaceTrianglesDraw { get; private set; }
        public static IBezierDraw BezierDraw { get; private set; }
        public static ITriangleDraw TriangleDraw { get; private set; }

        public static void DrawSurface(TriangulatedBezierSurface bs, DrawingData bitmapData) 
            => SurfaceDraw.Draw(bs, bitmapData);
        public static void DrawTriangulatedBezier(TriangulatedBezierSurface bs, DrawingData bitmapData)
            => SurfaceTrianglesDraw.Draw(bs, bitmapData);
        public static void DrawBezier(BezierSufrace b, DrawingData bitmapData)
            => BezierDraw.DrawBezier(b, bitmapData);
        public static void DrawTriangle(Triangle t, DrawingData bitmapData)
            => TriangleDraw.DrawTriangle(t, bitmapData);
    }
}
