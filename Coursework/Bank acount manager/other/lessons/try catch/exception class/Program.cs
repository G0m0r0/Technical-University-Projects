using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exception_class
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
                c = a / b;
                Console.WriteLine("Division of a by b is {0}", c);
            }
            //we can have multiple catch blocks
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Error: "+ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: "+ex.Message);
            }    
            finally
            {
                Console.WriteLine("Program executed");
            }
            
        }
    }
}
