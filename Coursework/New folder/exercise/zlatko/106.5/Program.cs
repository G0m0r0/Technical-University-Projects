using System;

namespace _106._5
{
    class Program
    {
        static void Main(string[] args)
        {
            //sort colors in array
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
            for (int i = 0; i <= whiteIndex; i++)
            {
                if (colorArray[i] == "Red")
                    swap(colorArray, redIndex++, i--);

                else if (colorArray[i] == "White")
                    swap(colorArray, i-- , whiteIndex--);
            }
        }


        static void swap(string[] colorArray, int first, int second)
        {
            string swap = colorArray[first];
            colorArray[first] = colorArray[second];
            colorArray[second] = swap;
        }

        private static void FillColorArray(string[] colorArray)
        {
            Random rnd = new Random(10);
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