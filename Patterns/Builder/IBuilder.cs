using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patterns.Field;

namespace Patterns.Builder
{
    internal interface IBuilder
    {
        bool N{ get; }
        IField Random();
    }
}
