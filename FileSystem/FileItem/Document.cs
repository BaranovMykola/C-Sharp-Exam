using System.Collections.Generic;

namespace FileSystem.FileItem
{
    public enum DocumentExtension
    {
        Pdf,
        Docx,
        Doc,
        Odt,
        Txt,
        Xml,
        Xls,
        Xlsx
    };

    public class Document : File
    {
        public string Data { get; set; }

        public DocumentExtension Extension { get; set; }

        public Document(string name, int size, IEnumerable<Atribute> atributes, string data, DocumentExtension extension) : base(name, size, atributes)
        {
            Data = data;
            Extension = extension;
        }

        public Document()
        {
            
        }

        public override string ToString()
        {
            return $"{base.ToString()}\tExtension: {Extension}\n\tData: {Data}";
        }
    }
}
