namespace BankManagerLib.Models.Accounts.Contracts
{
    public interface ICheckingAccount
    {
        void ActivateOverdraft(decimal amountOverdraft);
        void DeactivateOverdraft();
    }
}
