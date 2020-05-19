namespace d1.Core
{
    using System;

    public class Engin
    {
        private readonly Controller controller;

        public Engin()
        {
            this.controller = new Controller();
        }

        public void Run(string[] args)
        {
            //Console.WriteLine("Type -h for all commands:");
            // try
            // {
            //while (true)
            //{
            string result = string.Empty;

                   // if (args.Length == 0)
                  // {
                  //     args = Console.ReadLine().Split(" ");
                  //  }

                    switch (args[0])
                    {
                        case "-h":
                            result=this.controller.HelpCommand();
                            break;
                        case "-g":
                            result=this.controller.Gen()+"\n";
                            result+=this.controller.Save(args[1]);
                            break;
                        case "-v":
                            result=this.controller.Load(args[1]);
                            break;
                        case "-s":
                            result=this.controller.SortAndSaveToAnotherFile(args[1], args[2]);
                            break;
                        case "-e":
                            Environment.Exit(0);
                            break;
                        default:
                            result="Invalid command!";
                            break;
                    }

                    Console.WriteLine(result);
                   // args = Console.ReadLine().Split(" ");
            //  }
           // }
           // catch (Exception ex)
           // {
           //     Console.WriteLine(ex.Message);
           // }
        }
    }
}
