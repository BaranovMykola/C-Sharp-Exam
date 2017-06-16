using System;

namespace Rectangles
{
    [Serializable]
    public class Rectangle
    {
        #region Fields & Properties

        public Point First { get; set; }
        public Point Second { get; set; }

        #endregion

        #region Constructors

        public Rectangle()
        {

        }

        public Rectangle(Point first, Point second)
        {
            First = first;
            Second = second;
        }

        public Rectangle(int x1, int y1, int x2, int y2) : this(new Point(x1, y1), new Point(x2, y2))
        {

        }

        #endregion

        public override string ToString() => $"Rectangle:\t{First} -> {Second}";

        public bool IsInner(Rectangle otherRectangle)
        {
            return otherRectangle.First.X >= First.X && otherRectangle.First.Y <= First.Y &&
                   otherRectangle.Second.X <= Second.X && otherRectangle.Second.Y >= Second.Y;
        }

        public int Square() => (Second.X - First.X)*(First.Y - Second.Y);

        public bool IsSame(Rectangle ohteRectangle) => ohteRectangle.First == First && ohteRectangle.Second == Second;
    }
}