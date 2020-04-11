using System;
using System.Collections.Generic;
using System.Linq;

namespace count_number_of_words
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> text = Console.ReadLine()
                .Trim()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Console.WriteLine(text.Count);
        }
    }
}
