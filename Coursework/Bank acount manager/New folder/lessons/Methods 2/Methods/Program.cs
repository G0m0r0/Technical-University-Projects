using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    class Program
    {
        static void Print(int a)
        {
            if (a < 0) Console.WriteLine("The number {0} is negative.",a);
            else if (a == 0) Console.WriteLine("The number 0 is zero.");
            else if (a > 0) Console.WriteLine("The number {0} is positive.",a);
        }
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            Print(num);

        }
    }
}
