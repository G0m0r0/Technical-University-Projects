using System;

namespace palendrom_string
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] str = Console.ReadLine().Trim().ToLower().ToCharArray();

            for (int i = str.Length - 1; i > str.Length/2; i--)
            {
                    if (str[i] != str[str.Length - i - 1])
                    {
                        Console.WriteLine("Not palendrom");
                        return;
                    }
            }
            Console.WriteLine("Palentrom");
        }
    }
}
