using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Product.TechnicalGoods;

//namespace Product
//{
//    public class Product
//    {
//        public string Name { get; set; }
//        public List<ITechnicalProduct> Parts { get; set; } = new List<ITechnicalProduct>();

//        public Product()
//        {
            
//        }

//        public Product(string name)
//        {
//            Name = name;
//        }

//        public Product(string name, IEnumerable<ITechnicalProduct> parts): this(name)
//        {
//            Parts = parts.ToList();
//        }

//        public override string ToString()
//        {
//            string caption = $"Product [{Name}]\t";

//            string parts = string.Join("\n\t\t", Parts);

//            return $"{caption}\n\t[\n\t\t{parts}\n\t]";
//        }
//    }
//}