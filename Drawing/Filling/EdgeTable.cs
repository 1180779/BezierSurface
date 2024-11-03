using Objects.RotationAndTriangulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Drawing.Filling;
using Objects.Lightning;

namespace Drawing.Filling
{
    public class EdgeTable
    {
        public int MinY { get; private set; }
        public int MaxY { get; private set; }
        public List<EdgeList> Edges { get; private set; } = [];

        public bool IsEmpty
        {
            get
            {
                foreach (EdgeList edge in Edges)
                    if (!edge.IsEmpty)
                        return false;
                return true;
            }
        }
        public int Adj { get; private set; }
        public EdgeTable(int height) 
        {
            Adj = height / 2;
            MinY = -Adj;
            MaxY = Adj;
            Edges = new List<EdgeList>(height);
            for (int i = -Adj; i < Adj; ++i) 
            {
                Edges.Add(new EdgeList());
                //this[i] = new EdgeList();
            }
        }
        public void Fill(IPolygon p)
        {
            // TO DO: fill the Edges list
            Edge[] copy = new Edge[p.Edges.Length];
            for(int i = 0; i < p.Edges.Length; ++i)
            {
                copy[i] = p.Edges[i];
            }
            
            Array.Sort(copy, new EdgeComparer());
            foreach(var edge in copy)
            {
                int y = (int)edge.YMinR;
                if (y < -Adj || y >= Adj)
                    continue;
                this[y].Add(new EdgeItem(edge));
            }
        }
        public EdgeList this[int i] 
        {
            get 
            {
                return Edges[i + Adj];
            }
            private set
            {
                Edges[i + Adj] = value;
            }
        }
    }
}
