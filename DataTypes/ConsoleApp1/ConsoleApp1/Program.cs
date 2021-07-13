using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] integers = new int[8];

            int number_1 = -100;
            int number_2 = -128;
            uint number_3 = 3540;
            uint number_4 = 64876;
            long number_5 = 2147483648;
            long number_6 = -1141583228;
            long number_7 = -1223372036854770;
            int number_8 = 808;
            int number_9 = 2_000_000;
            int number_10 = 0b_0001_1110_1000_0100_1000_000;
            int number_11 = 0x_001E_8480;

            decimal number_12 = 3.141592653589793238M;
            float number_13 = 1.60217657F;
            decimal number_14 = 7.8184261974584555216535342341M;

            Console.WriteLine(number_1);
            Console.WriteLine(number_2);
            Console.WriteLine(number_3);
            Console.WriteLine(number_4);
            Console.WriteLine(number_5);
            Console.WriteLine(number_6);
            Console.WriteLine(number_7);
            Console.WriteLine(number_8);
            Console.WriteLine(number_9);
            Console.WriteLine(number_10);
            Console.WriteLine(number_11);
            Console.WriteLine(number_12);
            Console.WriteLine(number_13);
            Console.WriteLine(number_14);


        }
    }
}
