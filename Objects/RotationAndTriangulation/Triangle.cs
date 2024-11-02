using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Numerics;

namespace Objects.RotationAndTriangulation
{
    public class Triangle
    {
        public Vertex A = new();
        public Vertex B = new();
        public Vertex C = new();
        public Triangle() { }
        public Triangle(Vector3 a, Vector3 b, Vector3 c)
        {
            A.P = a;
            B.P = b;
            C.P = c;
        }

    }
}
