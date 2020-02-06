using System;
using System.Drawing;
using WindowsFormsApp4.Coordinates;

namespace WindowsFormsApp4.Shapes
{
    [Serializable]
    class Triangle : Shape
    {
        public Triangle(MyPoint centerPoint, float sideOne, float sideTwo, float sideThree ) : base(centerPoint)
        {
            this.SideOne = sideOne;
            this.SideTwo = sideTwo;
            this.SideThree = sideThree;
        }
        
        private float sideOne;

        public float SideOne
        {
            get { return sideOne; }
            private set
            {
                if (value < 0)
                {
                    throw new Exception("Side one can not be negative!");
                }
                sideOne = value;
            }

        }

        private float sideTwo;

        public float SideTwo
        {
            get { return sideTwo; }
            private set
            {
                if (value < 0)
                {
                    throw new Exception("Side two can not be negative!");
                }
                sideTwo = value;
            }

        }

        private float sideThree;

        public float SideThree
        {
            get { return sideThree; }
            private set
            {
                if (value < 0)
                {
                    throw new Exception("Side three can not be negative!");
                }
                sideThree = value;
            }

        }

        public override double CalculateSurface()
        {
            double halfPerimeter = Perimeter() / 2;
            return Math.Round( Math.Sqrt
                (halfPerimeter * 
                (halfPerimeter - this.SideOne) * 
                (halfPerimeter - this.SideTwo) * 
                (halfPerimeter - this.SideThree)));
        }

        public override double Perimeter()
        {
            return Math.Round( this.SideOne + this.SideTwo + this.SideThree);
        }

        public override void Paint(Graphics graphics, Pen pen)
        {
            Point[] points = { new Point(this.Point.XCenter, this.Point.YCenter),
                new Point(this.Point.XCenter + (int)sideOne, this.Point.YCenter),
                new Point(this.Point.XCenter + (int)sideOne/2, this.Point.YCenter + (int)SideTwo) };

            graphics.DrawPolygon(pen, points);
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
