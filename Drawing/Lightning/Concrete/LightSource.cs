using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            Color = Color.FromArgb(1, 255, 255, 255);
        }
        public LightSource(Vector3 location, Color color)
        {
            Location = location;
            Color = color;
        }
        private Vector3 _location;
        public Vector3 Location 
        { 
            get { return _location; }
            set 
            {
                if (_location == value)
                    return;
                _location = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Location)));
            }
        }
        public Color Color 
        { 
            get { return _color; }
            set 
            {
                if (_color == value)
                    return;
                _color = value;
                _color0To1 = new Vector3(
                    (float)Color.R / 255,
                    (float)Color.G / 255,
                    (float)Color.B / 255);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Color)));
            }
        }
        public Vector3 Color0To1 { get { return _color0To1; } }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
