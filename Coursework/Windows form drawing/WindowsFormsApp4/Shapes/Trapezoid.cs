using System;
using System.Drawing;
using WindowsFormsApp4.Coordinates;

namespace WindowsFormsApp4.Shapes
{
    [Serializable]
    class Trapezoid : Shape
    {
        public Trapezoid(MyPoint centerPoint, double sideOne, double sideTwo, double sideThree, double sideFour) : base(centerPoint)
        {
            this.SideOne = sideOne;
            this.SideTwo = sideTwo;
            this.SideThree = sideThree;
            this.SideFour = sideFour;
        }

        private double sideOne;
        private double sideTwo;
        private double sideThree;
        private double sideFour;

        public double SideTwo
        {
            get { return sideTwo; }
            private set
            {
                if (value < 0)
                {
                    throw new Exception("Can not be negative!");
                }
                sideTwo = value;
            }
        }


        public double SideOne
        {
            get { return sideOne; }
            private set
            {
                if (value < 0)
                {
                    throw new Exception("Can not be negative!");
                }
                sideOne = value;
            }
        }

        public double SideThree
        {
            get { return sideThree; }
            private set
            {
                if (value < 0)
                {
                    throw new Exception("Can not be negative!");
                }
                sideThree = value;
            }
        }

        public double SideFour
        {
            get { return sideFour; }
            private set
            {
                if (value < 0)
                {
                    throw new Exception("Can not be negative!");
                }
                sideFour = value;
            }
        }


        public override double CalculateSurface()
        {
            return Math.Round( this.SideOne * this.SideTwo);
        }

        public override double Perimeter()
        {
            return Math.Round( this.SideOne * 2 + this.SideTwo * 2);
        }

        public override void Paint(Graphics graphics, Pen pen)
        {
            throw new NotImplementedException();
        }

        public override bool IsInside(Point p)
        {
            throw new NotImplementedException();
        }

        public override void PaintSolid(Graphics graphics, Brush brush)
        {
            throw new NotImplementedException();
        }
    }
}
