﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.Basics.Concrete
{
    public class LibraryVector3Draw : IVector3Draw
    {
        public int Radius { get; set; }
        public LibraryVector3Draw(int radius = 5)
        {
            Radius = radius;
        }

        public void DrawVector3(Vector3 v, DrawingData bitmapData)
        {
            bitmapData.G!.FillEllipse(bitmapData.Brush!,
                new Rectangle((int)(v.X - Radius), (int)(v.Y - Radius), 2 * Radius, 2 * Radius));
        }
    }
}
