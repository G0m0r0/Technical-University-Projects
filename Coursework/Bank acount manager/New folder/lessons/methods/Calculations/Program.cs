using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculations
{
    class Program
    {
        static void Substraction(int a,int b)
        {
            Console.WriteLine(a-b);
        }
        static void Addition(int a,int b)
        {
            Console.WriteLine(a+b);
        }
        static void Multiplication(int a, int b)
        {
            Console.WriteLine(a*b);
        }
        static void division(int a,int b)
        {
            Console.WriteLine(a/b);
        }
        static void Main(string[] args)
        {
            string operation = Console.ReadLine();
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            switch(operation)
            {
                case "add": Addition(a, b); break;
                case "substract": Substraction(a, b); break;
                case "multiply": Multiplication(a, b); break;
                case "divide": division(a, b); break;
            }
        }
    }
}
