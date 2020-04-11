namespace fn181218001.Core
{
    using fn181218001.Core.Contracts;
    using fn181218001.IO;
    using fn181218001.IO.Contracts;
    using System;
    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;
        private Controller controller;

        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();
            this.controller = new Controller(5,6);
        }

        public void Run()
        {
            while (true)
            {
                string[] input = reader.ReadLine().ToLower().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }

                try
                {
                string result = string.Empty;

               

                writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
