﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class ErrorXMLDisplayService : DisplayService
    {                
        public override XMLParser GetParser()
        {
            return new ErrorXMLParser();
        }
    }
}
