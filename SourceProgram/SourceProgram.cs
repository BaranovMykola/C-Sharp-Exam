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
using FileSystem.Visitor;
using File = FileSystem.FileItem.File;
using Directory = FileSystem.Directory.Directory;

namespace SourceProgram
{
    class SourceProgram
    {
        private static readonly string[] fileNames = "Another limitation: The Print option won't show up if the files are of different types--even if all types are printable. For instance, you can select and print multiple .jpgs and multiple .docxs, but not .jpgs and .docxs together. The workaround for this is to group the folder by type (right-click a blank spot in Windows Explorer and select Group>Type), and select and print one type at a time.".Split(' ');

        private static string data =
            "wanted to modularize a Visual Studio Web Application developed at my office.However, when I try to think of modularizing the Visual Studio Web Application into different Web Applications, the circular dependency between components comes up which is Wrong.For example, I can't modularize the POCO project for each of the planned Web Application because there is too much dependency. Is there a way I could use Nuget to help with Modularizing?";

        static Random rnd = new Random();
        public static List<File> GenerateDocs(int n)
        {
            List<File> lst = new List<File>();
            for (int i = 0; i < n; i++)
            {
                int from = rnd.Next(0, data.Length);
                int to = rnd.Next(0, data.Length-from);
                var file = new Document(
                    fileNames[rnd.Next(0, fileNames.Length-1)],
                    rnd.Next(),
                    GenerateAtributes(),
                    data.Substring(from, to),
                    GenerateDocumentExtension()
                    );
                lst.Add(file);
            }
            return lst;
        }

        public static List<File> GenerateImg(int n)
        {
            List<File> lst = new List<File>();
            for (int i = 0; i < n; i++)
            {
                var file = new Image(
                    fileNames[rnd.Next(0, fileNames.Length - 1)],
                    rnd.Next(),
                    GenerateAtributes(),
                    new Resolution(rnd.Next(0, 2000), rnd.Next(0, 2000)),
                    rnd.Next(1, 1025),
                    rnd.Next(1, 5),
                    GenerateImageExtension()
                    );
                lst.Add(file);
            }
            return lst;
        }

        public static List<File> GenerateRave(int n)
        {
            int lower = rnd.Next(1, n+1);
            int upper = n - lower;
            List<File> lst = GenerateDocs(lower);
            lst.AddRange(GenerateImg(upper));
            int i = lst.Count;
            while (i > 1)
            {
                i--;
                int k = rnd.Next(i + 1);
                var value = lst[k];
                lst[k] = lst[i];
                lst[i] = value;
            }
            return lst;
        }

        public static List<Atribute> GenerateAtributes()
        {
            List<Atribute> lst = new List<Atribute>();
            for (int i = 0; i < 4; i++)
            {
                if (rnd.Next(0, 2) == 1)
                {
                    lst.Add(File.AtributesOrder[i]);
                }
            }
            return lst;
        }

        public static DocumentExtension GenerateDocumentExtension()
        {
            List<DocumentExtension> lst = new List<DocumentExtension>()
            {
                DocumentExtension.Doc,
                DocumentExtension.Docx,
                DocumentExtension.Odt,
                DocumentExtension.Pdf,
                DocumentExtension.Txt,
                DocumentExtension.Xls,
                DocumentExtension.Xlsx,
                DocumentExtension.Xml
            };
            return lst[rnd.Next(0, lst.Count)];
        }

        public static ImageExtension GenerateImageExtension()
        {
            List<ImageExtension> lst = new List<ImageExtension>()
            {
                ImageExtension.Bnp,
                ImageExtension.Gif,
                ImageExtension.Jpeg,
                ImageExtension.Jpg,
                ImageExtension.Png
            };
            return lst[rnd.Next(0, lst.Count)];
        }

        public static void Serialize<T>(T dir, string fileName)
        {
            System.IO.File.WriteAllText($"../../{fileName}.xml", string.Empty);
            using (var stream = System.IO.File.Open($"../../{fileName}.xml", FileMode.OpenOrCreate))
            {
                XmlSerializer xml = new XmlSerializer(typeof(T));
                xml.Serialize(stream, dir);
            }
        }

        public static T Deserialize<T>(string fileName)
        {
            T var;
            using (var stream = System.IO.File.Open($"../../{fileName}.xml", FileMode.Open, FileAccess.Read))
            {
                XmlSerializer xml = new XmlSerializer(typeof(T));
                var = (T)xml.Deserialize(stream);
            }
            return var;
        }

        static void Main(string[] args)
        {
            Directory root = new Directory("ROOT");
            Directory leftDirectory = new Directory("LEFT_DIR");
            Directory leftleftDirectory = new Directory("LEFT_LEFT_DIR");
            Directory rightDirectory = new Directory("RIGHT_DIR");
            Directory rightleftDirectory = new Directory("RIGHT_LEFT_DIR");
            Directory rightrightDirectory = new Directory("RIGHT_RIGHT_DIR");

            rightrightDirectory.Add(GenerateRave(3));
            rightleftDirectory.Add(GenerateRave(4));
            rightDirectory.Add(GenerateRave(2));
            leftleftDirectory.Add(GenerateRave(5));
            leftDirectory.Add(GenerateRave(1));

            leftleftDirectory.Add(leftDirectory);

            rightDirectory.Add(rightrightDirectory);
            rightDirectory.Add(rightleftDirectory);

            root.Add(leftDirectory);
            root.Add(rightDirectory);

            PrintVisitor print = new PrintVisitor();
            //print.visit(root);

            //Serialize(root, "dir");

            var t = Deserialize<Directory>("dir");
            print.visit(t);
            //Console.WriteLine("{0,10}", "ttt");
            //using (var stream = System.IO.File.Open($"../../dirxml", FileMode.OpenOrCreate))
            //{
            //    XmlSerializer xml = new XmlSerializer(typeof());
            //    xml.Serialize(stream, xml);
            //}

            Console.ReadKey();
        }
    }
}
