using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objects.RotationAndTriangulation;

namespace Objects.Bezier
{
    public class TriangulatedBezierSurface : BezierSufrace
    {
        private int _alpha;
        public int Alpha
        {
            get { return _alpha; }
            set
            {
                if (value == _alpha)
                    return;
                _alpha = value;
                Rotation();
            }
        }
        private int _beta;
        public int Beta
        {
            get { return _beta; }
            set
            {
                if (value == _beta)
                    return;
                _beta = value;
                Rotation();
            }
        }
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
                        _points[i, j].P,
                        _points[i, j + 1].P,
                        _points[i + 1, j].P));
                    tempTriangles.Add(new Triangle(
                        _points[i, j + 1].P,
                        _points[i + 1, j].P,
                        _points[i + 1, j + 1].P));
                }
            }

            _triangles = [.. tempTriangles];
        }

        private void Rotation()
        {
            // TO DO: rotate all the points
        }
    }
}
