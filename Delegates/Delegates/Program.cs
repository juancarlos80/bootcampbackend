using System;

namespace Delegates
{

    public class Expression
    {
        private int first;
        private int second;

        public Expression(int first, int second)
        {
            this.first = first;
            this.second = second;
        }

        public int Sum()
        {
            return first + second;
        }

        private int Substract()
        {
            return first - second;
        }

        private int Multiply()
        {
            return first * second;
        }

        public int ApplyOperator(Operation operation)
        {
            return operation();            
        }
    }


    public delegate int Operation();


    class Program
    {


        static void Main(string[] args)
        {
            Expression expresion = new Expression(10, 20);            

            var result = expresion.ApplyOperator(expresion.Sum);
            Console.WriteLine($"Result of operarions: {result}");

        }
    }
}
