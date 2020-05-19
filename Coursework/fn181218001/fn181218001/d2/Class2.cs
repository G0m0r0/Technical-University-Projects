using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Threading;
 
namespace ConsoleApp1
    {
        class Program
        {

            static void Gen(int amount, int min, int max, string memMapFile, string mutexName)
            {
                int[] numberArray = new int[amount];

                Random random = new Random();

                for (int i = 0; i < amount; i++)
                {
                    int number = random.Next(min, max);
                    numberArray[i] = number;
                }




                using (MemoryMappedFile mapedNumbers = MemoryMappedFile.OpenExisting(memMapFile))
                {
                    Mutex mutex = Mutex.OpenExisting(mutexName);
                    mutex.WaitOne();

                    using (MemoryMappedViewStream stream = mapedNumbers.CreateViewStream())
                    {
                        BinaryWriter writer = new BinaryWriter(stream);

                        writer.BaseStream.Seek(0, SeekOrigin.Begin);
                        writer.BaseStream.Write(new byte[10000000], 0, 10000000);
                        writer.BaseStream.Seek(0, SeekOrigin.Begin);



                        string arrayToString = "Length:" + Convert.ToInt32(numberArray.Length) + " -- " + String.Join(" ", numberArray);

                        writer.Write(arrayToString);
                    }
                    mutex.ReleaseMutex();
                }
            }

            static void SaveToFile(string path, string arr)
            {
                int[] array = Array.ConvertAll(arr.Split(' ').Where(w => w != arr.Split(' ')[0] && w != arr.Split(' ')[1]).ToArray(), s => int.Parse(s));
                using (StreamWriter writer = new StreamWriter(path))
                {
                    foreach (int a in array)
                    {
                        writer.WriteLine(a);
                    }
                }
            }

            static void Save(string path, string memMapedFile, string mutexName)
            {
                using (MemoryMappedFile mapedNumbers = MemoryMappedFile.OpenExisting(memMapedFile))
                {
                    Mutex mutex = Mutex.OpenExisting(mutexName);
                    mutex.WaitOne();

                    using (MemoryMappedViewStream stream = mapedNumbers.CreateViewStream())
                    {
                        BinaryReader reader = new BinaryReader(stream);

                        string numbers = reader.ReadString();

                        SaveToFile(path, numbers);
                    }
                    mutex.ReleaseMutex();
                }
            }

            static int[] StringToIntArr(string arr)
            {
                int[] array = Array.ConvertAll(arr.Split(' ').Where(w => w != arr.Split(' ')[0] && w != arr.Split(' ')[1]).ToArray(), s => int.Parse(s));
                return array;
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

            static void Sort(string memMapedFile, string mutexName)
            {
                using (MemoryMappedFile mapedNumbers = MemoryMappedFile.OpenExisting(memMapedFile))
                {
                    Mutex mutex = Mutex.OpenExisting(mutexName);
                    mutex.WaitOne();

                    using (MemoryMappedViewStream stream = mapedNumbers.CreateViewStream())
                    {
                        BinaryReader reader = new BinaryReader(stream);

                        string numbers = reader.ReadString();

                        int[] array = StringToIntArr(numbers);
                        SortArr(array);
                        string arrayToString = "Length:" + Convert.ToInt32(array.Length) + " -- " + String.Join(" ", array);


                        BinaryWriter writer = new BinaryWriter(stream);
                        stream.Position = 0;
                        writer.Write(arrayToString);

                    }
                    mutex.ReleaseMutex();
                }
            }

            static int[] LoadArr(string path)
            {
                int[] numArr;
                using (StreamReader reader = new StreamReader(path))
                {
                    string arr = reader.ReadToEnd();
                    arr = arr.Trim();
                    int[] array = Array.ConvertAll(arr.Split('\r').ToArray(), s => int.Parse(s));
                    int NofNumbers = Convert.ToInt32(reader.ReadLine());
                    numArr = new int[NofNumbers];

                    for (int i = 0; i < NofNumbers; i++)
                    {
                        numArr[i] = Convert.ToInt32(reader.ReadLine());
                    }
                    return array;
                }
            }

            static void Load(string path, string memMapedFile, string mutexName)
            {


                using (MemoryMappedFile mapedNumbers = MemoryMappedFile.OpenExisting(memMapedFile))
                {

                    Mutex mutex = Mutex.OpenExisting(mutexName);
                    mutex.WaitOne();

                    using (MemoryMappedViewStream stream = mapedNumbers.CreateViewStream())
                    {

                        int[] array = LoadArr(path);

                        string arrayToString = "Length:" + Convert.ToInt32(array.Length) + " -- " + String.Join(" ", array);


                        BinaryWriter writer = new BinaryWriter(stream);
                        writer.BaseStream.Seek(0, SeekOrigin.Begin);
                        writer.BaseStream.Write(new byte[10000000], 0, 10000000);
                        writer.BaseStream.Seek(0, SeekOrigin.Begin);
                        writer.Write(arrayToString);

                    }
                    mutex.ReleaseMutex();
                }
            }


            /*string MapedFileName = "testmap";
            string MutexName = "testmapmutex";

            string mapFile1 = "asd";
            string mutex1 = "sda";

            MemoryMappedFile mapedNumbers = MemoryMappedFile.CreateNew(MapedFileName, 10000000);
            bool mutexCreated;
            Mutex mutex = new Mutex(true, MutexName, out mutexCreated);

            MemoryMappedFile mapedNumbers2 = MemoryMappedFile.CreateNew(mapFile1, 10000000);
            bool mutexCreated1;
            Mutex mutex2 = new Mutex(true, mutex1, out mutexCreated1);


            mapedNumbers2.Dispose();
            mutex2.Dispose();

            mapedNumbers.Dispose();
            mutex.Dispose();*/


        }

    }

