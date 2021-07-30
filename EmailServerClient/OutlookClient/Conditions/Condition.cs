using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookClient
{
    abstract class Condition
    {
        public string Name { set; get; }

        public abstract bool Macth(Client cliente, Email email);

    }
}
