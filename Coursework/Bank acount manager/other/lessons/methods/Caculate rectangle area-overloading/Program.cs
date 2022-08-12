using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculate_rectangle_area_overloading
{
    class Program
    {
        static double Area(double a,double b)
        {
            return a * b;
        }
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            Console.WriteLine(Area(width,height));
        }
    }
}
