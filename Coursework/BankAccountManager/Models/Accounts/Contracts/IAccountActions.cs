namespace BankAccountManager.Models.Accounts.Contracts
{
    public interface IAccountActions
    {
        void Deposit(decimal amount);
        void Withdraw(decimal amount);
        void AddInterest();
    }
}
