namespace BankManagerLib.Models.Accounts.Contracts
{
    using BankManagerLib.Models.Transactions.Contracts;
    using System.Collections.Generic;
    using System.Security;
    public interface IAccount : IAccountActions
    {
        SecureString Iban { get; }
        decimal GetBalance { get; }
        IList<ITransaction> Transactions { get; }
    }
}
