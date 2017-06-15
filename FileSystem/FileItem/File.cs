using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using FileSystem.Directory;
using FileSystem.Visitor;

namespace FileSystem.FileItem
{
    public enum Atribute
    {
        System = 0x1,
        Hidden = 0x2,
        Archive = 0x4,
        ReadOnly = 0x8
    };

    [Serializable]
    [XmlInclude(typeof(Image))]
    [XmlInclude(typeof(Document))]
    public abstract class File : AbstractDirectory
    {
        #region Constants & Readonly

        const int AtributeCount = 4;

        public static readonly List<Atribute> AtributesOrder = new List<Atribute>()
        {
            Atribute.System,
            Atribute.Hidden,
            Atribute.Archive,
            Atribute.ReadOnly
        };

        #endregion

        #region Fields

        private int size;

        public string Name { get; set; }

        public int Size
        {
            get { return size; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Size cannot be null");
                }
                size = value;
            }
        }

        public List<Atribute> Atributes { get; set; }

        #endregion

        #region Constructors

        protected File(string name, int size, IEnumerable<Atribute> atributes)
        {
            Name = name;
            Size = size;
            Atributes = (List<Atribute>) atributes;
        }

        protected File()
        {
            
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            string atr = string.Join(" ", Atributes);
            return $"Name: {Name}\tSize: {Size}\tAtributes: {atr}";
        }

        protected void Clear() => Size = 0;

        protected void Rename(string fileName) => Name = fileName;

        public override void accept(AbstractVisitor visitor)
        {
            visitor.visit(this);
        }

        #endregion
    }
}