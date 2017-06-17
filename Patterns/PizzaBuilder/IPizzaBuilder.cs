using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.PizzaBuilder
{
    public interface IPizzaBuilder
    {
        List<string> LogPizza { get; set; }
        void MakeSouce(string souce);
        void MakeFilling(string filling);
    }
}
