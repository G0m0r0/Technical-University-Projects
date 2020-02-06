namespace BankAccountManager.Models.Transactions.Contracts
{
    using BankAccountManager.Models.Enums;
    using System;
    public interface ITransaction
    {
        decimal Amount { get; }
        TypeTransaction TypeTransaction { get; }
        DateTime DateTime { get; }
    }
}
