using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Numerics;
using System.ComponentModel;

namespace Drawing.Lightning
{
    public interface ILightSource : INotifyPropertyChanged
    {
        public Vector3 Location { get; set; }
        public Color Color { get; set; }
        public Vector3 Color0To1 { 
            get 
            { 
                return new Vector3(
                    (float)Color.R / 255, 
                    (float)Color.G / 255,
                    (float)Color.B / 255); } 
        }
    }
}
