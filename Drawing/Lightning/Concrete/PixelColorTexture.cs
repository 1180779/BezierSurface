using Objects.RotationAndTriangulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.Lightning.Concrete
{
    public class PixelColorTexture : IPixelColor
    {
        public void ColorPixel(Point p, Triangle t, DrawingData bitmapData)
        {
            var lambda = BarycentricCoordinatesCalculator.GetBarycentric(p, t);
            Vector3 pApprox = lambda.X * t.A.PR + lambda.Y * t.B.PR + lambda.Z * t.C.PR;
            Vector3 N = Vector3.Normalize(lambda.X * t.A.NR + lambda.Y * t.B.NR + lambda.Z * t.C.NR);
            Vector3 L = Vector3.Normalize(bitmapData.LightS.Location - pApprox);
            float cosNL = Vector3.Dot(N, L);
            Vector3 R = Vector3.Normalize(2 * cosNL * N - L);

            if (cosNL < 0f)
                cosNL = 0f;
            float cosVR = Vector3.Dot(Vector3.UnitZ, R);
            if (cosVR < 0)
                cosVR = 0;

            float u = Math.Max(0, Math.Min(1f, lambda.X * t.A.U + lambda.Y * t.B.U + lambda.Z * t.C.U));
            float v = Math.Max(0, Math.Min(1f, lambda.X * t.A.V + lambda.Y * t.B.V + lambda.Z * t.C.V));
            // add color from texture
            var (i, j) = ((int) (u * (bitmapData.Texture.Width - 1)), 
                (int)(v * (bitmapData.Texture.Width - 1)) );
            Vector3 color = bitmapData.PartialLightComputations.ATexture * bitmapData.TexturePreprocessed[i, j] * cosNL +
                bitmapData.PartialLightComputations.BTexture * bitmapData.TexturePreprocessed[i, j] * 
                (float)Math.Pow(cosVR, bitmapData.LightSParams.M);

            for (int k = 0; k < 3; ++k)
            {
                if (color[k] > 1f)
                    color[k] = 1f;
            }
            Color c = Color.FromArgb((int)(color[0] * 255), (int)(color[1] * 255), (int)(color[2] * 255));

            bitmapData.DBitmap.SetPixel(p.X + bitmapData.AdjX, bitmapData.AdjY - p.Y, c);
            //using Brush b = new SolidBrush(c);
            //bitmapData.G.FillRectangle(b, new Rectangle(p.X, p.Y, 1, 1));
        }
    }
}
