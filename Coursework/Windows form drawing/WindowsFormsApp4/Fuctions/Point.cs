using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4.Coordinates
{
    public class Point
    {
        public Point(int x,int y)
        {
            this.XCenter = x;
            this.YCenter = y;
        }
        private int xCenter;
        private int yCenter;

        public int YCenter
        {
            get { return yCenter; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("X coordinate can not be negative");
                }
                //to check
                yCenter = value;
            }
        }


        public int XCenter
        {
            get { return xCenter; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("X coordinate can not be negative");
                }
                //to check
                xCenter = value;
            }
        }
    }
}
