using System;
using System.Drawing;
using WindowsFormsApp4.Coordinates;

namespace WindowsFormsApp4.Shapes
{
    [Serializable]
    public class Rectangle : Shape
    {
        public Rectangle(MyPoint centerPoint,float sideOne,float sideTwo) : base(centerPoint)
        {
            this.SideOne = sideOne;
            this.SideTwo = sideTwo;
        }

        private float sideOne;
        private float sideTwo;

        public float SideTwo
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


        public float SideOne
        {
            get { return sideOne; }
            private set 
            { 
                if(value<0)
                {
                    throw new Exception("Can not be negative!");
                }
                sideOne = value; 
            }
        }

        public override bool IsInside(Point p)
        {
            if (p.X < Point.XCenter || p.Y > Point.YCenter)
            {
                return false;
            }
            if(p.X> Point.XCenter+sideOne||p.Y>Point.YCenter+sideTwo)
            {
                return false;
            }

            return true;
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
            graphics.DrawRectangle(pen, Point.XCenter, Point.YCenter, SideOne, SideTwo);
        }

        public override void PaintSolid(Graphics graphics, Brush brush)
        {
            graphics.FillRectangle(brush, Point.XCenter, Point.YCenter, SideOne, SideTwo);
        }
    }
}
