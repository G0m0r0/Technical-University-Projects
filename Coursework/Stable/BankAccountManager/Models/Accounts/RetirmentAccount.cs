namespace BankAccountManager.Models.Accounts
{
    using System;
    using System.Security;
    using BankAccountManager.Models.Person.Contracts;
    class RetirmentAccount : SavingAccount
    {
        private const decimal minimumBalanceForRetirment = 2000;
        private const float maxInterestRate = 4.0F;
        private const string separator = "___";
        public RetirmentAccount(IPerson person, decimal balance, float interestRate, SecureString Iban) 
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

        public override string ToString()
        {
            return "Retirment" + separator + base.ToString()+'.';
        }
    }
}
