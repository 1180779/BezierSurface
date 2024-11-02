﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Objects.Basics.Extensions;

namespace Objects.Basics
{
    public class BezierSufrace
    {
        public static readonly Matrix4x4 B =
            new(-1, 3, -3, 1,
                 3, -6, 3, 0,
                -3, 3, 0, 0,
                 1, 0, 0, 0);
        public static readonly Matrix4x4 BTransposed;
        static BezierSufrace()
        {
            BTransposed = Matrix4x4.Transpose(B);
        }

        public Vector3Matrix4x4 V { get { return _V; } }
        private Vector3Matrix4x4 _V;
        public Vector3[,] Points { get { return _v; } }
        private Vector3[,] _v;

        public BezierSufrace(string file)
        {
            var stream = new StreamReader(file);
            _v = new Vector3[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; ++j)
                {
                    var line = stream.ReadLine() ?? throw new InvalidDataException();
                    Vector3 vec = new();
                    vec.ReadFromLine(line);
                    _v[i, j] = vec;
                }
            }
            stream.Close();
            _V = new Vector3Matrix4x4(_v);
        }

        public Vector3 this[int i, int j]
        {
            get { return _v[i, j]; }
            set { _v[i, j] = value; }
        }

        public Vector3 P(float u, float v)
        {
            Vector4 uV = new(u * u * u, u * u, u, 1);
            Vector4 vV = new(v * v * v, v * v, v, 1);

            // add brackets in order to not reapeat computations
            var A = Vector4.Transform(uV, B);
            var C = Vector4.Transform(vV, BTransposed);

            float x = Vector4.Dot(Vector4.Transform(A, V.X), C);
            float y = Vector4.Dot(Vector4.Transform(A, V.Y), C);
            float z = Vector4.Dot(Vector4.Transform(A, V.Z), C);

            return new Vector3(x, y, z);
            // slower but cooooooler!
            //return Vector4.Transform(uV, B).Transform(V).Transform(BTransposed).Dot(vV);
        }

        // tangent vector along the u constant parameter line
        public Vector3 Pu(float u, float v)
        {
            // check is valid !!!
            Vector4 uV = new(u * u * u, u * u, u, 1);
            Vector4 vV = new(3 * v * v, 2 * v, 1, 0);
            return Vector4.Transform(uV, B).Transform(V).Transform(BTransposed).Dot(vV);
        }

        // tangent vector along the v constant parameter line
        public Vector3 Pv(float u, float v)
        {
            // check is valid !!!
            Vector4 uV = new(3 * u * u, 2 * u, 1, 0);
            Vector4 vV = new(v * v * v, v * v, v, 1);
            return Vector4.Transform(uV, B).Transform(V).Transform(BTransposed).Dot(vV);
        }
    }
}