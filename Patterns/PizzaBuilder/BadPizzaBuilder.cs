using System;
using System.Collections.Generic;

namespace Patterns.PizzaBuilder
{
    public class BadPizzaBuilder : IPizzaBuilder
    {
        public List<string> LogPizza { get; set; } = new List<string>();
        private static Random rnd = new Random();
        public void MakeSouce(string souce)
        {
            if (rnd.Next(0, 3) == 0)
            {
              Eat(souce);  
            }
            else
            {
                LogPizza.Add($"Added souce [{souce}]");
            }
        }

        public void MakeFilling(string filling)
        {
            if (rnd.Next(0, 3) == 0)
            {
                Eat(filling);
            }
            else
            {
                LogPizza.Add($"Added Filling *{filling}*");
            }
        }

        private void Eat(string food)
        {
            LogPizza.Add($"COMPONENT ---{food}--- STOLEN");
        }
    }
}