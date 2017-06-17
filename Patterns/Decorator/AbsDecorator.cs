using System;
using Patterns.Field;

namespace Patterns.Decorator
{
    class AbsDecorator : IDecorator
    {
        public IField Field { get; set; }

        public AbsDecorator(IField field)
        {
            Field = field;
        }
        public void Print()
        {
            Field.Abs();
            Console.WriteLine($"{Field}");
        }
    }
}