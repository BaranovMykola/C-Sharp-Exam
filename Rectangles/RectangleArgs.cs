using System;
using System.Collections.Generic;

namespace Rectangles
{
    class RectangleArgs : EventArgs
    {
        public List<RectangleTree> TreeHierarchy { get; set; }

        public RectangleArgs(List<RectangleTree> treeHirerarchy)
        {
            TreeHierarchy = treeHirerarchy;
        }
    }
}