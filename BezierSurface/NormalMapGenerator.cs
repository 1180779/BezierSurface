using Objects.Bezier;
using Objects.RotationAndTriangulation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Numerics;
using System.Windows.Forms.Design;

namespace BezierSurface
{
    public static class NormalMapGenerator
    {
        public static void Generate(int min, int max, string fileName = "generated.jpeg")
        {
            Bitmap bmp = new Bitmap(512, 512);

            double range = max - min;
            double shift = range / 2;
            for(int x = 0; x < 512; x++)
            {
                for(int y = 0; y < 512; y++)
                {
                    double u = ((float)x / 512) * range - shift;
                    double v = ((float)y / 512) * range - shift;
                    //double z = Math.Sin((u * u + v * v) / 9);

                    Vector3 U = new Vector3(
                        1, 
                        (float)0, 
                        (float)((float)2 / 9 * u * Math.Cos((u * u + v * v) / 9)));
                    Vector3 V = new Vector3(
                        (float)0, 
                        1, 
                        (float)((float)2 / 9 * v * Math.Cos((u * u + v * v) / 9)) );

                    Vector3 N = Vector3.Cross(U, V);
                    N = Vector3.Normalize(N);
                    if (N.X is float.NaN)
                        N = new Vector3(0, 0, 0);

                    Color c = Color.FromArgb(
                        (int) (N.X * 127 + 128),
                        (int) (N.Y * 127 + 128),
                        (int) ((N.Z * 127) + 128)
                        );
                    bmp.SetPixel(x, y, c);
                }
            }
            bmp.Save(fileName, ImageFormat.Jpeg);
        }
    }
}
