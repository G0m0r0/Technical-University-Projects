using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace OOPproject
{
    [Serializable]
    public class Triangle : Shape
    {
        public Triangle(int width, int height)
        {
            
            this.Width = width;
            this.Height = height;
        }



        public override void Paint(Graphics g)
        {

            Pen pen = new Pen(Color.Black, 3);
            SolidBrush brush = new SolidBrush(FillColor);

            g.DrawLine(pen, ShapePos.X + (Width / 2), ShapePos.Y, ShapePos.X + Width, ShapePos.Y + Height);
            g.DrawLine(pen, ShapePos.X + (Width / 2), ShapePos.Y, ShapePos.X, ShapePos.Y + Height);
            g.DrawLine(pen, ShapePos.X, ShapePos.Y + Height, ShapePos.X + Width, ShapePos.Y + Height);
            var path = new GraphicsPath();
            path.AddLine(ShapePos.X + (Width / 2), ShapePos.Y, ShapePos.X + Width, ShapePos.Y + Height);
            path.AddLine(ShapePos.X + (Width / 2), ShapePos.Y, ShapePos.X, ShapePos.Y + Height);
            path.AddLine(ShapePos.X, ShapePos.Y + Height, ShapePos.X + Width, ShapePos.Y + Height);
            g.FillPath(brush, path);

        }

        public override double CalculateArea()
        {
            return Width * Height;
        }

    }
}
