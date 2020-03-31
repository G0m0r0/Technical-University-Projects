using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math_operations
{
    class Program
    {
        static double Calculator(double a,char c,double b)
        {
            switch(c)
            {
                case '+': return a + b;
                case '-': return a - b;
                case '*': return a * b;
                case '/': return a / b;
                default: return 0; 
            }
        }
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            char c =char.Parse( Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine(Calculator(a,c,b));
        }
    }
}
