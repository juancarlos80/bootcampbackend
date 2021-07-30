using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookClient
{
    class ActionMove : Action
    {
        public string NewFolder { set; get; }                

        public ActionMove(string NewFolder)
        {
            this.NewFolder = NewFolder;                        
        }        

        public override bool Execute(Client client, Email email)
        {
            if (client.Folders["Inbox"].Remove(email))
            {
                client.Folders[NewFolder].Add(email);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
