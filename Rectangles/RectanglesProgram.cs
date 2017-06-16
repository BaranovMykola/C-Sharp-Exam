using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rectangles
{
    class RectanglesProgram
    {
        private static Random rnd = new Random();

        public static List<Rectangle> GenerateRave(int n, int from, int to)
        {
            List<Rectangle> raveList = new List<Rectangle>();
            for (int i = 0; i < n; i++)
            {
                int x1 = rnd.Next(from, to);
                int x2 = rnd.Next(x1, to);

                int y1 = rnd.Next(from, to);
                int y2 = rnd.Next(y1, to);
                raveList.Add( new Rectangle(x1, y1, x2, y2));
            }
            return raveList;
        }

        static void Main(string[] args)
        {
            Plane plane = new Plane();

            var rave = GenerateRave(5, 0, 11);
            foreach (var rectangle in rave)
            {
                plane.Add(rectangle);
            }

            Console.ReadKey();
        }
    }
}
