using System;
using Patterns.Field;

namespace Patterns.Builder
{
    class RBuilder : IBuilder
    {
        public bool N { get; }
        private static Random rnd = new Random();
        public RBuilder(bool n = false)
        {
            N = n;
        }

        public IField Random()
        {
            double NPart = rnd.Next();
            if (N)
            {
                NPart += rnd.Next()/(double) rnd.Next();
            }
            return new R(NPart);
        }
    }
}