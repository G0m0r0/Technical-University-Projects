namespace BankManagerLib.Repositories.Contracts
{
    using BankManagerLib.Models.Accounts.Contracts;
    using System.Collections.Generic;
    public interface IAccountEnumerable
    {
        IEnumerator<IAccount> GetEnumerator();
    }
}
