using Drawing.Lightning;
using Drawing.Lightning.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Numerics;

namespace Drawing
{
    public class DrawingBitmapData
    {
        public DrawingBitmapData(DirectBitmap dbitmap, int adjX, int adjY)
        {
            DBitmap = dbitmap;
            LightParams = new LightParameters();
            AdjX = adjX;
            AdjY = adjY;
            LightS = new LightSource(new Vector3(1000, 1000, 1000), Color.White);
        }
        public int AdjX { get; set; }
        public int AdjY { get; set; }
        public DirectBitmap DBitmap { get; set; }
        public Graphics? G { get; set; }
        public Pen? Pen { get; set; }
        public Brush? Brush { get; set; }
        public LightParameters LightParams {  get; set; }
        public ILightSource LightS { get; set; }
    }
}
