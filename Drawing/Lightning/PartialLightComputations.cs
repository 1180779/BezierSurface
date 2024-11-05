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
        public Vector3 ATexture { get; set; }
        public Vector3 BTexture { get; set; }
        public PartialLightComputations() { }
        public void Recalculate(ObjectColor objC, LightParameters LightParams,ILightSource lightSource) 
        {
            Vector3 partial = objC.Color0To1 * lightSource.Color0To1;
            A = LightParams.KD * partial;
            B = LightParams.KS * partial;
            ATexture = LightParams.KD * lightSource.Color0To1;
            BTexture = LightParams.KS * lightSource.Color0To1;
        }
    }
}
