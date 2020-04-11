using System;
using System.Text;
using System.Collections.Generic;

namespace _30._12
{
    class Program
    {
        static void Main(string[] args)
        {
            //palendrom page 30 exercise 12
            string palindrom = Console.ReadLine();
            int start = 0;
            int end = palindrom.Length - 1;

            Console.WriteLine(PalendromMethod(palindrom, start, end));
        }

        private static bool PalendromMethod(string palindrom, int start, int end)
        {
            if (palindrom.Length / 2 == end && palindrom.Length != 2)
                return true;
            else if (palindrom.Length == 0)
                return true;
            else if (palindrom.Length == 1)
                return true;

            return palindrom[start] == palindrom[end] ? PalendromMethod(palindrom, start + 1, end - 1) : false;
        }
    }
}

