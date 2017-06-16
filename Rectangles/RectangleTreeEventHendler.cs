using System;

namespace Rectangles
{
    class RectangleTreeEventHendler
    {
        public static void RemoveHierarchy(object sender, EventArgs args)
        {
            RectangleArgs recArgs = args as RectangleArgs;
            recArgs?.TreeHierarchy?.Clear();
        }
    }
}