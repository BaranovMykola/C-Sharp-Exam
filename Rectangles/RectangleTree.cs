using System;
using System.Collections.Generic;
using System.Linq;

namespace Rectangles
{
    [Serializable]
    public class RectangleTree
    {
        #region Fields & Properties

        public Rectangle ThisRectangle { get; set; }
        public List<RectangleTree> InnerRectangles { get; set; } = new List<RectangleTree>();
        public event EventHandler<EventArgs> OnMaxInners;

        #endregion

        #region Constructors

        public RectangleTree()
        {
            OnMaxInners += RectangleTreeEventHendler.RemoveHierarchy;
        }

        public RectangleTree(Rectangle thisRectangle): this()
        {
            ThisRectangle = thisRectangle;
        }

        public RectangleTree(Rectangle thisRectangle, List<RectangleTree> innerRectangle) : this(thisRectangle)
        {
            InnerRectangles = innerRectangle;
        }

        #endregion

        public void InsertRectangle(Rectangle newRectangle)
        {
            if (ThisRectangle != null && newRectangle.IsInner(ThisRectangle) && !ThisRectangle.IsSame(newRectangle))
            {
                var rec = ThisRectangle;
                ThisRectangle = newRectangle;
                InsertRectangle(rec);
                return;
            }

            List<RectangleTree> outer = new List<RectangleTree>();
            foreach (var tree in InnerRectangles)
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
            InnerRectangles.Add(new RectangleTree(newRectangle));
            if (InnerRectangles.Count >= RectanglesProgram.n_max)
            {
                OnMaxInners?.Invoke(this, new RectangleArgs(InnerRectangles));
            }
        }

        public void InsertRectangle(List<Rectangle> newRectangles)
        {
            foreach (var newRectangle in newRectangles)
            {
                InsertRectangle(newRectangle);
            }
        }

        public void Print()
        {
            if (ThisRectangle != null)
            {
                Console.Write($"{ThisRectangle}\t--->\t");
            }
            foreach (var rectangle in InnerRectangles)
            {
                rectangle.Print();
                if(rectangle == InnerRectangles.Last()) continue;
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("***********************************");
                Console.WriteLine();
            }
        }

        public List<Rectangle> GetAllRectangles()
        {
            List<Rectangle> lst = new List<Rectangle> {ThisRectangle};
            foreach (var rectangle in InnerRectangles)
            {
                lst.AddRange(rectangle.GetAllRectangles());
            }
            return lst;
        }

    }
}