using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace how_many_dots_and_commas
{
    class Program
    {
        static int countDots(string text)
        {
            int countDots = 0;
            foreach (var item in text)
            {
                if (item == '.') countDots++;
            }
            return countDots;
        }
        static int countCommas(string text)
        {
            int countCommas = 0;
            foreach (var item in text)
            {
                if (item == ',') countCommas++;
            }
            return countCommas;
        }
        static int countInteger(string text)
        {
            int countOfInteger = 0;
            bool flag = true;
            foreach (char item in text)
            {
                if (item < 48 || item > 57) flag = true;
                else if (flag != false)
                {
                    countOfInteger++;
                    flag = false;
                }
            }
            return countOfInteger;
        }
        static void Main(string[] args)
        {
            Console.Write("Write path to file: ");
            string path = Console.ReadLine();
            if (File.Exists(path))
            {
              //  string text = File.ReadAllText(path);
               
                using (StreamReader reader = new StreamReader(path))
                {
                    string text = string.Empty;
                    while (true)
                    {
                        string line = reader.ReadLine();
                       
                        if (line == null)
                        {
                            break;
                        }
                        text = text + line;
                        
                    }
                    Console.WriteLine("Number of Dots is: {0}", countDots(text));
                    Console.WriteLine("Number of commas is: {0} ", countCommas(text));
                    Console.WriteLine("Number of integer is: {0}", countInteger(text));
                }
            }
            else Console.WriteLine("The following path: {0} is invalid", path);
        }
    }
}
