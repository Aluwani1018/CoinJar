using System.Collections.Generic;

namespace CoinJar.Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        void Add(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
