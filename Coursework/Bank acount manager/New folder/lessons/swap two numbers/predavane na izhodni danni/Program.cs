using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace predavane_na_izhodni_danni
{
    class Program
    {
        static voidPrintSquared(int val, out int squared)
        {
            squared = val * val;
            Console.WriteLine("squared ={0}", squared);
        }
        static void Main(string[] args)
        {
            int v = int.Parse(Console.ReadLine()); // напр. v=5	
            int vv;
            PrintSquared(v, out vv);
            Console.WriteLine("vv={0}", vv); // vv=25
        }
    }
}
