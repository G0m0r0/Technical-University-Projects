using System;

namespace _106._5
{
    class Program
    {
        static void Main(string[] args)
        {
            //sort colors in array- not finished
            Console.Write("Enter lenght of the array: ");
            int n = int.Parse(Console.ReadLine());
            string[] colorArray = new string[n];

            FillColorArray(colorArray);

            TakeColorsInOrder(colorArray);
            Console.WriteLine(string.Join(" ", colorArray));
        }

        private static void TakeColorsInOrder(string[] colorArray)
        {
            int redIndex = 0;
            int whiteIndex = colorArray.Length - 1;
            for (int i = 0; i < colorArray.Length; i++)
            {
                switch (colorArray[i])
                {
                    case "Red":
                        swap(ref colorArray[i], ref colorArray[redIndex]);
                        redIndex++;
                        break;
                    case "White":
                        swap(ref colorArray[i], ref colorArray[whiteIndex]);
                        i--;
                        whiteIndex--;
                        break;
                }
            }
        }
        static void swap(ref string colorOne, ref string colorTwo)
        {
            string swap = colorOne;
            colorOne = colorTwo;
            colorTwo = swap;
        }
        private static void FillColorArray(string[] colorArray)
        {
            Random rnd = new Random(5);
            string[] colors = new string[]
            {
                 "Red","White","Blue"
            };

            for (int i = 0; i < colorArray.Length; i++)
            {
                int randomIndexColor = rnd.Next(0, colors.Length);
                colorArray[i] = colors[randomIndexColor];
            }

        }
    }
}
