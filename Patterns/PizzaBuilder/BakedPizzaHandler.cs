using System;

namespace Patterns.PizzaBuilder
{
    public class BakedPizzaHandler
    {
        public static void EatPizza(object sender, EventArgs pizza)
        {
            Console.WriteLine($"Thanks, {sender}!");
            var logArgs = pizza as PizzaEventArgs;
            if (logArgs?.PizzaLog != null)
                foreach (var item in logArgs.PizzaLog)
                {
                    Console.WriteLine(item);
                }
        }
    }
}