using System;
using System.Collections.Generic;
using System.Text;

namespace Trignagle
{
    public class Triangle
    {
        public double Hight { get; set; }
        public double BaseTriangle { get; set; }

        public Triangle(double hight,double baseTriangle)
        {
            this.BaseTriangle = baseTriangle;
            this.Hight = hight;
        }

        public double Surface()
        {
            return this.BaseTriangle * this.Hight/2;
        }
    }
}
