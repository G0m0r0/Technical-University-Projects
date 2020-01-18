namespace BankAccountManager.Core.Contracts
{
    using BankAccountManager.Models.Accounts.Contracts;
    using System.Collections.Generic;
    using System.Security;
    public interface IController
    {
        IReadOnlyCollection<IAccount> TakeAllAccounts();
        string AddAccount(string accountType,SecureString personId,decimal balance,float interestRate, SecureString Iban);

        string AddPerson(string firstName,string lastName,int age,SecureString ID);

        string Deposit(decimal amount, SecureString iban);

        string Withdraw(decimal amount, SecureString iban);

        string DeactivateOverdraft(SecureString iban);

        string ActivateOverdraft(SecureString iban, decimal amount);

        string CalculateAllMoney();

        string Report(SecureString id);
    }
}
