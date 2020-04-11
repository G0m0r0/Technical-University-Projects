namespace BankManagerLib.Repositories.Contracts
{
    using System.Collections.Generic;
    using System.Security;

    public interface IRepository<T>
    {
        IReadOnlyCollection<T> Models { get; }

        void Add(T model);

        bool Remove(T model);

        bool FindByIdentification(SecureString identification);

    }
}
