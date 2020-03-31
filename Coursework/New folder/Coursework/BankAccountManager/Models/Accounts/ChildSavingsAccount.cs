namespace BankAccountManager.Models.Accounts
{
    using System;
    using System.Security;
    using BankAccountManager.Models.Person.Contracts;
    class ChildSavingsAccount : SavingAccount
    {
        //private const decimal minimumBalanceForChild = 500;
        private const float maxInterestRate = 5.0F;
        private const string separator = "___";
        public ChildSavingsAccount(IPerson person, decimal balance, float interestRate, SecureString Iban)
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
            return "ChildSavings" + separator + base.ToString() + '.';
        }
    }
}
