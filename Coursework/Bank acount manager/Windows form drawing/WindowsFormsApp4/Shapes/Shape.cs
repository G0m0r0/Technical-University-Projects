using System;
using System.Drawing;
using WindowsFormsApp4.Coordinates;

namespace WindowsFormsApp4.Shapes
{
    [Serializable]
    public abstract class Shape
    {
        protected Shape(MyPoint centerPoint)
        {
            this.Point = centerPoint;
        }
        public abstract bool IsInside(Point p);

        public readonly MyPoint Point;

        public abstract double CalculateSurface();

        public abstract double Perimeter();

        public abstract void Paint(Graphics graphics, Pen pen);

        public abstract void PaintSolid(Graphics graphics, Brush brush);
    }
}
