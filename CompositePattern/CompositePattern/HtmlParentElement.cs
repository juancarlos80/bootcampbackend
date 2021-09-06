using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern
{
    class HtmlParentElement : HtmlTag
    {
        public string tagName { get; set; }
        public string startTag { get; set; }
        public string endTag { get; set; }
        public List<HtmlTag> childrenTag { get; set; }


        public HtmlParentElement(string tagName)
        {
            this.tagName = tagName;
            this.childrenTag = new List<HtmlTag>();
        }        

        public override string GetTagName()
        {
            return tagName;
        }

        public override void SetEndTag(string endTag)
        {
            this.endTag = endTag;
        }

        public override void SetStartTag(string startTag)
        {
            this.startTag = startTag;
        }

        public override void GenerateHtml()
        {
            Console.WriteLine(startTag);            
            foreach (HtmlTag tag in childrenTag) {                
                tag.GenerateHtml();                
            }
            Console.WriteLine(endTag);
        }

        public override List<HtmlTag> GetChildren() {
            return childrenTag;
        }

        public override void AddChildTag(HtmlTag tag)
        {
            childrenTag.Add(tag);
        }

        public override void RemoveChildTag(HtmlTag tag)
        {
            childrenTag.Remove(tag);
        }
    }
}
