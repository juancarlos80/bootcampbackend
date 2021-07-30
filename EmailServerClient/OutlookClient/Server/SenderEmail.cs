using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookClient
{
    class SenderEmail : ISenderMail
    {
        public void SendEmail(Email email, Client client)
        {
            Console.WriteLine("Server Send: {0}", email);
            client.Folders["Sent"].Add(email);
            foreach (var rule in client.RulesOut)
            {
                rule.MacthRules(client, email);
            }

            Console.WriteLine("Send mail: {0}", client.Username);
            client.ShowStatusUSer();
        }
    }
}
