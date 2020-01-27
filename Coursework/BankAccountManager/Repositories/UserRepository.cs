namespace BankAccountManager.Repositories
{
    using BankAccountManager.Models.Person;
    using BankAccountManager.Models.Person.Contracts;
    using BankAccountManager.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Security;

    [Serializable()]
    public class UserRepository : IRepository<IUser>,ISerializable
    {
        public List<IUser> accounts { get; set; }
        public UserRepository()
        {
            this.accounts = new List<IUser>();
        }
        public UserRepository(SerializationInfo info,StreamingContext context)
        {
            this.accounts = (List<IUser>)info.GetValue("accounts", typeof(List<IUser>));
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
      // public ObjectToSerialize(SerializationInfo info,StreamingContext ctxt)
      // {
      //     this.accounts = (List<IUser>)info.GetValue("Accounts", typeof(List<IUser>));
      // }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Accounts", this.accounts);
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
