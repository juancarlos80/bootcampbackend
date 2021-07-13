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
            Console.WriteLine(text.reverseString());
        }
    }
}
