using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @foreach
{
    //colections of data //we loop trough the collection
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[5];
            array[0] = 1;
            array[1] = 10;
            array[2] = 100;
            array[3] = 1000;
            array[4] = 10000;

           //for (int i = 0; i <=array.Length; i++)
           //{
           //    Console.WriteLine(array[i]);
           //}

            foreach (var element in array)
            {
                Console.WriteLine(element); //element individual intem
            }
        }
    }
}
