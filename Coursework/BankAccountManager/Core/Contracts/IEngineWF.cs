using BankAccountManager.Models.Accounts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccountManager.Core.Contracts
{
    public interface IEngineWF
    {
        void Run(string input);
        IReadOnlyCollection<IAccount> GetAllAccounts();
    }
}
