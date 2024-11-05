using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace Objects.RotationAndTriangulation
{
    public class Vertex
    {
        public float U {  get; set; }
        public float V { get; set; }
        // before rotation
        public Vector3 P { get; set; } // point BEFORE rotation
        public Vector3 Pu { get; set; } // tangent vector along the u constant parameter line BEFORE rotation
        public Vector3 Pv { get; set; } // tangent vector along the v constant parameter line BEFORE rotation
        public Vector3 N { get; set; } // normal vector BEFORE rotation

        // after rotation
        public Vector3 PR { get; set; } // point AFTER rotation
        public Vector3 PuR { get; set; } // tangent vector along the u constant parameter line AFTER rotation
        public Vector3 PvR { get; set; } // tangent vector along the v constant parameter line AFTER rotation
        public Vector3 NR { get; set; } // normal vector AFTER rotation
    }
}
