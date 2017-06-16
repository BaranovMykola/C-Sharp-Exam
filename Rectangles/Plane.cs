using System;
using System.Collections.Generic;
using System.Linq;

namespace Rectangles
{
    [Serializable]
    public class Plane
    {
        public List<RectangleTree> FiguresHierarchy { get; set; } = new List<RectangleTree>();

        public Plane()
        {

        }

        public Plane(List<RectangleTree> tree)
        {
            FiguresHierarchy = tree;
        }

        public void Add(Rectangle newRectangle)
        {
            List<RectangleTree> outer = new List<RectangleTree>();
            foreach (var tree in FiguresHierarchy)
            {
                if (tree.ThisRectangle.IsInner(newRectangle))
                {
                    outer.Add(tree);
                }
            }

            if (outer.Count > 0)
            {
                RectangleTree min = outer.First();
                foreach (var tree in outer)
                {
                    if (min.ThisRectangle.Square() < tree.ThisRectangle.Square())
                    {
                        min = tree;
                    }
                }
                min.InsertRectangle(newRectangle);
                return;
            }
            FiguresHierarchy.Add(new RectangleTree(newRectangle));
        }

        public void Print()
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine();
            foreach (var tree in FiguresHierarchy)
            {
                tree.Print();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("--------------------------");
                Console.WriteLine();
            }
        }

        public List<Rectangle> GetAllRectangles()
        {
            List<Rectangle> lst = new List<Rectangle>();
            foreach (var rectangle in FiguresHierarchy)
            {
                lst.AddRange(rectangle.GetAllRectangles());
            }
            return lst;
        }
    }
}