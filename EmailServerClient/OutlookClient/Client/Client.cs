using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookClient
{
    abstract class Client
    {
        public string AccountName { set; get; }
        
        public string Username { set; get; }
        public string Password { set; get; }

        public Dictionary<string, List<Email>> Folders { set; get; }
        public List<Rule> RulesIn { set; get; }
        public List<Rule> RulesOut { set; get; }        
        

        public override string ToString()
        {                        
            return string.Format("AccountName: {0}, Username: {1}, Folders: {2}"
                , AccountName
                , Username
                , string.Join(" ", Folders.Select( f => f.Key + "("+ f.Value.Count + ")" ).ToArray()));
        }

        public void ShowStatusUSer() {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(this.ToString());
            Console.ForegroundColor = ConsoleColor.Blue;
            foreach (var folder in Folders)
            {
                Console.WriteLine("-- Folfer: {0} --", folder.Key);
                foreach (var email in folder.Value)
                {
                    Console.WriteLine(email);
                }
                Console.WriteLine("-----------");
            }
            Console.ResetColor();
        }
    }
}