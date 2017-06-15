using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FileSystem.Directory
{
    [Serializable]
    [XmlInclude(typeof(Directory))]
    [XmlInclude(typeof(FileItem.File))]
    public abstract class AbstractDirectory
    {
    }
}
