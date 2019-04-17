using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repeat_string
{
    class Program
    {
        static string MultiplyString(string str,int count)
        {
            string finalStr = string.Empty;
            for (int i = 0; i < count; i++)
            {
                finalStr += str;
            }
            return finalStr;
        }
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            int repeatCount = int.Parse(Console.ReadLine());
            Console.WriteLine(MultiplyString(str,repeatCount));
        }
    }
}
