using System;

namespace Patterns.Field
{
    class R : IField
    {
        public double Real { get; set; }

        public R()
        {
            
        }

        public R(double real)
        {
            Real = real;
        }

        public void Abs()
        {
            Real = Math.Abs(Real);
        }

        public override string ToString() => Real.ToString();

        public static implicit operator R(double real)
        {
            return new R(real);
        }

        public void Add(R add)
        {
            Real += add.Real;
        }
    }
}