    using System;

namespace ExtensionFunction
{
    using CustomFunctions;
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Extension function example");

            string text = "Paralelepipedo";
            Console.WriteLine("Inital text: {0}", text);
            text = text.ReverseString();
            Console.WriteLine("Reversed text: {0}",text);

            //Override methods of the type itself 
            string search = "Para";
            Console.WriteLine("Resersed text contains '{0}': {1}", search, text.Contains(search));
            search = search.ReverseString();
            Console.WriteLine("Resersed text contains '{0}': {1}", search, text.Contains(search));
        }
    }
}
