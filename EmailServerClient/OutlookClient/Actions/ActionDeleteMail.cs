using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookClient
{
    class ActionDeleteMail : Action
    {
        public override bool Execute(Client client, Email email)
        {            
            foreach (var folder in client.Folders)
            {
                foreach (var email_f in folder.Value) 
                {
                    if (email == email_f) 
                        return folder.Value.Remove(email_f);
                }
            
            }
            return false;
        }
    }
}
