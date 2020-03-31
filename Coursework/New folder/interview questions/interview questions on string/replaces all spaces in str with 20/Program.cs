using System;

namespace replaces_all_spaces_in_str_with_20
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            str = str.Trim().Replace(" ","%20");
            Console.WriteLine(str);
        }
    }
}
