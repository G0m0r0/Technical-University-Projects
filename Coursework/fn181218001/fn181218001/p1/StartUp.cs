namespace p1
{
    class StartUp
    {
        static void Main(string[] args)
        {
            // d2.Engine engine = new d2.Engine();
            d1.Core.Engine engine = new d1.Core.Engine();
            engine.Run(args);
        }        
    }
}
