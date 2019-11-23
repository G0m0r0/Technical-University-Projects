namespace BankAccountManager.Models
{
    using System;
    using System.Security;

    class CheckingAccount : Account
    {
        private const decimal arrangeFeeForOverdraft = 0.05m;
        public CheckingAccount(Person person, decimal balance, float interestRate, SecureString Iban)
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
            this.OverdraftLimist = overdraftLimit;
        }

        private bool activeOverdraft;
        private decimal overdraftLimit;

        private decimal OverdraftLimist
        {
            get { return overdraftLimit; }
            set
            {
                if (value < 0.0m)
                {
                    throw new Exception("Negative overdraft limit");
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

            this.OverdraftLimist = amountOverdraft;
            activeOverdraft = true;
        }
        public void DeactivateOverdraft()
        {
            if (!activeOverdraft)
            {
                throw new Exception("Your overdraft is not active!");
            }
            //TODO: charge for deactivating overdraft
            activeOverdraft = false;
        }

        public override void Withdraw(decimal amount)
        {
            if (activeOverdraft)
            {
                if (base.CheckPossitiveAmount(amount) && (this.Balance + overdraftLimit) >= amount)
                {
                    this.Balance -= amount;
                    //TODO: take money from saving account for overdraft
                    if (CheckPossitiveAmount(this.balance) )
                    {
                        this.Balance -= overdraftLimit * arrangeFeeForOverdraft;
                    }
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
            return base.ToString()+$" with {overdraftStatus}.";
        }

    }
}
