using System;
using System.Collections.Generic;
using System.Linq;

namespace Rectangles
{
    class RectangleTree
    {
        #region Fields & Properties

        public Rectangle ThisRectangle { get; set; }
        public List<RectangleTree> InnerRectangles { get; set; } = new List<RectangleTree>();

        #endregion

        #region Constructors

        public RectangleTree()
        {

        }

        public RectangleTree(Rectangle thisRectangle)
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
            if (newRectangle.IsInner(ThisRectangle) && !ThisRectangle.IsSame(newRectangle))
            {
                var rec = ThisRectangle;
                ThisRectangle = newRectangle;
                InsertRectangle(rec);
                return;
            }

            List<RectangleTree> outer = InnerRectangles.Where(rectangle => rectangle.ThisRectangle.IsInner(rectangle.ThisRectangle)).ToList();

            if (outer.Count > 0)
            {
                RectangleTree min = outer.First();
                foreach (var tree in outer)
                {
                    if (min.ThisRectangle.Squre() < tree.ThisRectangle.Squre())
                    {
                        min = tree;
                    }
                }
                min.InsertRectangle(newRectangle);
                return;
            }

            throw new NotImplementedException();
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
            
        }

    }
}