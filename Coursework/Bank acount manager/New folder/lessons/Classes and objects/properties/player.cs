using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace properties
{
    class player
    {
        private int Lives = 100; //back up field for our property

        public int lives {
            get
            {
                return Lives;
            }
            set
            {
                if (value <= 0||value>=1000)
                {
                    Console.WriteLine("This does not make any sense");
                    return;
                }
                Lives = value;
            }
        }
    }

}
