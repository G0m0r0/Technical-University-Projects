namespace BankAccountManager.Models.Accounts
{
    using System.Security;
    using BankAccountManager.Models.Person.Contracts;
    using Person;
    class RetirmentAccount : SavingAccount
    {
        private const decimal minimumBalanceForRetirment = 2000;
        public RetirmentAccount(IPerson person, decimal balance, float interestRate, SecureString Iban) 
            : base(person, balance, interestRate, Iban)
        {
        }
    }
}
