using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern
{
    abstract class HtmlTag
    {        
        public abstract string GetTagName();
        public abstract void SetStartTag(string startTag);
        public abstract void SetEndTag(string endTag);

        public virtual void SetBodyTag(string body) {
            throw new NotImplementedException();
        }
        public virtual void AddChildTag(HtmlTag tag) {
            throw new NotImplementedException();
        }
        public virtual void RemoveChildTag(HtmlTag tag) {
            throw new NotImplementedException();
        }
        public virtual List<HtmlTag> GetChildren() {
            throw new NotImplementedException();
        }
        public abstract void GenerateHtml();
    }
}
