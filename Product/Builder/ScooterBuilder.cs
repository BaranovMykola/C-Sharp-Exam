using System;
using Product.TechnicalGoods;

namespace Product.Builder
{
    class ScooterBuilder : IBuilder
    {
        public Product Product { get; set; } = new Product();
        private static readonly Random rnd = new Random();

        public ScooterBuilder(string name)
        {
            Product.Name = name;
        }

        public void BuildCorpus()
        {
            Product.Parts.Add(
                new Agregat("Scooter corpus", rnd.Next(), "Iron")
                );
        }

        public void BuildViscera()
        {
            Product.Parts.Add(
                new Agregat("Engine v2.0", rnd.Next(), "Steel")
                );
        }

        public void BuildDesign()
        {
            Product.Parts.Add(
                new Detail("Red color")
                );
        }
    }
}