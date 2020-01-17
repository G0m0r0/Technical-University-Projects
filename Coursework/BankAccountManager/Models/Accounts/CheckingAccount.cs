namespace BankAccountManager.Models.Accounts
{
    using System;
    using System.Security;
    using BankAccountManager.Models.Enums;
    using BankAccountManager.Models.Person.Contracts;
    using BankAccountManager.Models.Transactions;
    using BankAccountManager.Models.Transactions.Contracts;
    using Person;

    class CheckingAccount : Account
    {
        private const decimal arrangeFeeForOverdraft = 0.05m;
        private const string separator = "___";
        private const decimal ChargesForDeactivatingOverdraft = 50;
        public CheckingAccount(IPerson person, decimal balance, float interestRate, SecureString Iban)
            : base(person, balance, interestRate, Iban)
        {
            //create account with deactivated overdraft
            activeOverdraft = false;
        }
        public CheckingAccount(Person person, decimal balance, float interestRate, SecureString IBAN,decimal overdraftLimit)
            : base(person, balance, interestRate, IBAN)
        {
            //create account with acctive overdraft
            activeOverdraft = true;
            this.OverdraftLimit = overdraftLimit;
        }

        private bool activeOverdraft;
        private decimal overdraftLimit;

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
            if(activeOverdraft)
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
                    //TODO: take money from saving account for overdraft
                    if (base.CheckPossitiveAmount(this.balance) )
                    {
                        this.Balance -= OverdraftLimit * arrangeFeeForOverdraft;
                    }
                }
            }
            else
            {
                base.Withdraw(amount);
            }

            AddToTransactionHistory(amount, "Withdraw");
        }

        public override string ToString()
        {
            string overdraftStatus = activeOverdraft ? "activated" : "deactivated";
            return "Checking"+separator+ base.ToString()+separator+$"overdraft {overdraftStatus}.";
        }

    }
}
