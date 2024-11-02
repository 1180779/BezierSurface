using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Numerics;

namespace Objects.Basics.Extensions
{
    public static class Vector3ReaderExtension
    {
        public static void ReadFromLine(this ref Vector3 v, string line)
        {
            line = line.Trim();
            var split = line.Split(',');
            v.X = float.Parse(split[0]);
            v.Y = float.Parse(split[1]);
            v.Z = float.Parse(split[2]);
        }
    }
}
