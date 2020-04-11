using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace greatest_of_two_values
{
    class Program
    {

       static int GetMax(int a, int b)
       {
            return a > b ? a : b;
       }
        static char GetMax(char a,char b)
        {
            return a > b ? a : b;
        }
       static string GetMax(string a,string b)
       {
            int sumA = 0, sumB = 0;
            char[] arr1 = a.ToArray();
            char[] arr2 = b.ToArray();
            foreach (char c in arr1)
                sumA += c;
            foreach (char c in arr2)
                sumB += c;
            return sumA > sumB ? a : b;
       }
       static void Main(string[] args)
       {
            string dataType = Console.ReadLine();
            if(dataType=="int")
            {
                int a = int.Parse(Console.ReadLine());
                int b = int.Parse(Console.ReadLine());
                Console.WriteLine(GetMax(a,b));
            }
            else if(dataType=="char")
            {
                char a = char.Parse(Console.ReadLine());
                char b = char.Parse(Console.ReadLine());
                Console.WriteLine(GetMax(a,b));
            }
            else if(dataType=="string")
            {
                string a = Console.ReadLine();
                string b = Console.ReadLine();
                Console.WriteLine(GetMax(a,b));
            }
       }
    }
}
