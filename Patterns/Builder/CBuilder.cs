using System;
using Patterns.Field;

namespace Patterns.Builder
{
    class CBuilder : IBuilder
    {
        public bool N { get; }
        private static Random rnd = new Random();
        public CBuilder(bool n = false)
        {
            N = n;
        }

        public IField Random()
        {
            double NPart = rnd.Next();
            if (N)
            {
                NPart += rnd.Next() / (double)rnd.Next();
            }

            double CPart = rnd.Next();
            if (N)
            {
                CPart += rnd.Next() / (double)rnd.Next();
            }

            return new C(NPart, CPart);
        }
    }
}