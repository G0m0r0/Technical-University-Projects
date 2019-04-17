using System;
using System.Collections.Generic;
using System.Linq;

namespace all_unique_characters
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> text = Console.ReadLine().ToList();

            for (int i = 0; i < text.Count; i++)
            {
                char ch = text[0];
                text.RemoveAt(0);
                if (text.Contains(ch))
                {
                    Console.WriteLine("There is dublicated characters!");
                    return;
                }
            }
            Console.WriteLine("There is NOT dublicated characters!");
        }
    }
}
