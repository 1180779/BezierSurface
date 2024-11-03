using Objects.RotationAndTriangulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.Lightning.Concrete
{
    public class PixelColor : IPixelColor
    {
        public void ColorPixel(Point p, Triangle t, DrawingBitmapData bitmapData)
        {
            var lambda = BarycentricCoordinatesCalculator.GetBarycentric(p, t);
            
            Vector3 pApprox = lambda.X * t.A.PR + lambda.Y * t.B.PR + lambda.Z * t.C.PR;
            Vector3 N = Vector3.Normalize(lambda.X * t.A.NR + lambda.Y * t.B.NR + lambda.Z * t.C.NR);
            Vector3 L = Vector3.Normalize(bitmapData.LightS.Location - pApprox);
            Vector3 V = Vector3.UnitZ;
            Vector3 R = Vector3.Normalize(2 * Vector3.Dot(N, L) * N - L);

            float m = 1;
            Vector3 objectColor = new Vector3(0, 1, 0);
            float cosNL = Vector3.Dot(N, L);
            if (cosNL < 0f)
                cosNL = 0f;
            float cosVR = Vector3.Dot(V, R);
            if(cosVR < 0)
                cosVR = 0;
            // TO DO:
            // add colors to triangles
            float A = bitmapData.LightParams.kd * cosNL;
            float B = bitmapData.LightParams.ks * (float)Math.Pow(cosVR, m);
            float colorR =  A * bitmapData.LightS.Color0To1.X * objectColor.X
                + B * bitmapData.LightS.Color0To1.X * objectColor.X;
            float colorG = A * bitmapData.LightS.Color0To1.Y * objectColor.Y
                + B * bitmapData.LightS.Color0To1.Y * objectColor.Y;
            float colorB = A * bitmapData.LightS.Color0To1.Z * objectColor.Z
                + B * bitmapData.LightS.Color0To1.Z * objectColor.Z;
            Color c = Color.FromArgb((int)(colorR * 255), (int)(colorG * 255), (int)(colorB * 255));

            // TO DO:
            // change to set pixel
            // (how does transformation change final placement???)
            //bitmapData.DBitmap.SetPixel(p.X + bitmapData.AdjX, p.Y + bitmapData.AdjY, c);

            using Brush b = new SolidBrush(c);
            bitmapData.G.FillRectangle(b, new Rectangle(p.X, p.Y, 1, 1));
        }
    }
}
