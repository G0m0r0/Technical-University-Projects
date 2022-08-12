using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_errors
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int a, b, c;
                Console.WriteLine("enter value of a");
                a = int.Parse(Console.ReadLine());
                Console.WriteLine("enter value of b");
                b = int.Parse(Console.ReadLine());
                //logical implimentation
                //if(b==0)
                //{
                //    Console.WriteLine("enter number other of zero");
                //    return;
                //}
                c = a / b;
                Console.WriteLine("Division of a by b is {0}", c);
            }
            catch 
            {
                Console.WriteLine("Error occured!");
            }
            finally
            {
                Console.WriteLine("Program executed");
            }
            
        }
    }
}
