using System;

namespace FileSystem.FileItem
{
    [Serializable]
    public struct Resolution
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public Resolution(int height, int width)
        {
            Height = height;
            Width = width;
        }
    }
}
