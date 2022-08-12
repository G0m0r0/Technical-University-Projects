using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reference_types_vs_value_types
{
    class Program
    {
        static void Main(string[] args)
        {
            bool a; //we dont need the variable to be initialize
            makeitFalse(out a);

            Console.WriteLine(a); 
        }
        static void makeitFalse(out bool a)
        {
            a = false; //but we must to assignt it here
        }
    }
}

