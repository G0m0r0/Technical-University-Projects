using System;
using WindowsFormsApp4.Coordinates;

namespace WindowsFormsApp4.Shapes
{
    [Serializable]
    public class Square : Rectangle
    {
        public Square(MyPoint centerPoint, float sideOne) : base(centerPoint, sideOne, sideOne)
        {
        }

    }
}
