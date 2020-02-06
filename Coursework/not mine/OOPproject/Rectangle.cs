using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OOPproject
{
    [Serializable]
    public class Rectangle : Shape
    {
        public Rectangle(int width, int height)
        {
            //Name = "Rectangle";
            
            this.Width = width;
            this.Height = height;
        }
           


        public override void Paint(Graphics g)
        {

            Pen pen = new Pen(Color.Black, 3);
            SolidBrush brush = new SolidBrush(FillColor);

            g.DrawRectangle(pen, ShapePos.X, ShapePos.Y, Width, Height);
            g.FillRectangle(brush, ShapePos.X, ShapePos.Y, Width, Height);
        }

        public override double CalculateArea()
        {
            return Width * Height/2;
        }
       
    }

        
}
