using System;
using System.IO;
using System.Diagnostics;

namespace p1
{
    class Program
    {
        static int[] Gen(int amount, int min, int max)
        {
            int[] numberArray = new int[amount];

            Random random = new Random();

            for (int i = 0; i < amount; i++)
            {
                int number = random.Next(min, max);
                numberArray[i] = number;
            }

            return numberArray;
        }

        static void Save(int[] numArr, string path)
        {
            if (!(new FileInfo(path).Length == 0))
            {
                File.WriteAllText(path, String.Empty);
            }
            using (StreamWriter numFile = new StreamWriter(path))
            {
                numFile.WriteLine(numArr.Length);
                foreach (int num in numArr)
                {
                    numFile.WriteLine(num);
                    //Console.WriteLine(num + "  saved"); 
                }
            }
        }

        static int[] Load(string path)
        {
            int[] numArr;
            using (StreamReader reader = new StreamReader(path))
            {
                int NofNumbers = Convert.ToInt32(reader.ReadLine());
                numArr = new int[NofNumbers];

                for (int i = 0; i < NofNumbers; i++)
                {
                    numArr[i] = Convert.ToInt32(reader.ReadLine());
                }
            }
            return numArr;
        }

        static void View(string path)
        {
            Process.Start("notepad.exe", path);
        }

        static void SortInFile(string path)
        {
            int[] arr = Load(path);

            int iterations = 1;
            int counter = 0;

            while (iterations > 0 && counter < arr.Length)
            {
                iterations = 0;
                counter++;
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        int keeper = arr[i + 1];
                        arr[i + 1] = arr[i];
                        arr[i] = keeper;

                        iterations++;
                    }
                }
            }
            Save(arr, path);

        }

        static void SortArr(int[] arr)
        {


            int iterations = 1;
            int counter = 0;

            while (iterations > 0 && counter < arr.Length)
            {
                iterations = 0;
                counter++;
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        int keeper = arr[i + 1];
                        arr[i + 1] = arr[i];
                        arr[i] = keeper;

                        iterations++;
                    }
                }
            }


        }

        static void ConsoleLogArr(int[] arr)
        {


            Console.WriteLine(String.Join(" - ", arr));
        }
        static void Main(string[] args)
        {


            if (args.Length > 0)
            {
                if (args[0] == "-h")
                {
                    Console.WriteLine("command: -g {file path}\t\t\t-Generate random numbers and save them in the given file");
                    Console.WriteLine("command: -v {file path}\t\t\t-View the the numbers in the given file(in notepad)");
                    Console.WriteLine("command: -s {file1 path} {file1 path}\t-Sorts the numbers from file1 and saves them in file2");

                }
                else if (args[0] == "-g")
                {
                    string path = args[1];
                    int[] arr = Gen(10, 1, 100);
                    Save(arr, path);
                }
                else if (args[0] == "-v")
                {
                    View(args[1]);
                }
                else if (args[0] == "-s")
                {
                    int[] arr = Load(args[1]);
                    SortArr(arr);
                    Save(arr, args[2]);
                }
                else
                {
                    Console.WriteLine("For help write 'p1.exe -h'");
                }
            }

        }
    }
}
