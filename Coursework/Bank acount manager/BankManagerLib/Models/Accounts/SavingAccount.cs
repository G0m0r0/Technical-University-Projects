namespace BankManagerLib.Models.Accounts
{
    using BankManagerLib.Models.Person.Contracts;
    using System;
    using System.Security;
    abstract class SavingAccount : Account
    {
        private const float maxInterestRate = 4.0F;
        protected SavingAccount(IPerson person, decimal balance, float interestRate, SecureString Iban) 
            : base(person, balance, interestRate, Iban)
        {
        }

        public override float InterestRate
        {
            get { return base.InterestRate; }
            protected set
            {
                if (value < 0.0F || value > maxInterestRate)
                {
                    throw new ArgumentException($"Interest rate should be between 0 and {maxInterestRate}%");
                }
                base.InterestRate = value;
            }
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
