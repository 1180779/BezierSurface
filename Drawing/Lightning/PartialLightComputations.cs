using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.Lightning
{
    public struct PartialLightComputations
    {
        public Vector3 A { get; set; }
        public Vector3 B { get; set; }
        public PartialLightComputations() { }
        public void Recalculate(ObjectColor objC, LightParameters LightParams,ILightSource lightSource) 
        {
            Vector3 partial = objC.Color0To1 * lightSource.Color0To1;
            A = LightParams.kd * partial;
            B = LightParams.ks * partial;
        }
    }
}
