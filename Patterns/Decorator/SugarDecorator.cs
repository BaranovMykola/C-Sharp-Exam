using System;
using Patterns.Field;

namespace Patterns.Decorator
{
    class SugarDecorator : IDecorator
    {
        public IField Field { get; set; }

        public SugarDecorator(IField field)
        {
            Field = field;
        }

        public void Print()
        {
            var r = Field as R;
            var c = Field as C;
            Console.WriteLine(r != null ? $"***{r}***" : $"***{c.Real}*** + ***{c.Complex}i***");
        }
    }
}