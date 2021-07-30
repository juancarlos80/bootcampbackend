using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookClient
{
    class ConditionContact : Condition
    {
        public string ClientField { set; get; }

        public string EmailField { set; get; }

        public ConditionContact( string ClientField, string EmailField )
        {
            Name = "ComparareContact";
            this.ClientField = ClientField;
            this.EmailField = EmailField;
        }


        public override bool Macth(Client client, Email email)
        {            
            Type tc = client.GetType();
            Type t2 = email.GetType();
            var clientField = tc.GetProperty(ClientField);
            if (clientField == null) return false;
            var emailField = t2.GetProperty(EmailField);
            if (emailField == null) return false;
            
            if (clientField.GetValue(client).ToString().Equals(emailField.GetValue(email).ToString())) 
            {
                return true;
            }
            return false;
        }
    }
}
