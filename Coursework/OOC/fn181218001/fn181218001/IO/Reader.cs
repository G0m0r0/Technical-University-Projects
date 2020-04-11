namespace fn181218001.IO
{
    using fn181218001.IO.Contracts;
    using System;
    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
