using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Numerics;

using Objects.Lightning;

using System.Numerics;

namespace Objects.RotationAndTriangulation
{
    public class Triangle : IPolygon
    {
        public Vertex A { get; private set; }
        public Vertex B { get; private set; }
        public Vertex C { get; private set; }
        public Edge[] Edges { get; private set; }
        public Vertex[] Vertices { get; private set; }
        public Triangle(Vertex a, Vertex b, Vertex c)
        {
            A = a;
            B = b;
            C = c;
            Edges = new Edge[3];
            Edges[0] = new Edge(A, B);
            Edges[1] = new Edge(A, C);
            Edges[2] = new Edge(B, C);

            Vertices = new Vertex[3];
            Vertices[0] = A;
            Vertices[1] = B;
            Vertices[2] = C;
        }


        public static float Area2DXYTimes2(Vector3 X, Vector3 Y, Vector3 Z)
        {
            return Math.Abs(X.X * (Y.Y - Z.Y) + Y.X * (Z.Y - X.Y) + Z.X * (X.Y - Y.Y));
        }
        public static float Area2DXY(Vector3 X, Vector3 Y, Vector3 Z) => Area2DXYTimes2(X, Y, Z) / 2;

        public static float AreaTimes2(Vector2 X, Vector2 Y, Vector2 Z)
        {
            return Math.Abs(X.X * (Y.Y - Z.Y) + Y.X * (Z.Y - X.Y) + Z.X * (X.Y - Y.Y));
        }
        public static float Area(Vector2 X, Vector2 Y, Vector2 Z) => AreaTimes2(X, Y, Z) / 2;
    }
}
