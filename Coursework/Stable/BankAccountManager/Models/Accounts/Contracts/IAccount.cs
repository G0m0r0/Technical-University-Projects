namespace BankAccountManager.Models.Accounts.Contracts
{
    using BankAccountManager.Models.Transactions.Contracts;
    using System.Collections.Generic;
    using System.Security;
    public interface IAccount : IAccountActions
    {
        public SecureString Iban { get; }
        decimal GetBalance { get; }
        IList<ITransaction> Transactions { get; }
    }
}
