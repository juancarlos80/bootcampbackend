using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern
{
    class HtmlElement : HtmlTag
    {
        public string tagName { get; set; }
        public string startTag { get; set; }
        public string endTag { get; set; }
        public string bodyTag { get; set; }


        public HtmlElement(string tagName)
        {
            this.tagName = tagName;
        }

        public override void GenerateHtml()
        {
            Console.WriteLine("\t{0} {1} {2} ",
                startTag,
                bodyTag,
                endTag);
        }

        public override string GetTagName()
        {
            return tagName;
        }
        public override void SetStartTag(string startTag)
        {
            this.startTag = startTag;
        }
        public override void SetEndTag(string endTag)
        {
            this.endTag = endTag;
        }        
        public override void SetBodyTag(string bodyTag)
        {
            this.bodyTag = bodyTag;
        }
    }
}
