using Objects.Bezier.Extensions;
using Objects.RotationAndTriangulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.Lightning.Concrete
{
    public class PixelColorNormalMap : IPixelColor
    {
        public void ColorPixel(Point p, Triangle t, DrawingData bitmapData)
        {
            var lambda = BarycentricCoordinatesCalculator.GetBarycentric(p, t);
            Vector3 pApprox = lambda.X * t.A.PR + lambda.Y * t.B.PR + lambda.Z * t.C.PR;
            Vector3 N = Vector3.Normalize(lambda.X * t.A.NR + lambda.Y * t.B.NR + lambda.Z * t.C.NR);
            Vector3 L = Vector3.Normalize(bitmapData.LightS.Location - pApprox);

            Vector3 Pu = Vector3.Normalize(lambda.X * t.A.PuR + lambda.Y * t.B.PuR + lambda.Z * t.C.PuR);
            Vector3 Pv = Vector3.Normalize(lambda.X * t.A.PvR + lambda.Y * t.B.PvR + lambda.Z * t.C.PvR);
            Matrix4x4 matrix = new Matrix4x4(
                Pu.X, Pv.X, N.X, 0,
                Pu.Y, Pv.Y, N.Y, 0,
                Pu.Z, Pv.Z, N.Z, 0,
                0, 0, 0, 1);

            float u = Math.Max(0, Math.Min(1f, lambda.X * t.A.U + lambda.Y * t.B.U + lambda.Z * t.C.U));
            float v = Math.Max(0, Math.Min(1f, lambda.X * t.A.V + lambda.Y * t.B.V + lambda.Z * t.C.V));
            Color mapC = bitmapData.NormalMap.GetPixel(
                (int)(u * (bitmapData.NormalMap.Width - 1)),
                (int)(v * (bitmapData.NormalMap.Height - 1)) );
            Vector3 coef = new Vector3(mapC.R, mapC.G, mapC.B);
            coef.X = (coef.X / 255) * 2f - 1;
            coef.Y = (coef.Y / 255) * 2f - 1;
            coef.Z = (coef.Z  - 128) / 127;
           
            Vector4 Nres = Vector4.Transform(new Vector4(coef.X, coef.Y, coef.Z, 0), matrix);
            N = new Vector3(Nres.X, Nres.Y, Nres.Z);

            float cosNL = Vector3.Dot(N, L);
            Vector3 R = Vector3.Normalize(2 * cosNL * N - L);
            if (cosNL < 0f)
                cosNL = 0f;
            float cosVR = Vector3.Dot(Vector3.UnitZ, R);
            if (cosVR < 0)
                cosVR = 0;

            Vector3 color = bitmapData.PartialLightComputations.A * cosNL +
                bitmapData.PartialLightComputations.B * (float)Math.Pow(cosVR, bitmapData.LightSParams.M);
            for (int i = 0; i < 3; ++i)
            {
                if (color[i] > 1f)
                    color[i] = 1f;
            }
            Color c = Color.FromArgb((int)(color[0] * 255), (int)(color[1] * 255), (int)(color[2] * 255));

            bitmapData.DBitmap.SetPixel(p.X + bitmapData.AdjX, bitmapData.AdjY - p.Y, c);
            //using Brush b = new SolidBrush(c);
            //bitmapData.G.FillRectangle(b, new Rectangle(p.X, p.Y, 1, 1));
        }
    }
}
