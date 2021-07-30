using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookClient
{
    class Email
    {
        public int id { set; get; }
        public string IpOrigin { set; get; }
        public string From { set; get; }
        public string To { set; get; }
        public string Subject { set; get; }
        public string CC { set; get; }
        public string Body { set; get; }
        public string Date { set; get; }

        public string Category { set; get; }
        public bool IsReaded { set; get; }
        public bool IsSpam { set; get; }
        public bool IsImportant { set; get; }

        public override string ToString()
        {
            return string.Format("From: {0}, To: {1}, CC: {2}, Subject: {3} ", From, To, CC, Subject);
        }
    }
    
}
