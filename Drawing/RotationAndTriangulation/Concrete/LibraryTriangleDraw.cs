﻿using Drawing.Basics;
using Drawing.RotationAndTriangulation;
using Objects.Triangulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.RotationAndTriangulation.Concrete
{
    public class LibraryTriangleDraw : ITriangleDraw
    {
        public ILineDraw LineDraw { get; set; }
        public IVector3Draw Vector3Draw { get; set; }
        public LibraryTriangleDraw(IVector3Draw vector3Draw, ILineDraw lineDraw)
        {
            LineDraw = lineDraw;
            Vector3Draw = vector3Draw;
        }
        public void DrawTriangle(Triangle t, DrawingBitmapData bitmapData)
        {
            LineDraw.DrawLine(t.A.P, t.B.P, bitmapData);
            LineDraw.DrawLine(t.A.P, t.C.P, bitmapData);
            LineDraw.DrawLine(t.B.P, t.C.P, bitmapData);

            Vector3Draw.DrawVector3(t.A.P, bitmapData);
            Vector3Draw.DrawVector3(t.B.P, bitmapData);
            Vector3Draw.DrawVector3(t.C.P, bitmapData);
        }
    }
}