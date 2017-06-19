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
