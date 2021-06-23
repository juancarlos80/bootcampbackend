using System;
using System.Collections.Generic;

namespace ConsoleValueTypes
{
    class Program
    {
        struct DetailedInteger
        {
            public int Number;

            List<string> detailed;
            public DetailedInteger(int n)
            {
                this.Number = n;
                this.detailed = new List<string>();
            }
            

            public void AddDetail(string detail)
            {
                detailed.Add(detail);
            }

            public override string ToString()
            {
                return $"{this.Number} [{ String.Join(",",this.detailed) }]";
            }
        }

        static void Main(string[] args)
        {
            var n1 = new DetailedInteger(0);

            n1.AddDetail("A");

            Console.WriteLine(n1);

            var n2 = n1;
            n2.Number = 7;
            n2.AddDetail("B");

            Console.WriteLine(n1);
            Console.WriteLine(n2);

        }
    }
}
