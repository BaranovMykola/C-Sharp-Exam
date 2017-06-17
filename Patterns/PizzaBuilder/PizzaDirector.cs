using System;
using System.Collections.Generic;

namespace Patterns.PizzaBuilder
{
    public class PizzaDirector
    {
        public event EventHandler<EventArgs> OnBaked;
        public enum Component
        {
            Souce,
            Filling
        };

        public IPizzaBuilder PizzaBuilder { get; set; }

        public PizzaDirector(IPizzaBuilder pizzaBuilder)
        {
            PizzaBuilder = pizzaBuilder;
            OnBaked = BakedPizzaHandler.EatPizza;
        }

        public void Bake(List<KeyValuePair<Component, string>> componentsList)
        {
            foreach (var pair in componentsList)
            {
                if (pair.Key == Component.Filling)
                {
                    PizzaBuilder.MakeFilling(pair.Value);
                }
                else if (pair.Key == Component.Souce)
                {
                    PizzaBuilder.MakeSouce(pair.Value);
                }
            }
            OnBaked?.Invoke(PizzaBuilder, new PizzaEventArgs(PizzaBuilder.LogPizza));
        }

    }
}