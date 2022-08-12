using System;
using System.Linq;

namespace higest_occurence_of_char
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] text = Console.ReadLine().ToCharArray();
            Array.Sort(text);

            char bestCh = ' ';
            int bestCount = 0;
            int count = 0;
            char previousCh = text[0];

            for (int i = 1; i < text.Length; i++)
            {

                if (previousCh == text[i])
                    count++;
                else
                {
                    count = 0;
                    previousCh = text[i];
                }
                if (count > bestCount)
                {
                    bestCount = count;
                    bestCh = text[i];
                }
            }
            Console.WriteLine($"High occurance of char is {bestCount+1} with symbol {bestCh}");
        }
    }
}
