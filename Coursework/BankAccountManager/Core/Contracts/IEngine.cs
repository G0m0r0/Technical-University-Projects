using BankAccountManager.Models.Accounts.Contracts;
using BankAccountManager.Models.Person.Contracts;
using System.Collections.Generic;

namespace BankAccountManager.Core.Contracts
{
    public interface IEngine
    {
        void Run(string command);
        IReadOnlyCollection<IAccount> GetAllAccounts();
        IReadOnlyCollection<IUser> GetAllUsers();
    }
}
