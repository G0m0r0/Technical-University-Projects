namespace BankAccountManager.Core.Contracts
{
    using BankAccountManager.Models.Accounts.Contracts;
    using BankAccountManager.Models.Person.Contracts;
    using BankAccountManager.Repositories.Contracts;
    using System.Security;
    public interface IController
    {
        IPerson Person { get; }
        IRepository<IAccount> Account { get; }
        string AddAccount(string accountType,SecureString personId,decimal balance,float interestRate, SecureString Iban);

        string AddPerson(string firstName,string lastName,int age,SecureString ID);

        string Deposit(SecureString id, decimal amount, SecureString iban);

        string Withdraw(SecureString id, decimal amount, SecureString iban);

        //void AddInterests();

        //void AddCard();

        string CalculateAllMoney(SecureString id);

        string Report(SecureString id);
    }
}
