namespace BankManagerLib.Models.Transactions.Contracts
{
    using BankManagerLib.Models.Enums;
    using System;
    public interface ITransaction
    {
        decimal Amount { get; }
        TypeTransaction TypeTransaction { get; }
        DateTime DateTime { get; }
    }
}
