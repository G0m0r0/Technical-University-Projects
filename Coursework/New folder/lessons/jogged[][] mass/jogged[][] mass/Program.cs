using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jogged_____mass
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] jaggedArray = new int[2][];
            jaggedArray[0] = new int[3] { 1, 2, 3 };
            jaggedArray[1] = new int[1] { 4 };

            foreach (var arr in jaggedArray)
            {
                foreach (var element in arr)
                Console.Write("{0}", element);
                Console.WriteLine();
            }
        }
    }
}
