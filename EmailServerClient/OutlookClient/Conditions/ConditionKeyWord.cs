using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookClient
{
    class ConditionKeyWord : Condition
    {
        public string KeyWords { set; get; }

        public string EmailField { set; get; }

        public ConditionKeyWord(string EmailField, string KeyWords)
        {
            this.EmailField = EmailField;
            this.KeyWords = KeyWords;

        }
        public override bool Macth(Client client, Email email)
        {                        
            Type t2 = email.GetType();                                    
            var emailField = t2.GetProperty(EmailField);

            if (emailField == null) return false;

            if ((emailField.GetValue(email).ToString()).Contains(KeyWords) )
            {
                return true;
            }
            return false;
        }
    }
}
