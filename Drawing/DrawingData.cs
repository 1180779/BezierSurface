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
        public DrawingData(DirectBitmap dbitmap, int adjX, int adjY, object configLock, 
            string normalMapFile = "", string textureFile = "")
        {
            DBitmap = dbitmap;
            AdjX = adjX;
            AdjY = adjY;
            
            LightSParams = new LightParameters();
            LightSParams.PropertyChanged += RecalculatePartialLightComputations;

            //LightS = new LightSource(new Vector3(0, 0, 100), Color.White); // new Vector3(-100, -1000, 0)
            LightS = new MovingLightSource(new Vector3(0, 0, 100), Color.White, configLock); // new Vector3(-100, -1000, 0)
            LightS.StartMoving();
            LightS.PropertyChanged += RecalculatePartialLightComputations;

            SurfaceColor = new ObjectColor();
            SurfaceColor.PropertyChanged += RecalculatePartialLightComputations;

            RecalculatePartialLightComputations(null, new PropertyChangedEventArgs(""));

            if (normalMapFile != "")
                if (!ChangeNormalMap(normalMapFile))
                    throw new Exception();
            if(textureFile != "")
                if(!ChangeTexture(textureFile))
                    throw new Exception();

        }
        public Bitmap Texture { get; set; }
        public Vector3[,] TexturePreprocessed { get; set; }
        public DirectBitmap NormalMap { get; set; }
        public int AdjX { get; set; }
        public int AdjY { get; set; }
        public int TextureWidth { get; private set; }
        public int TextureHeight { get; private set; }
        public int NormalmapWidth { get; private set; }
        public int NormalmapHeight { get; private set; }
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
            Bitmap temp = new Bitmap(filePath);
            NormalmapWidth = temp.Width;
            NormalmapHeight = temp.Height;
            NormalMap = new DirectBitmap(NormalmapWidth, NormalmapHeight);

            // copy to direct bitmap
            for(int i = 0; i < NormalmapWidth; ++i)
            {
                for(int j = 0; j < NormalmapHeight; ++j)
                {
                    var tempP = temp.GetPixel(i, j);
                    NormalMap.SetPixel(i, j, Color.FromArgb(tempP.R, tempP.G, tempP.B));
                }
            }
            return true;
        }

        public bool ChangeTexture(string filePath)
        {
            if (!File.Exists(filePath))
                return false;
            Texture = new Bitmap(filePath);
            TexturePreprocessed = new Vector3[Texture.Width, Texture.Height];
            Color c;
            TextureWidth = Texture.Width;
            TextureHeight = Texture.Height;
            for (int i = 0; i < Texture.Width; ++i)
            {
                for (int j = 0; j < Texture.Height; ++j)
                {
                    c = Texture.GetPixel(i, j);
                    TexturePreprocessed[i, j] = new Vector3(
                        c.R / 255f,
                        c.G / 255f,
                        c.B / 255f);
                }
            }
            //Thread thread = new Thread(() =>
            //{
            //    for (int i = 0; i < Texture.Width; ++i)
            //    {
            //        for (int j = 0; j < Texture.Height; ++j)
            //        {
            //            c = Texture.GetPixel(i, j);
            //            TexturePreprocessed[i, j] = new Vector3(
            //                c.R / 255f,
            //                c.G / 255f,
            //                c.B / 255f);
            //        }
            //    }
            //});
            //thread.Start();
            return true;
        }

    }
}
