using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace properties
{
    class Program
    {
        static void Main(string[] args)
        {
            player player = new player();
            Console.WriteLine("Enter number of lives");
            player.lives = int.Parse(Console.ReadLine());
            Console.WriteLine(player.lives);
        }
    }
}
