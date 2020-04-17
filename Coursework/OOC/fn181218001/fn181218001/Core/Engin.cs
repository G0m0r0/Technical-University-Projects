namespace fn181218001.Core
{
    using fn181218001.Core.Contracts;
    using fn181218001.IO.Contracts;
    using fn181218001.Utilities;
    using System;
    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;
        private IController controller;

        public Engine(IReader reader, IWriter writer)
        {
            this.writer = writer;
            this.reader = reader;
            this.controller = new Controller();
        }

        public void Run(string[] input)
        {
            this.writer.WriteLine(String.Format(OutputMessages.help));
            this.writer.WriteLine(String.Format(OutputMessages.exampleOptions));
            this.writer.WriteLine(input[0]);
            this.writer.WriteLine(input[1]);

            while (true)
            {
                if (input[0] == "")
                {
                    input = reader.ReadLine().ToLower().Split();
                }                

                if (input[0] == "--help")
                {
                    this.writer.WriteLine(String.Format(OutputMessages.commands));
                }

                if (input[0] == "exit")
                {
                    Environment.Exit(0);
                }

                try
                {
                string result = string.Empty;
                    int start = 0;
                    int end = 0;

                    if (input[0] == "generatesequence") {
                        start = int.Parse(input[1]);
                        end = int.Parse(input[2]);
                        int length = int.Parse(input[3]);

                        result = controller.GenerateSubSequenceAndAddToSequence(length, start, end);
                    }
                    else if(input[0]== "generatenumber")
                    {
                        start = int.Parse(input[1]);
                        end = int.Parse(input[2]);

                        result = controller.GenerateNumberAndAddToSequence(start, end);
                    }else if (input[0] == "print")
                    {
                        result = controller.Print();
                    }else if (input[0] == "sort")
                    {
                        result = controller.Sort();
                    }else if (input[0] == "saveoutputinfile")
                    {
                        controller.SaveOutputInFile();
                    }else if (input[0] == "save")
                    {
                        result = controller.Save();
                    }else if (input[0] == "load")
                    {
                        result=controller.Load();
                    }else if (input[0] == "clear")
                    {
                        result=controller.Clear();
                    }
                    else
                    {
                        result = "Ivanlid command!";
                    }
               

                this.writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
