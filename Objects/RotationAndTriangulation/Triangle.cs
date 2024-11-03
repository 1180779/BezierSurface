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

    }
}
