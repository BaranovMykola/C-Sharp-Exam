using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileSystem.Directory;

namespace FileSystem.Visitor
{
    public abstract class AbstractVisitor
    {
        public abstract void visit(AbstractDirectory dir);
    }
}
