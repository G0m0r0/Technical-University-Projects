using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swap_two_numbers_with_functions
{
    class Program
    {
        public static void Swap(ref int a,ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
            Console.WriteLine("a ={0}, b ={1}", a, b); //without a=5, b=0
        }
            static void Main(string[] args)
        {
            int x = 0, y = 5;
            x = int.Parse(Console.ReadLine());
           y = int.Parse(Console.ReadLine());
            Swap(ref x, ref y);
            Console.WriteLine("x ={0}, y ={1}", x, y); //without ref x=0, y=5//predavat se po stoinost-adress
            //s ref se predavat po psevdonim
            //reference-adress
        }
    }
}
