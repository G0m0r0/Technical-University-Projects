using System;
using System.IO;

namespace array_read_write
{
    class Program
    {
        static void Inputarray(double[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write("Element {0}{1} = ",i,j);
                    array[i,j] = double.Parse(Console.ReadLine());
                }
            }
        }
        static void Output(double[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j <array.GetLength(1); j++)
                {
                    Console.WriteLine(array[i,j]+" ");
                }
            }
        }
        static void WriteToFile(double[,] array)
        {
            using (var sw = new StreamWriter("D:\\text.txt",false))
            {
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        sw.Write(array[i,j] + " ");
                    }
                    sw.Write("\n");
                }
                sw.Flush();
                sw.Close();
            }
        }
        static void ReadToFile(double[,] array)
        {
            int n = array.GetLength(0);
            int m = array.GetLength(1);
            String input = File.ReadAllText("D:\\text.txt");
            int i = 0, j = 0;
            foreach (var row in input.Split('\n'))
            {
                if (row == "") break;
                j = 0;
                foreach (var col in row.Trim().Split(' '))
                {
                    array[i, j] = Convert.ToDouble(col.Trim());
                    j++;
                }
                i++;
            }
        }
        static void Main()
        {
            Console.WriteLine("Enter 2D array lenght:");
            Console.Write("n= ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("m= ");
            int m = int.Parse(Console.ReadLine());
            double[,] array = new double[n,m];
            Console.WriteLine("0-Menu " +
                " 1-Input 2D array " +
                " 2-Output array " +
                " 3-Save to file " +
                " 4-Read File ");
            Console.WriteLine("5-Insertion sort+ " +
                " 6-Buble sort " +
                " 7-Selection sort " +
                " 8-Enter stop for stop");  
            string choice = string.Empty;
            do
            {
                Console.Write("Enter number of choice: ");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": Inputarray(array); break;
                    case "2": Output(array); break;
                    case "3": WriteToFile(array); break;
                    case "4": ReadToFile(array); break;
                    case "5": break;
                    case "6": break;
                    case "7": break;
                    case "8": choice = "stop"; break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Wrong comand! Type something else.");
                        Console.WriteLine();
                        break;
                }
            } while (choice != "stop");
        }
    }
}
