namespace BankAccountManager.Models.Accounts.Contracts
{
    using System.Security;
    public interface IAccount : IAccountActions
    {
        public SecureString Iban { get; }
        decimal GetBalance { get; }
    }
}
