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
            int x1 = int.Parse(Console.ReadLine());
            int y1 = int.Parse(Console.ReadLine());
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            for (int i = 0; i < 1; i++)
            {

            }
            if (x1 > x && y1 < y)
            {
                Console.WriteLine("SW");
            }
            else if (x1 > x && y1 == y)
            {
                Console.WriteLine("W");
            }
        }
    }
}
