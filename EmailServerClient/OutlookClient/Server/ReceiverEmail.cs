using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookClient
{
    class ReceiverEmail : IReceiverMail
    {
        public void ReceiveEmail(Email email, List<Client> clients)
        {
            Console.WriteLine("Server Receive: {0}", email);
            foreach (var client in clients)
            {
                if (client.Username.Equals(email.To))
                {
                    client.Folders["Inbox"].Add(email);
                    foreach (var rule in client.RulesIn)
                    {
                        rule.MacthRules(client, email);
                    }

                    Console.WriteLine("Recieve mail: {0}", client.Username);
                    client.ShowStatusUSer();
                    return;
                }
            }
            Console.WriteLine("Client not found in Server");
        }
    }
}
