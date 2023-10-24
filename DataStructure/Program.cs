
using System;

namespace DataStructure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var operation = "(5^(1+1)-10)*2";

            var c = Calculator.Calculator.InfixExpressionEvaluator(operation);

            Console.WriteLine(c);
        }
    }
}