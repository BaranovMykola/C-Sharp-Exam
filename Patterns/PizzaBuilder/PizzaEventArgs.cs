using System;
using System.Collections.Generic;

namespace Patterns.PizzaBuilder
{
    public class PizzaEventArgs : EventArgs
    {
        public List<string> PizzaLog { get; set; }

        public PizzaEventArgs(List<string> log)
        {
            PizzaLog = log;
        }
    }
}