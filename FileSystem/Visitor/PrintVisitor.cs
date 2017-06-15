using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileSystem.Directory;

namespace FileSystem.Visitor
{
    public class PrintVisitor : AbstractVisitor
    {
        private int depth = -1;
        public override void visit(AbstractDirectory dir)
        {
            //++depth;
            var nextDir = dir as Directory.Directory;
            if (nextDir != null)
            {
                ++depth;
                Retreat(depth);
                Console.WriteLine(nextDir.Name);
                Retreat(depth);
                Console.WriteLine("{");
                //++depth;
                Retreat(depth);
                foreach (var abstractDirectory in nextDir.ChildrenList)
                {
                    abstractDirectory.accept(this);
                }
                --depth;
                Console.WriteLine("}");
            }
            else
            {
                Retreat(depth+1);
                Console.WriteLine(dir);
            }
            Retreat(depth);
            //--depth;
        }

        private void Retreat(int width)
        {
            for (int i = 0; i < width; i++)
            {
                Console.Write("\t");
            }
        }
    }
}
