using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product.Builder;
using Product.TechnicalGoods;

namespace Product
{
    class ProductProgram
    {
        static void Main(string[] args)
        {
            IBuilder b1 = new ScooterBuilder("Death");
            IBuilder b2 = new ChoopaChupsBuilder("Petya");

            Director dir = new Director();

            dir.Build(b1);
            dir.Build(b2);

            Console.WriteLine(b1.Product);

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine(b2.Product);

            Console.ReadKey();
        }
    }
}

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

namespace Product.Builder
{
    public interface IBuilder
    {
        Product Product { get; set; }
        void BuildCorpus();
        void BuildViscera();
        void BuildDesign();
    }
}

namespace Product.Builder
{
    class Director
    {
        public void Build(IBuilder builder)
        {
            builder.BuildCorpus();
            builder.BuildViscera();
            builder.BuildDesign();
        }
    }
}

namespace Product.Builder
{
    class ChoopaChupsBuilder : IBuilder
    {
        public Product Product { get; set; } = new Product();

        public ChoopaChupsBuilder(string name)
        {
            Product.Name = name;
        }

        public void BuildCorpus()
        {
            Product.Parts.Add(new Detail("Chopstick"));
        }

        public void BuildViscera()
        {
            Product.Parts.Add(new Detail("Caramel"));
        }

        public void BuildDesign()
        {
            Product.Parts.Add(new Detail("Wrapper"));
        }
    }
}

namespace Product
{
    public class Product
    {
        public string Name { get; set; }
        public List<ITechnicalProduct> Parts { get; set; } = new List<ITechnicalProduct>();

        public Product()
        {

        }

        public Product(string name)
        {
            Name = name;
        }

        public Product(string name, IEnumerable<ITechnicalProduct> parts) : this(name)
        {
            Parts = parts.ToList();
        }

        public override string ToString()
        {
            string caption = $"Product [{Name}]\t";

            string parts = string.Join("\n\t\t", Parts);

            return $"{caption}\n\t[\n\t\t{parts}\n\t]";
        }
    }
}

namespace Product.TechnicalGoods
{
    public class Agregat : Detail
    {
        public uint Id { get; set; }
        public string Stuff { get; set; }

        public Agregat()
        {
        }

        public Agregat(string name) : base(name)
        {
        }

        public Agregat(string name, int id, string stuff) : this(name)
        {
            Id = (uint)id;
            Stuff = stuff;
        }

        public override string ToString() => $"Agregat [{Name}]\tStuff: [{Stuff}]\tId: [{Id}]";
    }
}

namespace Product.TechnicalGoods
{
    public class Detail : ITechnicalProduct
    {
        public string Name { get; set; }

        public Detail()
        {

        }

        public Detail(string name)
        {
            Name = name;
        }

        public override string ToString() => $"Detail [{Name}]";
    }
}

namespace Product.TechnicalGoods
{
    public interface ITechnicalProduct
    {
        string Name { get; set; }
    }
}