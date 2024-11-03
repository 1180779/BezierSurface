using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.Lightning.Concrete
{
    public struct LightSource : ILightSource
    {
        private Color _color;
        private Vector3 _color0To1;
        public LightSource(Vector3 location)
        {
            Location = location;
            _color = Color.FromArgb(1, 255, 255, 255);
        }
        public LightSource(Vector3 location, Color color)
        {
            Location = location;
            _color = color;
            _color0To1 = new Vector3(
                    (float)Color.R / 255,
                    (float)Color.G / 255,
                    (float)Color.B / 255);
        }
        public Vector3 Location { get; set; }
        public Color Color 
        { 
            get { return _color; }
            set 
            {
                if (_color == value)
                    return;
                _color0To1 = new Vector3(
                    (float)Color.R / 255,
                    (float)Color.G / 255,
                    (float)Color.B / 255);
            }
        }
        public Vector3 Color0To1 { get { return _color0To1; } }
    }
}
