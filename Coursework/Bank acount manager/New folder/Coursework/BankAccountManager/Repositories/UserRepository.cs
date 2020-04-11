namespace BankAccountManager.Repositories
{
    using BankAccountManager.Models.Person.Contracts;
    using BankAccountManager.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security;
    public class UserRepository : IRepository<IUser>
    {
        private readonly List<IUser> accounts;
        public UserRepository()
        {
            this.accounts = new List<IUser>();
        }
        public IReadOnlyCollection<IUser> Models => this.accounts.AsReadOnly();

        public void Add(IUser model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("User cannot be null!");
            }

            var account = this.accounts.SingleOrDefault(acc=>acc.Username==model.Username);
            if(account!=null)
            {
                throw new ArgumentException("Username already exist");
            }

            this.accounts.Add(model);
        }

        public bool FindByIdentification(SecureString identification)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IUser model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("Account cannot be null!");
            }

            return this.accounts.Remove(model);
        }
    }
}
