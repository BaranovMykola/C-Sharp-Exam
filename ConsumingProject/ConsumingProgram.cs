using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumingProject
{
    class ConsumingProgram
    {
        static void Main(string[] args)
        {
            TestClassLibrary.TestClass.Foo();
            Console.ReadKey();
        }
    }
}
