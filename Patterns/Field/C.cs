using System;

namespace Patterns.Field
{
    class C : IField
    {
        public R Real { get; set; }
        public R Complex { get; set; }

        public C()
        {
            
        }

        public C(R real, R complex)
        {
            Real = real;
            Complex = complex;
        }

        public void Abs()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString() => $"{Real} + {Complex}i";

        public void Add(R real, R complex)
        {
            Real.Add(real);
            Complex.Add(complex);
        }
    }
}