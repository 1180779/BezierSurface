using Objects.RotationAndTriangulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.Lightning
{
    public static class BarycentricCoordinatesCalculator
    {
        public static Vector3 GetBarycentric(Point p, Triangle t)
        {
            Vector3 P = new Vector3(p.X, p.Y, 0);

            // TO DO:
            // change to faster method

            //float AreaABC = Triangle.Area2DXYTimes2(t.A.PR, t.B.PR, t.C.PR);
            //float AreaPBC = Triangle.Area2DXYTimes2(P, t.B.PR, t.C.PR);
            //float AreaPCA = Triangle.Area2DXYTimes2(P, t.C.PR, t.A.PR);
            //float AreaPAB = Triangle.Area2DXYTimes2(P, t.A.PR, t.B.PR);

            //float Lambda1 = AreaPBC / AreaABC;
            //float Lambda2 = AreaPCA / AreaABC;
            //float Lambda3 = AreaPAB / AreaABC;

            float detABC = (t.B.PR.Y - t.C.PR.Y) * (t.A.PR.X - t.C.PR.X) +
                (t.C.PR.X - t.B.PR.X) * (t.A.PR.Y - t.C.PR.Y);

            float Lambda1 = ((t.B.PR.Y - t.C.PR.Y) * (p.X - t.C.PR.X)
                + (t.C.PR.X - t.B.PR.X) * (p.Y - t.C.PR.Y)) / detABC;
            float Lambda2 = ((t.C.PR.Y - t.A.PR.Y) * (p.X - t.C.PR.X)
                + (t.A.PR.X - t.C.PR.X) * (p.Y - t.C.PR.Y)) / detABC;
            float Lambda3 = 1 - Lambda1 - Lambda2;
            return new Vector3(Lambda1, Lambda2, Lambda3);
        }
    }
}
