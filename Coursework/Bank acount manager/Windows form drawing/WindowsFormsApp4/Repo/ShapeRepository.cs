using System;
using System.Collections.Generic;
using WindowsFormsApp4.Shapes;

namespace WindowsFormsApp4.ShapeActions
{
    [Serializable]
    public class ShapeRepository
    {
        public ShapeRepository()
        {
            this.shapes = new List<Shape>();
        }
        public List<Shape> shapes { set; get; }

        public void AddShape(Shape shape)
        {
            shapes.Add(shape);
        }
    }
}
