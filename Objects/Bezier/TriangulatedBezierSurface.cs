﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objects.RotationAndTriangulation;

using System.Numerics;

namespace Objects.Bezier
{
    public class TriangulatedBezierSurface : BezierSufrace
    {
        private int _n = 0;
        public int N
        {
            get { return _n; }
            set
            {
                if (value == _n)
                    return;
                _n = value;
                Triangulation();
                Rotation();
            }
        }
        public Vertex[,] TrianglePoints { get { return _points; } }
        private Vertex[,] _points = new Vertex[0, 0];
        private Triangle[] _triangles = [];
        public Triangle[] Triangles { get { return _triangles; } }
        public TriangulatedBezierSurface(string file, int n) : base(file)
        {
            if (n < 4)
                throw new InvalidDataException();
            N = n;
            Alpha = 0;
            Beta = 0;
        }

        // triangulation
        private void Triangulation()
        {
            _points = new Vertex[N + 1, N + 1];
            float step = 1f / N;
            {
                int i = 0, j;
                for (float u = 0f; u <= 1f + step / 2; u += step, ++i)
                {
                    j = 0;
                    for (float v = 0f; v <= 1f + step / 2; v += step, ++j)
                    {
                        _points[i, j] = new Vertex();
                        _points[i, j].P = P(u, v);
                    }
                }
            }

            List<Triangle> tempTriangles = [];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    tempTriangles.Add(new Triangle(
                        _points[i, j],
                        _points[i, j + 1],
                        _points[i + 1, j]));
                    tempTriangles.Add(new Triangle(
                        _points[i, j + 1],
                        _points[i + 1, j],
                        _points[i + 1, j + 1]));
                }
            }

            _triangles = [.. tempTriangles];
        }

        protected override (Quaternion ZR, Quaternion XR) Rotation()
        {
            var (rotationZ, rotationX) = base.Rotation();

            if(N <= 0)
                return (rotationZ, rotationX);

            for(int i = 0; i <= N; ++i)
            {
                for(int j = 0; j <= N; j++)
                {
                    _points[i, j].PR = Vector3.Transform(Vector3.Transform(_points[i, j].P, rotationZ), rotationX);
                }
            }
            return (rotationZ, rotationX);
        }
    }
}