using Drawing.Basics;
using Objects.Lightning;
using Objects.RotationAndTriangulation;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Drawing.Filling.Concrete
{
    public class BucketPolygonFill : IPolygonFill
    {
        private EdgeTable ET;
        private EdgeList AET;
        //public ILineDraw LineDraw { get; set; }
        public IScanDraw ScanDraw {  get; set; }
        public BucketPolygonFill(IScanDraw scanDraw)
        {
            ScanDraw = scanDraw;
        }
        //public BucketPolygonFill(ILineDraw lineDraw)
        //{
        //    LineDraw = lineDraw;
        //}
        //public void FillPolygonLibrary(IPolygon p, DrawingBitmapData bitmapData)
        //{
        //    Point[] points = new Point[3];
        //    points[0] = new Point((int)p.Vertices[0].PR.X, (int)p.Vertices[0].PR.Y);
        //    points[1] = new Point((int)p.Vertices[1].PR.X, (int)p.Vertices[1].PR.Y);
        //    points[2] = new Point((int)p.Vertices[2].PR.X, (int)p.Vertices[2].PR.Y);
        //    bitmapData.G.FillPolygon(bitmapData.Brush, points);
        //}
        public void FillPolygon(Triangle t, DrawingData bitmapData)
        {
            ET = new EdgeTable(bitmapData.DBitmap.Height);
            ET.Fill(t);
            // ustaw AETjako pusta lista
            AET = new EdgeList();

            // ustaw y na najmniejszą wartość indeksu, dla którego wartość 
            // ET jest niepusta
            int i;
            for (i = -ET.Adj; i < ET.Adj; ++i)
            {
                if (!ET[i].IsEmpty)
                    break;
            }

            // powtarzaj dopóki obie struktury AET i ET nie są puste
            while ((!AET.IsEmpty || !ET.IsEmpty) && i < ET.Adj)
            {
                // przenieś  listy z kubełka ET[y] do AET (ymin = y)
                AET.AddRange(ET[i].Extract());

                // posortuj listę AET wg x
                AET.Edges.Sort(new EdgeItemComparer());

                // TO DO: popraw na poprawną implementacją ze światłem etc.
                // wypełnij piksele pomiędzy parami przecięć
                if (AET.Edges.Count == 1)
                { }
                else if(AET.Edges.Count == 3)
                {
                    ScanDraw.DrawScan(
                        (int)AET.Edges[0].X,
                        (int)AET.Edges[2].X,
                        i,
                        t,
                        bitmapData);
                    //LineDraw.DrawLine(
                    //    new Point((int)AET.Edges[0].X, i),
                    //    new Point((int)AET.Edges[2].X, i),
                    //    bitmapData);
                }
                else
                {
                    for(int j = 0; j < AET.Edges.Count; j += 2)
                    {
                        ScanDraw.DrawScan(
                        (int)AET.Edges[j].X,
                        (int)AET.Edges[j + 1].X,
                        i,
                        t,
                        bitmapData);
                        //LineDraw.DrawLine(
                        //    new Point((int)AET.Edges[j].X, i),
                        //    new Point((int)AET.Edges[j + 1].X, i),
                        //    bitmapData);
                    }
                }

                // usuń z AET te elementy, dla których y = ymax
                AET.Edges.RemoveAll(e => (int)e.YMax == i);

                // zwiększ y o 1 (przejście do następnej scan-linii)
                ++i;

                // dla każdej krawędzi w AET 
                // uaktualnij x dla nowej scanlinii y(x+= 1 / m)
                AET.Update();
            }
        }
    }
}
