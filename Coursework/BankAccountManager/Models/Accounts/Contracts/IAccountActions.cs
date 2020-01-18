namespace BankAccountManager.Models.Accounts.Contracts
{
    using BankAccountManager.Models.Transactions.Contracts;
    using System.Collections.Generic;
    public interface IAccountActions
    {
        void Deposit(decimal amount);
        void Withdraw(decimal amount);
        IList<ITransaction> Transactions { get; }
    }
}
