using Objects.RotationAndTriangulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Objects.Lightning;
using Drawing.Basics;

namespace Drawing.Filling
{
    public interface IPolygonFill
    {
        public void FillPolygon(IPolygon p, DrawingBitmapData bitmapData);
    }
}
