using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.Lightning
{
    public class ObjectColor
    {
        private Color _color = Color.Green;
        public Color Color 
        {
            get { return _color; }
            set 
            {
                if (value == _color)
                    return;
                _color = value;
                Color0To1 = new Vector3((float)_color.R / 255, (float)_color.G / 255, (float)_color.B / 255);
            }
        }
        public Vector3 Color0To1 { get; private set; }
        public ObjectColor() { }
        public ObjectColor(Color c)
        {
            Color = c;
        }
    }
}
