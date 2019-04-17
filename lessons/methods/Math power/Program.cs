using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math_power
{
    class Program
    {
        static double Powder(double num,int pow)
        {
            return Math.Pow(num, pow);
        }
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            int pow = int.Parse(Console.ReadLine());
            Console.WriteLine(Powder(num,pow));
        }
    }
}
