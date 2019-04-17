using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hanoi_tower
{
    class HanoiSolver
    {
        int counter;
    }
    class Program
    {
        static void MoveDisk(int disks, string starSpike, string endSpike, string helpSpike)
        {
            if (disks == 1)
                Console.WriteLine($"Move from {starSpike} to {endSpike}");
            else
            {
                MoveDisk(disks - 1, starSpike, helpSpike, endSpike);
                MoveDisk(1, starSpike, endSpike, helpSpike);
                MoveDisk(disks - 1, helpSpike, endSpike, starSpike);
            }
        }
        static void HanoiSlover(int disks)
        {
            MoveDisk(disks, "Left", "Right", "Middle");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Number of disks");
            int n = int.Parse(Console.ReadLine());
            HanoiSlover(n);
        }
    }
}
