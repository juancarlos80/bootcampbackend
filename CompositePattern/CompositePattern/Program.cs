using System;

namespace CompositePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            HtmlTag rootTag = new HtmlParentElement("html");
            rootTag.SetStartTag("<html>");
            rootTag.SetEndTag("</html>");

            HtmlTag body = new HtmlParentElement("body");
            body.SetStartTag("<body>");
            body.SetEndTag("</body>");

            rootTag.AddChildTag(body);

            HtmlTag paragraph1 = new HtmlElement("p");
            paragraph1.SetStartTag("<p>");
            paragraph1.SetEndTag("</p>");
            paragraph1.SetBodyTag("Testing html tag library");
            body.AddChildTag(paragraph1);

            HtmlTag paragraph2 = new HtmlElement("p");
            paragraph2.SetStartTag("<p>");
            paragraph2.SetEndTag("</p>");
            paragraph2.SetBodyTag("Second Paragraph");
            body.AddChildTag(paragraph2);

            rootTag.GenerateHtml();

        }
    }
}
