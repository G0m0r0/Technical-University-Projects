namespace TEST_Services
{
    using System;
    using Topshelf;
    class StartUp
    {
        static void Main(string[] args)
        {
            //use topshelf library
            var exitCode = HostFactory.Run(x =>
            {
                x.Service<Engine>(s => {
                    s.ConstructUsing(Engine => new Engine());
                    s.WhenStarted(Engine => Engine.Start());
                    s.WhenStarted(Engine => Engine.Stop());
                });
           
                x.RunAsLocalSystem();
           
                x.SetServiceName("ObserverService");
                x.SetDisplayName("Observer Servie");
                x.SetDescription("Observs txt file for changes");
            });
           
            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            Environment.ExitCode = exitCodeValue;
        }
    }
}
