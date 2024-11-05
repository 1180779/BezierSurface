using Drawing.Lightning;
using Drawing.Lightning.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Numerics;
using System.ComponentModel;

namespace Drawing
{
    public class DrawingData
    {
        public DrawingData(DirectBitmap dbitmap, int adjX, int adjY, object configLock, string normalMapFile = "")
        {
            DBitmap = dbitmap;
            AdjX = adjX;
            AdjY = adjY;
            
            LightSParams = new LightParameters();
            LightSParams.PropertyChanged += RecalculatePartialLightComputations;

            //LightS = new LightSource(new Vector3(0, 0, 100), Color.White); // new Vector3(-100, -1000, 0)
            LightS = new MovingLightSource(new Vector3(0, 0, 400), Color.White, configLock); // new Vector3(-100, -1000, 0)
            LightS.StartMoving();
            LightS.PropertyChanged += RecalculatePartialLightComputations;

            SurfaceColor = new ObjectColor();
            SurfaceColor.PropertyChanged += RecalculatePartialLightComputations;

            RecalculatePartialLightComputations(null, new PropertyChangedEventArgs(""));

            if (normalMapFile != "")
                NormalMap = new Bitmap(normalMapFile);
            
        }
        public Bitmap Texture { get; set; }
        public Bitmap NormalMap { get; set; }
        public int AdjX { get; set; }
        public int AdjY { get; set; }
        public DirectBitmap DBitmap { get; set; }
        public Graphics? G { get; set; }
        public Pen? Pen { get; set; }
        public Brush? Brush { get; set; }
        public ObjectColor SurfaceColor;
        public LightParameters LightSParams;
        public IMovingLightSource LightS;
        public PartialLightComputations PartialLightComputations;
        public void RecalculatePartialLightComputations(Object? sender, PropertyChangedEventArgs e) 
            => PartialLightComputations.Recalculate(SurfaceColor, LightSParams, LightS);
        public bool ChangeNormalMap(string filePath)
        {
            if (!File.Exists(filePath))
                return false;
            NormalMap = new Bitmap(filePath);
            return true;
        }

        public bool ChangeTexture(string filePath)
        {
            if (!File.Exists(filePath))
                return false;
            Texture = new Bitmap(filePath);
            return true;
        }
    }
}
