namespace BankAccountManager.IO
{
    using BankAccountManager.IO.Contracts;
    public class Reader : IReader
    {
        public string ReadLine()
        {
            return System.Console.ReadLine();
        }
    }
}
