namespace fn181218001
{
    using fn181218001.Core;
    using fn181218001.Core.Contracts;
    using fn181218001.IO;
    using fn181218001.IO.Contracts;
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {        
            IReader reader = new Reader();
            IWriter writer = new Writer(); 


            IEngine engine = new Engine(reader,writer);
            engine.Run(args);
        }
    }
}
