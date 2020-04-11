using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OOPproject
{
    [Serializable]
    public class Ellipse : Shape
    {
        public Ellipse(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }
        
            
        
        public override void Paint(Graphics g)
        {

            Pen pen = new Pen(Color.Black, 3);
            SolidBrush brush = new SolidBrush(FillColor);

            g.DrawEllipse(pen, ShapePos.X, ShapePos.Y, Width, Height);
            g.FillEllipse(brush, ShapePos.X, ShapePos.Y, Width, Height);
        }

        public override double CalculateArea()
        {
            return Width/2 * Height/2*Math.PI;//calc area
        }
       
    }
}
