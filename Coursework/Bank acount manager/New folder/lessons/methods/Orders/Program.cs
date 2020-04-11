using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders
{
    class Program
    {
        static void SumPrice(string product,int quantity)
        {
            if (product == "coffee") Console.WriteLine($"{(1.5*quantity):f2}");
            else if (product == "water") Console.WriteLine($"{quantity:f2}");
            else if (product == "coke") Console.WriteLine($"{(quantity*1.4):f2}");
            else if (product == "snacks") Console.WriteLine($"{(quantity*2):f2}");
        }
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            SumPrice(product, quantity);
        }
    }
}
