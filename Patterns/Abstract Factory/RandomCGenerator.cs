using System;
using Patterns.Field;

namespace Patterns.Abstract_Factory
{
    class RandomCGenerator : AbstractFactory
    {
        static Random rnd = new Random();

        public override IField Random() => new C(rnd.Next() + rnd.Next()/(double) rnd.Next(), rnd.Next() + rnd.Next()/(double) rnd.Next());
    }
}