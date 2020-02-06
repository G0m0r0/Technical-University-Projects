namespace BankManagerLib.Core.Contracts
{
    using BankManagerLib.Models.Accounts.Contracts;
    using BankManagerLib.Models.Person.Contracts;
    using System.Collections.Generic;
    public interface IEngine
    {
        void Run(string command);
        IReadOnlyCollection<IAccount> GetAllAccounts();
        IReadOnlyCollection<IUser> GetAllUsers();
    }
}
