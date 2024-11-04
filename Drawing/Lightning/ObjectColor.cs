using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.Lightning
{
    public struct ObjectColor
    {
        private Color _color;
        public Color Color 
        {
            get { return _color; }
            set 
            {
                _color = value;
                Color0To1 = new Vector3((float)_color.R / 255, (float)_color.G / 255, (float)_color.B / 255);
            }
        }
        public Vector3 Color0To1 { get; private set; }
        public ObjectColor() 
        {
            Color = Color.FromArgb(0, 255, 0);
        }
        public ObjectColor(Color c)
        {
            Color = c;
        }
    }
}
