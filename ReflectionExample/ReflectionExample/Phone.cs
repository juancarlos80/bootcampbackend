using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionExample
{
    public class Phone : Device
    {
        public string Type { set; get; }
        public bool HasButtons{ set; get; }

        public void MakeCall() {
            Console.WriteLine("Calling...");
        }
    }
}
