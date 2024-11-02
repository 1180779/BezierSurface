using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Numerics;

namespace Objects.Basics.Extensions
{
    public static class Vector4Vector3Matrix4x4MultiplicationExtension
    {
        public static Vector3Vector4 Transform(this Vector4 v, Vector3Matrix4x4 V)
        {
            return new Vector3Vector4(
                Vector4.Transform(v, V.X),
                Vector4.Transform(v, V.Y),
                Vector4.Transform(v, V.Z));
        }
    }
}
