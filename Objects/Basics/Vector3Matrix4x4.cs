using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Objects.Basics
{
    // inspired by 
    // https://esezam.okno.pw.edu.pl/mod/book/view.php?id=22&chapterid=249
    public class Vector3Matrix4x4
    {
        private Matrix4x4 _x = new();
        private Matrix4x4 _y = new();
        private Matrix4x4 _z = new();
        public Matrix4x4 X { get { return _x; } }
        public Matrix4x4 Y { get { return _y; } }
        public Matrix4x4 Z { get { return _z; } }
        public Vector3 Point(int i, int j)
        {
            if (i < 0 || i > 3)
                throw new InvalidOperationException();
            if (j < 0 || j > 3)
                throw new InvalidOperationException();
            return new Vector3(_x[i, j], _y[i, j], _z[i, j]);
        }
        public Vector3Matrix4x4(Vertex[,] vMatrix)
        {
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    _x[i, j] = vMatrix[i, j].P.X;
                    _y[i, j] = vMatrix[i, j].P.Y;
                    _z[i, j] = vMatrix[i, j].P.Z;
                }
            }
        }
        public Vector3Matrix4x4(Vector3[,] vMatrix)
        {
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    _x[i, j] = vMatrix[i, j].X;
                    _y[i, j] = vMatrix[i, j].Y;
                    _z[i, j] = vMatrix[i, j].Z;
                }
            }
        }
        public Vector3Matrix4x4(
            Vector3 V00, Vector3 V01, Vector3 V02, Vector3 V03,
            Vector3 V10, Vector3 V11, Vector3 V12, Vector3 V13,
            Vector3 V20, Vector3 V21, Vector3 V22, Vector3 V23,
            Vector3 V30, Vector3 V31, Vector3 V32, Vector3 V33)
        {
            // set X
            _x.M11 = V00.X;
            _x.M12 = V01.X;
            _x.M13 = V02.X;
            _x.M14 = V03.X;

            _x.M21 = V10.X;
            _x.M22 = V11.X;
            _x.M23 = V12.X;
            _x.M24 = V13.X;

            _x.M31 = V20.X;
            _x.M32 = V21.X;
            _x.M33 = V22.X;
            _x.M34 = V23.X;

            _x.M41 = V30.X;
            _x.M42 = V31.X;
            _x.M43 = V32.X;
            _x.M44 = V33.X;

            // set Y
            _y.M11 = V00.Y;
            _y.M12 = V01.Y;
            _y.M13 = V02.Y;
            _y.M14 = V03.Y;

            _y.M21 = V10.Y;
            _y.M22 = V11.Y;
            _y.M23 = V12.Y;
            _y.M24 = V13.Y;

            _y.M31 = V20.Y;
            _y.M32 = V21.Y;
            _y.M33 = V22.Y;
            _y.M34 = V23.Y;

            _y.M41 = V30.Y;
            _y.M42 = V31.Y;
            _y.M43 = V32.Y;
            _y.M44 = V33.Y;

            // set Z
            _z.M11 = V00.Z;
            _z.M12 = V01.Z;
            _z.M13 = V02.Z;
            _z.M14 = V03.Z;

            _z.M21 = V10.Z;
            _z.M22 = V11.Z;
            _z.M23 = V12.Z;
            _z.M24 = V13.Z;

            _z.M31 = V20.Z;
            _z.M32 = V21.Z;
            _z.M33 = V22.Z;
            _z.M34 = V23.Z;

            _z.M41 = V30.Z;
            _z.M42 = V31.Z;
            _z.M43 = V32.Z;
            _z.M44 = V33.Z;
        }


    }
}
