using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OOPproject
{[Serializable]
    public abstract class Shape 

    {
        public Point ShapePos { get; set; }
        //protected string Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Color FillColor { get; set; }

        public abstract void Paint(Graphics g);
        public abstract double CalculateArea();
        //public abstract string GetName();
       
    }
   
}
