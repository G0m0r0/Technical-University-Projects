using System;

namespace Trignagle
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Triangle[] arrayOfTriangles = new Triangle[3];
            for (int i = 0; i < arrayOfTriangles.Length; i++)
            {
                Console.Write($"Hight {i+1}= ");
                double hight = double.Parse(Console.ReadLine());
                Console.Write($"Base  {i+1}= ");
                double baseTriangle = double.Parse(Console.ReadLine());

                arrayOfTriangles[i] = new Triangle(hight, baseTriangle);
            }

            for (int i = 0; i < arrayOfTriangles.Length; i++)
            {
                Console.WriteLine($"Surface {i+1} = {arrayOfTriangles[i].Surface()}");
            }
        }
    }
}
