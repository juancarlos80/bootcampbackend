using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookClient
{
    class Rule
    {        
        public string Name { set; get; }
        public List<Condition> Conditions { set; get; }
        public List<Action> Actions { set; get; }

        public Rule(String Name)
        {
            this.Name = Name;
            Conditions = new List<Condition>();
            Actions = new List<Action>();
        }

        public bool MacthRules(Client client, Email email) {
            foreach (var condition in Conditions)
            {
                if (!condition.Macth(client, email)) return false;                
            }
            foreach (var action in Actions)
            {
                if (!action.Execute(client, email)) return false;
            }
            return true;
        }
        
    }
}
