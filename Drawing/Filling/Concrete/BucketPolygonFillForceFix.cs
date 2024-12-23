﻿using Drawing.Basics;
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
    public class BucketPolygonFillForceFix : IPolygonFill
    {
        public IScanDraw ScanDraw {  get; set; }
        public BucketPolygonFillForceFix(IScanDraw scanDraw)
        {
            ScanDraw = scanDraw;
        }
        public void FillPolygon(Triangle t, DrawingData bitmapData)
        {
            EdgeTable ET = new EdgeTable(bitmapData.DBitmap.Height);
            ET.Fill(t);
            // ustaw AETjako pusta lista
            EdgeList AET = new EdgeList();

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
                AET.AddRange(ET.Extract(i));

                // posortuj listę AET wg x
                AET.Edges.Sort(new EdgeItemComparer());

                // wypełnij piksele pomiędzy parami przecięć
                if (AET.Edges.Count == 1)
                {
                    ScanDraw.DrawScan(
                        (int)(AET.Edges[0].X),
                        (int)(AET.Edges[0].X),
                        i,
                        t,
                        bitmapData);
                }
                else if(AET.Edges.Count == 3)
                {
                    ScanDraw.DrawScan(
                        (int)(AET.Edges[0].X),
                        (int)(AET.Edges[2].X),
                        i,
                        t,
                        bitmapData);
                }
                else
                {
                    for (int j = 0; j < AET.Edges.Count; j += 2)
                    {
                        ScanDraw.DrawScan(
                        (int)(AET.Edges[j].X),
                        (int)(AET.Edges[j + 1].X),
                        i,
                        t,
                        bitmapData);
                    }
                }

                // usuń z AET te elementy, dla których y = ymax
                AET.Edges.RemoveAll(e => e.YMax == i); 

                // zwiększ y o 1 (przejście do następnej scan-linii)
                ++i;

                // dla każdej krawędzi w AET 
                // uaktualnij x dla nowej scanlinii y(x+= 1 / m)
                AET.Update();

                // fix wrong Xs by force
                AET.Edges.ForEach(e =>
                {
                    if (e.X < e.EXMin)
                        e.X = e.EXMin;
                    else if (e.X > e.EXMax)
                        e.X = e.EXMax;
                });
            }
        }
    }
}
