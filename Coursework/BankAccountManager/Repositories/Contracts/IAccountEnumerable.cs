namespace BankAccountManager.Repositories.Contracts
{
    using BankAccountManager.Models.Accounts.Contracts;
    using System.Collections.Generic;
    public interface IAccountEnumerable
    {
        IEnumerator<IAccount> GetEnumerator();
    }
}
