namespace BankAccountManagerConsole
{
    using BankAccountManager.Core;
    using System;
    class StartUp
    {
        static void Main()
        {
            Engine engin = new Engine();

            string input = Console.ReadLine().ToLower();
            while (input!="exist")
            {
                engin.Run(input);
                input = Console.ReadLine();
            }            
        }
    }
}
