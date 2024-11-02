﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drawing.Basics;
using Objects.Triangulation;

namespace Drawing.Bezier
{
    public interface ITriangulatedBezierDraw
    {
        public void DrawTriangulatedBezier(TriangulatedBezierSurface bs, DrawingBitmapData bitmapData);
    }
}