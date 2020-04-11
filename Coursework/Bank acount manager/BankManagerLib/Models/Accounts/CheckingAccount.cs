namespace BankManagerLib.Models.Accounts
{
    using System;
    using System.Security;
    using BankManagerLib.Models.Accounts.Contracts;
    using BankManagerLib.Models.Person.Contracts;
    using Person;

    class CheckingAccount : Account, ICheckingAccount
    {
        private const decimal arrangeFeeForOverdraft = 0.05m;
        private const float maxInterestRate = 3.0F;
        private const string separator = "___";
        private const decimal ChargesForDeactivatingOverdraft = 50;
        public CheckingAccount(IPerson person, decimal balance, float interestRate, SecureString Iban)
            : base(person, balance, interestRate, Iban)
        {
            //create account with deactivated overdraft
            activeOverdraft = false;
        }
        public CheckingAccount(Person person, decimal balance, float interestRate, SecureString IBAN, decimal overdraftLimit)
            : base(person, balance, interestRate, IBAN)
        {
            //create account with acctive overdraft
            activeOverdraft = true;
            this.OverdraftLimit = overdraftLimit;
        }

        private bool activeOverdraft;
        private decimal overdraftLimit;

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
                if(value<-overdraftLimit)
                {
                    throw new ArgumentException("Balance can not be less than overdraft limit!");
                }
                base.Balance = value;
            }
        }

        private decimal OverdraftLimit
        {
            get { return overdraftLimit; }
            set
            {
                if (value < 0.0m)
                {
                    throw new ArgumentOutOfRangeException("Negative overdraft limit");
                }
                overdraftLimit = value;
            }
        }

        public void ActivateOverdraft(decimal amountOverdraft)
        {
            if (activeOverdraft)
            {
                throw new Exception("Your overdraft is active!");
            }

            this.OverdraftLimit = amountOverdraft;

            activeOverdraft = true;
        }
        public void DeactivateOverdraft()
        {
            if (!activeOverdraft)
            {
                throw new Exception("Your overdraft is not active!");
            }

            this.Balance -= ChargesForDeactivatingOverdraft;

            activeOverdraft = false;
        }

        public override void Withdraw(decimal amount)
        {
            if (activeOverdraft)
            {
                if (base.CheckPossitiveAmount(amount) && (this.Balance + OverdraftLimit) >= amount)
                {
                    this.Balance -= amount;
                    this.Balance -= OverdraftLimit * arrangeFeeForOverdraft;

                    AddToTransactionHistory(amount, "Withdraw");
                }
            }
            else
            {
                base.Withdraw(amount);
            }
        }

        public override string ToString()
        {
            string overdraftStatus = activeOverdraft ? "activated" : "deactivated";
            return "Checking" + separator + base.ToString() + separator + $"overdraft {overdraftStatus}.";
        }

    }
}
