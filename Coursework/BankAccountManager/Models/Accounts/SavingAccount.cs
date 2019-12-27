namespace BankAccountManager.Models.Accounts
{
    using System;
    using System.Security;
    using BankAccountManager.Models.Person.Contracts;
    using Person;
    abstract class SavingAccount : Account
    {
        protected SavingAccount(IPerson person, decimal balance, float interestRate, SecureString Iban) 
            : base(person, balance, interestRate, Iban)
        {
        }
    }
}
