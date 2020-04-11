using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace calculator
{
    class Logger
    {
        public static void WriteToLog(string logEntry) //we can put exeption instead of string bcs its bigger class than zerro execption...
        {
            using (StreamWriter stream = new StreamWriter("calculator.log", true))
            {
                stream.WriteLine(logEntry);
            }
        }
    }
    class divideByFourtyTwoException : Exception //throw our execption
    {
        public divideByFourtyTwoException(string message) : base("Divison by 42") { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string yesNo =string.Empty;
            do
            {
                try
                {
                    Console.Write("A= ");
                    int a = int.Parse(Console.ReadLine());

                    Console.Write("B= ");
                    int b = int.Parse(Console.ReadLine());

                    int c = a / b;
                    Console.WriteLine("Result " + c);
                }
                catch(Exception e)
                {
                    //exception is the main class it catches all the errors
                    //not good practise because we cant handle all exception better the program to fail
                    //Console.WriteLine("Error! ");
                    Console.WriteLine(e.Message); //show error
                    //Console.WriteLine(e.Source);
                    // Console.WriteLine(e.StackTrace);
                    Logger.WriteToLog(e.Message); //create class that write in file the exeption for later handaling
                }
                //we can have multiple try catch
                Console.WriteLine("Do you want to continue: y or n");
                yesNo = Console.ReadLine();
            } while (yesNo =="y");
        }
    }
}
