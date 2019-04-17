using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void printGrade(double a)
        {
            if (a >= 2 && a < 3) Console.WriteLine("Fail");
            else if (a >= 3 && a < 3.49) Console.WriteLine("Poor");
            else if (a >= 3.5 && a < 4.5) Console.WriteLine("Good");
            else if (a >= 4.5 && a < 5.5) Console.WriteLine("Very good");
            else if (a >= 5.5 && a <= 6) Console.WriteLine("Excellent");
        }
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());
            printGrade(grade);
        }
    }
}
