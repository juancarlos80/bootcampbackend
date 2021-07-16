using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtensionFunctionExcer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Extension metodos con LINQ
            List<Product> products = new List<Product>()
            {
                new Product() { ID = 1, Price = 35},
                new Product() { ID = 2, Price = 150},
                new Product() { ID = 3, Price = 650},
                new Product() { ID = 4, Price = 150},
                new Product() { ID = 5, Price = 15},
                new Product() { ID = 6, Price = 35},
                new Product() { ID = 7, Price = 650},
                new Product() { ID = 8, Price = 78},
                new Product() { ID = 9, Price = 35},
                new Product() { ID = 10, Price = 78}
            };

            Console.WriteLine("Average {0}", products.Average(p => p.Price));
            Console.WriteLine("Median {0}", products.Median(p => p.Price));
            Console.WriteLine("Mode {0}", products.Mode(p => p.Price));
            Console.WriteLine("UnMode {0}", products.UnMode(p => p.Price));

        }
    }
}
