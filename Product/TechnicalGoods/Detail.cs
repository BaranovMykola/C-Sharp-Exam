using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
