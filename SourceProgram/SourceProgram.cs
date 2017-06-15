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
        public static List<File> GenerateFiles(int n)
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

        static void Main(string[] args)
        {
            var bred = GenerateFiles(100);
            foreach (var file in bred)
            {
                Console.WriteLine(file);
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
