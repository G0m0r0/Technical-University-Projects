namespace BankAccountManager.Models.Transactions
{
    using BankAccountManager.Models.Enums;
    using BankAccountManager.Models.Transactions.Contracts;
    using System;
    public class TransactionCurrent : ITransaction
    {
        public TransactionCurrent(decimal amount, TypeTransaction typeTransaction)
        {
            this.Amount = amount;
            this.TypeTransaction = typeTransaction;
            this.DateTime = DateTime.Now;
        }

        private decimal amount;
        public TypeTransaction TypeTransaction { get; private set; }
        public DateTime DateTime { get; private set; }

        public decimal Amount
        {
            get { return amount; }
            private set
            {
                if (amount < 0)
                {
                    throw new ArgumentException("Amount can not be negative!");
                }
                this.amount = value;
            }
        }

        public override string ToString()
        {
            return $" {this.DateTime} {this.TypeTransaction} {this.Amount}";
        }
    }
}
