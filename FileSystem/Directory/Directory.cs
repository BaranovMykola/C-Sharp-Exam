using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;
using FileSystem.Visitor;

namespace FileSystem.Directory
{
    [Serializable]
    public class Directory : AbstractDirectory
    {
        public string Name { get; set; }

        public List<AbstractDirectory> ChildrenList { get; set; } = new List<AbstractDirectory>();

        public Directory(string name, IEnumerable<AbstractDirectory> childrenList)
        {
            Name = name;
            ChildrenList = childrenList.ToList();
        }

        public Directory()
        {
            
        }

        public void Add(AbstractDirectory item)
        {
            ChildrenList.Add(item);
        }

        public override void accept(AbstractVisitor visitor)
        {
            visitor.visit(this);
        }
    }
}
