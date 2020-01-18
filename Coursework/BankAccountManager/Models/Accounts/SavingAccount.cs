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

        public override decimal Balance
        {
            get => base.Balance;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Balance can not be less than overdraft limit!");
                }
                base.Balance = value;
            }
        }
    }
}
