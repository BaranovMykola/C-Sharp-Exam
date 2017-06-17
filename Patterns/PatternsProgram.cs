using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patterns.Abstract_Factory;
using Patterns.Builder;
using Patterns.Decorator;
using Patterns.Field;
using Patterns.PizzaBuilder;

namespace Patterns
{
    class PatternsProgram 
    {
        static void Main(string[] args)
        {

            List<KeyValuePair<PizzaDirector.Component, string>> componentList = new List
                <KeyValuePair<PizzaDirector.Component, string>>()
            {
                new KeyValuePair<PizzaDirector.Component, string>(PizzaDirector.Component.Filling, "Mashrooms"),
                new KeyValuePair<PizzaDirector.Component, string>(PizzaDirector.Component.Filling, "Sausage"),
                new KeyValuePair<PizzaDirector.Component, string>(PizzaDirector.Component.Filling, "Corn"),
                new KeyValuePair<PizzaDirector.Component, string>(PizzaDirector.Component.Souce, "Vasabi")
            };

            GoodPizzaBuilder good = new GoodPizzaBuilder();
            BadPizzaBuilder bad = new BadPizzaBuilder();
            PizzaDirector pizzaDirector = new PizzaDirector(bad);
            pizzaDirector.Bake(componentList);
            Console.ReadKey();
        }
    }
}
