using System;
using Patterns.Field;

namespace Patterns.Abstract_Factory
{
    class RandomRGenerator : AbstractFactory
    {
        static Random rnd = new Random();
        public override IField Random() => new R(rnd.Next() + rnd.Next()/(double) rnd.Next());
    }
}