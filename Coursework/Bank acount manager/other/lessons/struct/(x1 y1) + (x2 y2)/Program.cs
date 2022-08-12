using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _x1_y1_____x2_y2_
{
    class Program
    {
        struct point
        {
            public double x;
            public double y;
          //  public Point();
          //  {
          //   Console.WriteLine("Yeeeey!");
          //  }
            public void add(point othe) // static void Add(Point this, Point p) {}
            {
                x += othe.x;
                y += othe.y;
            }
        }
        static void pointInspector(point point)
        {
            Console.WriteLine($"X: {point.x}\nY: {point.y}");
        }
        static void Main(string[] args)
        {
            point p1 = new point();
            point p2 = new point();
            p1.x = 2.3;
            p1.y = 5.3;

            p2.x = 1.2;
            p2.y = 4.5;

            pointInspector(p1); //p1 
            p1.add(p2); // Point.Add(p1, p2)
            pointInspector(p1); //p1+p2
        }
    }
}
