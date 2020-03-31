using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recursion
{
    class Program
    {
        //fibunachi sequence 0 1 1 2 3 5 8 13 21
        static int recursion(uint n)
        {
            if (n == 1) return 0;
            if (n == 2) return 1;
            return recursion(n - 1) + recursion(n - 2);
        }
        static void Main(string[] args)
        {
            uint n = uint.Parse(Console.ReadLine());
        }
    }
}
