namespace Rectangles
{
    struct Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString() => $"[{X},{Y}]";

        public static bool operator==(Point left, Point right) => left.X == right.X && left.Y == right.Y;

        public static bool operator !=(Point left, Point right) => !(left == right);
    }
}