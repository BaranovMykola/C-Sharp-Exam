using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LINQ.Program;

namespace LINQ
{
    [Serializable]
    public class CatOwner
    {
        public string OwnerName { get; set; }
        public int Age { get; set; }
        public CatOwner()
        {
        }
        public override string ToString()
        {
            return $"{OwnerName} {Age}";
        }
    }

    internal class GenerateCatOwner
    {       
        static Random rand = new Random();

        public CatOwner GenerateOwner(Cat cat)
        {
            CatOwner toReturn = new CatOwner();
            toReturn.OwnerName = cat.OwnerName;
            toReturn.Age = rand.Next(10, 80);
            return toReturn;
        }
       
    }
}
