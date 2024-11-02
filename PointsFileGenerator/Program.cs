using System.Drawing;
using System.Numerics;

namespace PointsFileGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName = "./Points.txt";
            Size size = new Size(0, 0);
            int fillPercent = 0;

            Console.WriteLine("Provide canvas width: ");
            size.Width = int.Parse(Console.ReadLine());
            Console.WriteLine("\tand height: ");
            size.Height = int.Parse(Console.ReadLine());

            Console.WriteLine("Provide canvas fill percentage (1-99): ");
            fillPercent = int.Parse(Console.ReadLine());

            Vector3Int[,] v = new Vector3Int[4,4];
            Size sizeToFill = size * fillPercent / 100;
            Size sizeStep = sizeToFill / 3;
            Size centering = sizeToFill / 2;

            PointsFunc func = new PointsFunc();

            var stream = new StreamWriter(fileName);
            for(int i = 0; i < 4; ++i)
            {
                for(int j = 0; j < 4; ++j)
                {
                    int x = sizeStep.Width * j - centering.Width;
                    int y = sizeStep.Height * i - centering.Height;
                    Vector3Int u = new Vector3Int(x, y, func.Z(x, y));
                    stream.WriteLine($"{u}");
                }
            }
            stream.Close();
            Console.WriteLine("Saved!");
        }
    }
}
