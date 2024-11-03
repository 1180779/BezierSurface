using Objects.RotationAndTriangulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Objects.Lightning;

namespace Drawing.Filling
{
    public interface IPolygonFill
    {
        public void FillPolygon(Triangle p, DrawingData bitmapData);
    }
}
