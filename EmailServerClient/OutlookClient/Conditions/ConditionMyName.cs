using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookClient
{
    class ConditionMyName : Condition
    {
        public string EmailField { set; get; }

        public ConditionMyName(string EmailField)
        {
            this.EmailField = EmailField;
        }

        public override bool Macth(Client client, Email email)
        {
            Type t2 = email.GetType();
            var emailField = t2.GetProperty(EmailField);
            if (emailField == null) return false;

            if (emailField.GetValue(client).ToString().Contains( client.Username ) )
            {
                return true;
            }
            return false;
        }
    }
}
