using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.Filling
{
    public class EdgeItemComparer : IComparer<EdgeItem>
    {
        public int Compare(EdgeItem? x, EdgeItem? y)
        {
            float val = x.X - y.X;
            if (val < 0f) return -1;
            if (val > 0f) return 1;
            return 0;
        }
    }
}
