using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leap_or_not_leap_year
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MONTH: ");
            int month = int.Parse(Console.ReadLine());
            Console.Write("YEAR: ");
            int year = int.Parse(Console.ReadLine());
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    Console.WriteLine("Month number {0} of {1} has 31 days", month, year);
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    Console.WriteLine("Month number {0} of {1} has 30 days", month, year);
                    break;
                case 2:
                    if (year % 400 == 0 || (year % 100 != 0 && year % 4 == 0))
                        Console.WriteLine("Month number {0} of {1} has 29 days", month, year);
                    else
                        Console.WriteLine("Month number {0} of {1} has 28 days", month, year);
                    break;
                default:
                    Console.WriteLine("{0} is not a valid month number", month);
                    break;
            }

        }
    }
}
