using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookClient
{
    interface ISenderMail
    {
        public void SendEmail(Email email, Client client);
    }
}
