using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patterns.Field;

namespace Patterns.Decorator
{
    internal interface IDecorator
    {
        IField Field { get; set; }
        void Print();
    }
}
