using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patterns.Field;

namespace Patterns.Abstract_Factory
{
    abstract class AbstractFactory
    {
        public abstract IField Random();
    }
}
