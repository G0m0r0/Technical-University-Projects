namespace fn181218001
{
    using fn181218001.Core;
    using fn181218001.Core.Contracts;
    class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
