using Objects.RotationAndTriangulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects.Lightning
{
    public class Edge
    {
        public Vertex A {  get; set; }
        public Vertex B { get; set; }
        public float YMinR { get { return A.PR.Y < B.PR.Y ? A.PR.Y : B.PR.Y; } }
        public Edge(Vertex a, Vertex b) 
        {  
            A = a; 
            B = b; 
        }
    }
}
