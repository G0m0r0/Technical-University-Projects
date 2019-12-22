using System.Security;

namespace BankAccountManager.Models.Accounts.Contracts
{
    public interface IAccount
    {
        public SecureString Iban { get; }
        void Deposit(decimal amount);
        void Withdraw(decimal amount);
        decimal GetBalance{get;}
    }
}
