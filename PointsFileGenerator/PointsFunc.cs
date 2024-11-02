using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointsFileGenerator
{
    public class PointsFunc
    {
        public PointsFunc() { }
        // bezier surface is functional with respect to the xy plane
        public int Z (int x, int y)
        {
            return x * y;
        }
    }
}
