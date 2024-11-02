using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.Basics
{
    public class DrawingBitmapData
    {
        public DrawingBitmapData(DirectBitmap dbitmap)
        {
            DBitmap = dbitmap;
        }
        public DirectBitmap DBitmap { get; set; }
        public Graphics? G { get; set; }
        public Pen? Pen { get; set; }
        public Brush? Brush { get; set; }
    }
}
