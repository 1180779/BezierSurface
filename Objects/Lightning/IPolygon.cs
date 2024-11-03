using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Numerics;

using Objects.RotationAndTriangulation;

namespace Objects.Lightning
{
    public interface IPolygon
    {
        public Edge[] Edges { get; }
        public Vertex[] Vertices { get; }
    }
}
