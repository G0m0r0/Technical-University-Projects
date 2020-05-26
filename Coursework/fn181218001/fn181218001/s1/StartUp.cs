namespace s1
{
    using System;
    using Topshelf;

    class StartUp
    {
        static void Main(string[] args)
        {
            var exitCode = HostFactory.Run(x =>
            {
                x.Service<Engine>(s => {
                    s.ConstructUsing(Engine => new Engine());
                    s.WhenStarted(Engine => Engine.Start());
                    s.WhenStopped(Engine => Engine.Stop());
                });
           
           
                x.SetServiceName("ObserverService");
                x.SetDisplayName("Observer Servie");
                x.SetDescription("Observs txt file for commands -h,-g -s, -v, -e");
            });
           
            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            Environment.ExitCode = exitCodeValue;
        }
    }
}
