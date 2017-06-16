using System;

namespace Rectangles
{
    class Plane
    {
        public RectangleTree FiguresHierarchy { get; set; }

        public Plane()
        {
            
        }

        public Plane(RectangleTree tree)
        {
            FiguresHierarchy = tree;
        }

        public void Add(Rectangle newRectangle)
        {
            if (FiguresHierarchy == null)
            {
                FiguresHierarchy = new RectangleTree(newRectangle);
                return;
            }
            FiguresHierarchy.InsertRectangle(newRectangle);
        }
    }
}