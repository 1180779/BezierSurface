using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Objects.RotationAndTriangulation;
using Objects.Lightning;

namespace Drawing.Filling
{
    public class EdgeList
    {
        public List<EdgeItem> Edges { get; set; }
        public EdgeList() 
        {
            Edges = new List<EdgeItem>();
        }
        public void Update() 
        {
            foreach (var item in Edges) 
            {
                item.Update();
            }
        }
        public void Add(EdgeItem item) { Edges.Add(item); }
        public void AddRange(IEnumerable<EdgeItem> items) { Edges.AddRange(items); }
        public List<EdgeItem> Extract() 
        {
            List<EdgeItem> res = Edges;
            Edges = new();
            return res;
        }
        public bool IsEmpty { get { return Edges.Count == 0; } }
    }



    public class EdgeItem
    {
        public float YMax { get; set; }
        public float XMin { get; set; }
        public float OneOverM { get; set; }
        public float X { get; set; }
        public void Update()
        {
            X += OneOverM;
        }
        public EdgeItem(Edge e) 
        {
            YMax = e.A.PR.Y > e.B.PR.Y ? e.A.PR.Y : e.B.PR.Y;
            XMin = e.A.PR.Y < e.B.PR.Y ? e.A.PR.X : e.B.PR.X;

            //float numenator = (e.A.PR.X - e.B.PR.X);
            //float denominator = (e.A.PR.Y - e.B.PR.Y);
            //if (Math.Abs(numenator) < 0.1f)
            //    numenator = 0.1f * Math.Sign(numenator);
            //if (Math.Abs(denominator) < 0.1f)
            //    denominator = 0.1f * Math.Sign(denominator);
            //OneOverM = numenator / denominator;
            OneOverM = (e.A.PR.X - e.B.PR.X) / (e.A.PR.Y - e.B.PR.Y);
            X = XMin;
        }
    }
}
