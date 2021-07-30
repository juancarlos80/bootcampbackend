using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookClient
{
    abstract class Action
    {
        public string Name { set; get; }

        public abstract bool Execute(Client client, Email email);
    }
}
