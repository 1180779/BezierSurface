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
    public class DrawingData
    {
        public DrawingData(DirectBitmap dbitmap, int adjX, int adjY)
        {
            DBitmap = dbitmap;
            LightSParams = new LightParameters();
            AdjX = adjX;
            AdjY = adjY;
            LightS = new LightSource(new Vector3(-100, -1000, 0), Color.White);
            SurfaceColor = new ObjectColor();
            RecalculatePartialLightComputations();
        }
        public int AdjX { get; set; }
        public int AdjY { get; set; }
        public DirectBitmap DBitmap { get; set; }
        public Graphics? G { get; set; }
        public Pen? Pen { get; set; }
        public Brush? Brush { get; set; }
        public ObjectColor SurfaceColor;
        public LightParameters LightSParams;
        public ILightSource LightS;
        public PartialLightComputations PartialLightComputations;
        public void RecalculatePartialLightComputations() 
            => PartialLightComputations.Recalculate(SurfaceColor, LightSParams, LightS);
    }
}
