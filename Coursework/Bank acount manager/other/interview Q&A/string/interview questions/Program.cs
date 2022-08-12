using System;
using System.Linq;

namespace interview_questions
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] str1 = Console.ReadLine().ToCharArray();
            char[] str2 = Console.ReadLine().ToCharArray();
            Array.Sort(str1);
            Array.Sort(str2);
            if (string.Join("", str1) == string.Join("", str2))
                Console.WriteLine("Anagrams");
            else
            Console.WriteLine("Not anagrams");
        }
    }
}
