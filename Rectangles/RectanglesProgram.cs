using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Rectangles
{
    class RectanglesProgram
    {
        public const int n_max = 2;

        private static readonly Random rnd = new Random();

        public static List<Rectangle> GenerateRave(int n, int from, int to)
        {
            List<Rectangle> raveList = new List<Rectangle>();
            for (int i = 0; i < n; i++)
            {
                //[0;10]
                int x1 = rnd.Next(from, to); // 3
                int x2 = rnd.Next(x1, to); // 8

                int y2 = rnd.Next(from, to); 
                int y1 = rnd.Next(y2, to); 
                raveList.Add( new Rectangle(x1, y1, x2, y2));
            }
            return raveList;
        }

        public static void Serialize(Plane rootPlane, string fileName)
        {
            using (var stream = File.Open($"../../{fileName}.xml", FileMode.OpenOrCreate, FileAccess.Write))
            {
                XmlSerializer xml = new XmlSerializer(typeof(Plane));
                xml.Serialize(stream, rootPlane);
            }
        }

        public static Plane Deserialize(string fileName)
        {
            using (var stream = File.Open($"../../{fileName}.xml", FileMode.Open, FileAccess.Read))
            {
                XmlSerializer xml = new XmlSerializer(typeof(Plane));
                Plane plane = xml.Deserialize(stream) as Plane;
                return plane;
            }
        }

        static void Main(string[] args)
        {
            //Plane plane = new Plane();
            Plane root = new Plane();

            var rave = GenerateRave(100, 0, 11);
            foreach (var rectangle in rave)
            {
                root.Add(rectangle);
            }
            Rectangle r1 = new Rectangle(0,10,10,0);
            Rectangle r2 = new Rectangle(1, 9, 9, 1);

            Rectangle r3 = new Rectangle(0, 9, 9, 2);
            Rectangle r4 = new Rectangle(0, 10, 10, 8);

            root.Add(r1);
            root.Add(r2);
            root.Add(r3);
            root.Add(r4);

            //root.Print();
            //Serialize(root, "Plane");
            var rootSer = Deserialize("Plane");
            foreach (var rectangle in root.GetAllRectangles())
            {
                rootSer.Add(rectangle);
            }
            rootSer.Print();

            

            Console.ReadKey();
        }
    }
}
