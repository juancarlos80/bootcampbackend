using System;
namespace DotNetDebugging
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 7;
            for (int i = 0; i <n; i++) { 
                int result = Fibonacci(i);
                Console.Write(result+" ");                
            }
            Console.ReadKey(true);
        }
        static int Fibonacci(int n)
        {
            int n1 = 0;
            int n2 = 1;
            int sum = 0;

            for (int i = 2; i <= n; i++)
            {
                sum = n1 + n2;
                n1 = n2;
                n2 = sum;                
            }
            return n == 0 ? n1 : n2;
        }
    }
}