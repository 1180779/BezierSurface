using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Numerics;

namespace Objects.Basics
{
    public class Vector3Vector4
    {
        Vector4 _x;
        Vector4 _y;
        Vector4 _z;
        public Vector4 X { get { return _x; } }
        public Vector4 Y { get { return _y; } }
        public Vector4 Z { get { return _z; } }
        public Vector3Vector4(Vector4 x, Vector4 y, Vector4 z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        public Vector3Vector4 Transform(Matrix4x4 M)
        {
            return new Vector3Vector4(
                Vector4.Transform(X, M),
                Vector4.Transform(Y, M),
                Vector4.Transform(Z, M));
        }

        public Vector3 Dot(Vector4 v)
        {
            return new Vector3(
                Vector4.Dot(X, v),
                Vector4.Dot(Y, v),
                Vector4.Dot(Z, v));
        }
    }
}
