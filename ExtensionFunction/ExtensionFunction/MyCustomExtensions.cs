using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomFunctions
{
    public static class MyCustomExtensions
    {
        public static string ReverseString(this String str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static bool Contains(this String str) 
        {
            if (str == "void") 
                return true;
            else 
                return false;
        }

    }
}
