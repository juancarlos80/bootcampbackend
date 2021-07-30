using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookClient
{
    class ClientSMTP : Client
    {
        public string ServerName { set; get; }
        public int Port { set; get; }

        public ClientSMTP()
        {
            //Setup default folders
            Folders = new Dictionary<string, List<Email>>
            {
                { "Inbox", new List<Email>() },
                { "Social", new List<Email>() },
                { "Sent", new List<Email>() },
                { "Spam", new List<Email>() }
            };            

            RulesIn = new List<Rule>();            
            RulesOut = new List<Rule>();
        }
    }
}
