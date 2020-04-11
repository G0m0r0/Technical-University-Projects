using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace OOPproject
{
    [Serializable]
    class Scene
    {
        private List<Shape> shapesList = new List<Shape>();
        private List<Shape> selectedShape = new List<Shape>();

        public void Paint(Graphics g)
        {
            foreach (var shape in shapesList)
                shape.Paint(g);
        }
        public void AddShape(Shape shape)
        {
            shapesList.Add(shape);
        }

        public void AddSelectedShape(Point p)
        {
            selectedShape = shapesList
                        .Where(r => r.ShapePos.X < p.X &&
                                    r.ShapePos.Y < p.Y &&
                                   (r.ShapePos.X + r.Width) > p.X &&
                                   (r.ShapePos.Y + r.Height) > p.Y
                        )
                        .ToList();
        }
        public void ChangeColorandSize(int w,int h,Color color)
        {
            foreach (var shape in selectedShape)
            {
                
                shape.FillColor = color;
                shape.Width = w;
                shape.Height = h;
            }
        }
        public void RemoveShape()
        {
            foreach (var item in selectedShape)
            {
                shapesList.Remove(item);
            }

        }

        public void MoveShape(Point p)
        {
            foreach (var shape in selectedShape)
            {
                //var point1 = new Point((shape.ShapePos.X-p.X),shape.ShapePos.Y-p.Y);
                //p.Offset(point1);

                shape.ShapePos = p;




            }
        }

        public void ShowArea()
        {
            foreach (var shape in selectedShape)
            {
                MessageBox.Show($"Area of selected shape is: {shape.CalculateArea()}");
            }
        }
    }
}
