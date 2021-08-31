using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    abstract class DisplayService
    {
        public void display() {
            Console.WriteLine( "I can format: {0}", GetParser().parse() );            
        }
        public abstract XMLParser GetParser();        
    }
}
