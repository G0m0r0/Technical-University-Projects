namespace BankAccountManager.Models.Accounts
{
    using System.Security;
    using BankAccountManager.Models.Person.Contracts;
    using Person;
    class ChildSavingsAccount : SavingAccount
    {
        private const decimal minimumBalanceForChild = 500;
        public ChildSavingsAccount(IPerson person, decimal balance, float interestRate, SecureString Iban) 
            : base(person, balance, interestRate, Iban)
        {
        }
    }
}
