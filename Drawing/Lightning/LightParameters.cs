using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.Lightning
{
    public struct LightParameters
    {
        public float kd {  get; set; }
        public float ks { get; set; }
        public float m {  get; set; }
        public LightParameters() 
        {
            kd = ks = 0.5f;
            m = 1;
        }
    }
}
