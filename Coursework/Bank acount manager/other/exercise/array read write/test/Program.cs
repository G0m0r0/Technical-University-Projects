using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            string a =  "2.5 4.6 7.8" ;
            string[] array = a.Split(' ');
            double[] arrayDouble = new double[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                arrayDouble[i] = double.Parse(array[i]);
            }
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(arrayDouble[i]+" ");
            }
        }
    }
}
