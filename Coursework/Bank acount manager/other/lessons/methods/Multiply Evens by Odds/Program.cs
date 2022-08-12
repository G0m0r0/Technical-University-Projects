using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiply_Evens_by_Odds
{
    class Program
    {
        static int GetSumOFEvenDigit(int num)
        {
            int sum=0;
            while(num!=0)
            {
                int a = num % 10;
                if (a % 2 == 0) sum += a;
                num /= 10;
                //Console.WriteLine(a); output only negative numbers
            }
            return sum;
        }
        static int GetSumOfOddDigits(int num)
        {
            int sum = 0;
            while(num!=0)
            {
                int a = num % 10;
                if (a % 2 != 0) sum += a;
                num /= 10;
            }
            return sum;
        }
        static int GetMultipleOfOddAndEven(int num)
        {
            return GetSumOFEvenDigit(num) * GetSumOfOddDigits(num);
        }
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine(GetMultipleOfOddAndEven(Math.Abs(num)));
        }
    }
}
