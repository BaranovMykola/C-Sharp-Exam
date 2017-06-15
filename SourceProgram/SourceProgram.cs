using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using FileSystem;
using FileSystem.Directory;
using FileSystem.FileItem;
using File = FileSystem.FileItem.File;
using Directory = FileSystem.Directory.Directory;

namespace SourceProgram
{
    class SourceProgram
    {
        static void Main(string[] args)
        {
            File img = new Image("img1", 22, new List<Atribute>() {Atribute.Archive, Atribute.System}, new Resolution(100,100), 255, 3, ImageExtension.Gif);
            File doc = new Document("doc1", 2222, new List<Atribute>() {Atribute.Hidden, Atribute.System, Atribute.Archive}, ".....data.....", DocumentExtension.Docx);
            Directory dir = new Directory("DIRECTORY_ROOT", new List<AbstractDirectory>());
            Directory dir1 = new Directory("dir1", new List<AbstractDirectory>() {img, doc});
            dir.Add(dir1);
            using (var stream = System.IO.File.Open("../../dir.xml", FileMode.OpenOrCreate))
            {
                XmlSerializer xml = new XmlSerializer(typeof(AbstractDirectory));
                xml.Serialize(stream, dir);
            }

            Console.ReadKey();
        }
    }
}
