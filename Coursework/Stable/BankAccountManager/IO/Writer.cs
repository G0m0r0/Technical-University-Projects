namespace BankAccountManager.IO
{
    using BankAccountManager.IO.Contracts;
    public class Writer : IWriter
    {
        public void Write(string message)
        {
            System.Console.Write(message);
        }

        public void WriteLine(string message)
        {
            System.Console.WriteLine(message);
        }
    }
}
