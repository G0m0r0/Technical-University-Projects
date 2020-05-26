namespace TEST_Services
{
    using System;
    using System.IO;
    using System.Timers;

    public class Engine
    {
         private readonly Timer timer;
        
         public Engine()
         {
             timer = new Timer(1000) { AutoReset = true };
             timer.Elapsed += TimerElapsed;
         }
        
        //it needs created folder firstly
         private void TimerElapsed(object sender, ElapsedEventArgs e)
         {
             string[] lines = new string[] { DateTime.Now.ToString() };
             File.AppendAllLines(@"D:\\timer.txt", lines);
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
