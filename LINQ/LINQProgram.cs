using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
namespace LINQ
{
   public class Program
    {
        public static string xmlfile = "data.xml";       

        static void Main(string[] args)
        {

            #region allCats & owners

            List<Cat> allCats = new List<Cat>();
            using (FileStream str = File.Open("../../data.xml", FileMode.Open))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof (List<Cat>));
                allCats = (List<Cat>) deserializer.Deserialize(str);
            }
            Console.WriteLine();
            List<CatOwner> owners = new List<CatOwner>();
            using (var stream = File.Open("../../owners.bin", FileMode.OpenOrCreate, FileAccess.Read))
            {
                BinaryFormatter bin = new BinaryFormatter();
                owners = bin.Deserialize(stream) as List<CatOwner>;
            }

            Console.WriteLine("Cat owners:");
            foreach (var item in owners)
            {
                Console.WriteLine(item);
            }
                                                allCats.RemoveRange(5,allCats.Count-6);
                                                allCats.Add(allCats[1]);
                                                allCats.Add(new Cat() {Age = 3, OwnerName =  "Unknown", CatName = "Noise", IsHungry = true, MouseCaught = 1});
            Console.WriteLine();
            Console.WriteLine("Cats");
            foreach (var item in allCats)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine();

            #endregion


            var q =
                from ca1 in allCats
                let ca2 = (from ow in owners
                    join ca in allCats on ow.OwnerName equals ca.OwnerName
                    select ca)
                where !ca2.Contains(ca1)
                select ca1;

            foreach (var cat in q)
            {
                Console.WriteLine(cat);
            }

            Console.ReadKey();

        }
        public static void output(List<Cat> cats)
        {
            foreach (var item in cats)
            {
                Console.WriteLine(item);
            }
        }

    }
}
