using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookClient
{
    class MailServer 
    {
        public List<Client> Clients { set; get; }

        private IReceiverMail Receiver;
        private ISenderMail Sender;

        public MailServer( List<Client> clients, IReceiverMail receiver, ISenderMail sender)
        {            
            Clients = clients;            
            Receiver = receiver;
            Sender = sender;            
        }        

        public void RecieveEmail(Email email) 
        {
            Receiver.ReceiveEmail(email, Clients);
        }

        public void SendEmail(Email email, Client client)
        {
            Sender.SendEmail(email, client);
        }

    }
}
