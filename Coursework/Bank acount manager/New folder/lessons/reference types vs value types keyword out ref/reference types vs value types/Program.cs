using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reference_types_vs_value_types
{
    class Program
    {
        //
        static void Main(string[] args)
        {
            bool a = true;
            makeitFalse(ref a);
      
            Console.WriteLine(a); //stays true if we dont put ref 
        }
        static void makeitFalse(ref bool a)
        {
            a = false;
        }
    }
}
