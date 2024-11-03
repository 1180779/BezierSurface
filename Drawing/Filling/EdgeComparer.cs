using Objects.RotationAndTriangulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Objects.Lightning;

namespace Drawing.Filling
{
    public class EdgeComparer : IComparer<Edge>
    {
        public int Compare(Edge? x, Edge? y)
        {
            if(x is null || y is null) 
                return 0;
            float val = x.YMinR - y.YMinR;
            if (val < 0f) return -1;
            if (val > 0f) return 1;
            return 0;
        }
    }
}
