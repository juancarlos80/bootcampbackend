using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookClient
{
    class ActionDeleteFolder
    {
        public bool Execute(Client client, String name)
        {            
            foreach (var folder in client.Folders)
            {
                if (folder.Key == name) {
                    client.Folders.Remove(name);
                }                            
            }
            return false;
        }
    }
}
