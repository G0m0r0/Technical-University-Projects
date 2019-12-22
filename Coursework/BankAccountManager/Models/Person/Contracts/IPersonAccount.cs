namespace BankAccountManager.Models.Person.Contracts
{
    using BankAccountManager.Models.Accounts.Contracts;
    using System.Collections.Generic;
    public interface IPersonAccount
    {
        ICollection<IAccount> Accounts { get; }

        void AddAccount(IAccount account);

        bool RemoveAccount(IAccount account);

        string GetFullName { get; }

        //ICollection<ICard> cards {get;}
    }
}
