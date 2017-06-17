using Patterns.Field;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Adapter
{
    class Adapter : IField
    {
        public R Field { get; set; }

        public Adapter(double field)
        {
            this.Field = field;
        }

        public void Abs()
        {
            Field.Abs();
        }
    }
}
