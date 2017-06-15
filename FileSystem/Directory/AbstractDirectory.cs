using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using FileSystem.Visitor;

namespace FileSystem.Directory
{
    [Serializable]
    [XmlInclude(typeof(Directory))]
    [XmlInclude(typeof(FileItem.File))]
    public abstract class AbstractDirectory
    {
        public abstract void accept(AbstractVisitor visitor);
    }
}
