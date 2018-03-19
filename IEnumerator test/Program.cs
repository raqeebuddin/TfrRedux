using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerator_test
{
    class Program
    {
        public static List<Product> products;
        static void Main(string[] args)
        {



            List<string> name = new List<string>()
            {
                "prod1", "prod2", "prod3", "prod4"
            };

            List<int> price = new List<int>()
            {
                1, 2, 3, 4
            };
            List<string> url = new List<string>()
            {
                "url1", "url2", "url3", "url4"
            };

            IEnumerable<Product>result  = from n in name
                                          from p in price
                                          from u in url
                                          select new Product()
                                          {
                                              Name = n,
                                              Price = p,
                                              Url = u
                                          };

            products = result.ToList();
            // Loop.
            foreach (Product value in products)
            {
                Console.WriteLine(value.Name);
                Console.WriteLine(value.Price);
                Console.WriteLine(value.Url);
            }

            Console.ReadLine();

            // Extension methods can convert IEnumerable<int>
            //List<Product> list = result.ToList();
            //Product[] array = result.ToArray();
        }
    }
}

