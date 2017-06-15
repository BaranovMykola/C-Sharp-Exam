using System.Collections.Generic;

namespace FileSystem.FileItem
{
    public enum ImageExtension
    {
        Jpg,
        Jpeg,
        Bnp,
        Png,
        Gif
    };

    public class Image : File
    {
        public Resolution Resolution { get; set; }

        public int Depth { get; set; }

        public int Channels { get; set; }

        public ImageExtension Extension { get; set; }

        public Image(string name, int size, IEnumerable<Atribute> atributes, Resolution resolution, int depth, int channels, ImageExtension extension) : base(name, size, atributes)
        {
            Resolution = resolution;
            Depth = depth;
            Channels = channels;
            Extension = extension;
        }

        public Image()
        {
            
        }

        public override string ToString() => $"{base.ToString()}\n\tResolution: {Resolution}\tDepth: {Depth}\tChannels: {Channels}\tExtension {Extension}";
    }
}
