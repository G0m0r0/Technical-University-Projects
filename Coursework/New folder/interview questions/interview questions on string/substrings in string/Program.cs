using System;

namespace substrings_in_string
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            for (int i = 1; i < text.Length; i++)
            {
                for (int j = 0; j <= text.Length-i; j++)
                {
                    Console.WriteLine(text.Substring(j,i));
                }
            }
        }
    }
}
