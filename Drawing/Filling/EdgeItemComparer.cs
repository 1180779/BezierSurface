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
            return (int)(x.X - y.X);
        }
    }
}
