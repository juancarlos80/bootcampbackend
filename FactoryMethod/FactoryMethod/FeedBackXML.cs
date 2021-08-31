using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class FeedBackXML : XMLParser
    {
        public string parse()
        {
            return "This is an XML Feedback";
        }
    }
}
