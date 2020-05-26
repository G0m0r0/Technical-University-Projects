namespace s1
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Timers;
    class Engine
    {
        private readonly Timer timer;

        public Engine()
        {
            timer = new Timer(3000) { AutoReset = true };
            timer.Elapsed += TimerElapsed;
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            string path = @"D:\Programming\University\Coursework\fn181218001\command.txt";
            string[] command = File.ReadAllText(path).Split();

            if (command[0] != string.Empty)
            {
                d1.Core.Engine engine = new d1.Core.Engine();
                engine.Run(command);
            }       

           //proc.StandardInput.WriteLine($"{path2} {command}");

            File.WriteAllText(path, String.Empty);
        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }

    }
}
