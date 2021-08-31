using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class ErrorXMLParser : XMLParser
    {
        public string parse()
        {
            return "This is an XML Error";
        }
    }
}
