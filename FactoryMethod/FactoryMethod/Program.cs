using System;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayService errorService = new ErrorXMLDisplayService();
            DisplayService orderService = new OrderXMLDisplayService();
            DisplayService feedbackService = new FeedBackXMLDisplayService();
            DisplayService responseService = new ResponseXMLDisplayService();

            ShowXML(errorService);
            ShowXML(orderService);
            ShowXML(feedbackService);
            ShowXML(responseService);
        }

        public static void ShowXML(DisplayService service) {
            service.display();
        }
    }
}
