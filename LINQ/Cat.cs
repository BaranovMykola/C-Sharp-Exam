using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class Cat
    {
        public string CatName { get; set; }
        public string OwnerName { get; set; }
        public uint Age { get; set; } = 1;
        public bool IsHungry { get; set; } = true;
        public uint MouseCaught { get; set; } = 0;
        public Cat()
        {
        }
        public override string ToString()
        {
            return $"Name: {CatName}, OwnerName: {OwnerName}, Age: {Age}, IsHungry: {IsHungry}, MouseCaught: {MouseCaught} ";
        }
    }

    internal class Generator
    {

        Random rand = new Random();

        public Cat CatInformation()
        {
            return new Cat
            {
                CatName = generateName(),
                OwnerName = generateName(),
                Age = genereteAge(),
                IsHungry = generateHunger(),
                MouseCaught = generateMouseCaught()
            };

        }

        string generateName()
        {
            uint quantityOfLetters = (uint)rand.Next(2, 10);
            string res = string.Empty;
            for (int i = 0; i < quantityOfLetters; i++)
            {
                res += (char)rand.Next(97, 123);
            }
            return res;
        }
        uint genereteAge()
        {
            return (uint)rand.Next(20);
        }
        bool generateHunger()
        {
            switch (rand.Next(2))
            {
                case 0:
                    return false;
                case 1:
                    return true;
                default: return true;
            }
        }

        uint generateMouseCaught()
        {
            return (uint)rand.Next(200);
        }

    }


    public class a
    {
        public static void SelectLinq(List<Cat> cats)
        {
            var sort = cats.OrderBy(cat => cat.IsHungry).ThenBy(cat => cat.Age).ThenBy(cat => cat.MouseCaught).ThenBy(cat => cat.CatName).ThenBy(cat => cat.OwnerName);

            var divideCats =
                from i in sort
                group i by i.IsHungry into hungryCats
                select new
                {
                    IsCatHungry = hungryCats.Key,
                    CatAge =

                from j in hungryCats
                group j by j.Age into ages
                select new
                {
                    Age = ages.Key,
                    MouseCatch =
                    from k in ages
                    group k by k.MouseCaught into mice
                    select new
                    {
                        mice.Key,
                        Other =
                        from l in mice
                        select new { l.CatName, l.OwnerName }
                    }
                }
                };



            foreach (var item in divideCats)
            {
                Console.WriteLine(item.IsCatHungry);
                foreach (var i in item.CatAge)
                {
                    Console.WriteLine($"        {i.Age}");
                    foreach (var j in i.MouseCatch)
                    {
                        Console.WriteLine($"            {j.Key}");
                        foreach (var k in j.Other)
                        {
                            Console.WriteLine($"                {k.CatName} {k.OwnerName}");
                        }
                    }

                }
            }
        }

    }
    
}
