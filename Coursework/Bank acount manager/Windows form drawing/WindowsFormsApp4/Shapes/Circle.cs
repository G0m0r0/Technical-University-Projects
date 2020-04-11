using System;
using System.Drawing;
using WindowsFormsApp4.Coordinates;

namespace WindowsFormsApp4.Shapes
{
    [Serializable]
    public class Circle : Shape
    {
        public Circle(MyPoint centerPoint,float radius) : base(centerPoint)
        {
            this.Radius = radius;
        }

        private float radius;

        public float Radius
        {
            get { return radius; }
            private set 
            { 
                if(value<0)
                {
                    throw new Exception("Radius can not be negative!");
                }
                radius = value; 
            }
        }

        public override double CalculateSurface()
        {
            return Math.Round(this.Radius * this.Radius * Math.PI);
        }

        public override double Perimeter()
        {
            return Math.Round(2 * this.Radius * Math.PI);
        }

        public override void Paint(Graphics graphics, Pen pen)
        {
            graphics.DrawEllipse(pen, Point.XCenter, Point.YCenter, radius, radius);
        }

        public override void PaintSolid(Graphics graphics, Brush brush)
        {
            graphics.FillEllipse(brush, Point.XCenter, Point.YCenter, radius, radius);
        }

        public override bool IsInside(Point p)
        {
            var distance = Math.Sqrt(Math.Pow(p.X - Point.XCenter/2,2) + Math.Pow(p.Y - Point.YCenter/2,2));
            if(Math.Pow(distance,2)<=Math.Pow(this.radius,2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
