using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace switch_two_numbers
{
    {
        class Program
        {
            static void Main(string[] args)
            {
                int a = 5;
                int b = 9;

                int temp;
                temp = a; // a = 5, b = 9, temp = 5
                a = b;    // a = 9, b = 9, temp = 5
                b = temp; // a = 9, b = 5, temp = 5
                Console.WriteLine("a={0}, b={1}", a, b);
            }
        }
    }

}
    }
}
