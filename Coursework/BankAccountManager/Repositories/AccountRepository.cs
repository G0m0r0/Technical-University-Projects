namespace BankAccountManager.Repositories
{
    using BankAccountManager.Models.Accounts.Contracts;
    using BankAccountManager.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    public class AccountRepository : IRepository<IAccount>
    {
        public AccountRepository()
        {
            this.accounts = new List<IAccount>();
        }
        private readonly List<IAccount> accounts;
        public IReadOnlyCollection<IAccount> Models => this.accounts.AsReadOnly();

        public void Add(IAccount model)
        {
            if(model==null)
            {
                throw new ArgumentNullException("Account cannot be null!");
            }
            this.accounts.Add(model);
        }

        public IAccount FindByType(string type)
        {
            //TODO: find by type or find by name
            throw new NotImplementedException();
        }

        public bool Remove(IAccount model)
        {
            if(model==null)
            {
                throw new ArgumentNullException("Account cannot be null!");
            }

            return this.accounts.Remove(model);
        }
    }
}
