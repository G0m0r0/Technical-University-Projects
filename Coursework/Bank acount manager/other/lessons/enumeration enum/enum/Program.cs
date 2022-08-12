using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @enum
{
    class player
    {
        public weapons Weapon { get; set; }
        //instead of writing public int weapon
    }
    public enum weapons
    {
            Kalashnikov,
            MachineGun,
            SniperRifle,
            FlameThower
    }
    class Program
    {
        static void Main(string[] args)
        {
            player player = new player();
           // player.Weapon = "MachineGun";
           // if (player.Weapon.Equals("Machinegun")) 
           // {
           //     Console.WriteLine("RUN!");
           // }
           // else if(player.Weapon.Equals("Kalashnikov"))
           // {
           //     Console.WriteLine("Give up!");
           // }
           // else if(player.Weapon.Equals("SniperRifle"))
           // {
           //     Console.WriteLine("Hide");
           // }
           if(player.Weapon==weapons.MachineGun)
            {
                Console.WriteLine("Run!");
            }
           else if(player.Weapon==weapons.Kalashnikov)
            {
                Console.WriteLine("Give up!");
            }
            else if(player.Weapon==weapons.SniperRifle)
            {
                Console.WriteLine("Hide!");
            }
        }
    }
}
