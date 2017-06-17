using System.Collections.Generic;

namespace Patterns.PizzaBuilder
{
    public class GoodPizzaBuilder : IPizzaBuilder
    {
        public List<string> LogPizza { get; set; } = new List<string>();

        public void MakeSouce(string souce)
        {
            LogPizza.Add($"Added souce [{souce}]");
        }

        public void MakeFilling(string filling)
        {
            LogPizza.Add($"Added Filling *{filling}*");
        }
    }
}