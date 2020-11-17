using System.Linq;
using CoinJar.Core.Repositories;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoinJar.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _dBcontext;

        public Repository(DbContext context)
        {
            _dBcontext = context;
        }

        public void Add(T entity)
        {
            _dBcontext.Set<T>().Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _dBcontext.Set<T>().ToList();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dBcontext.Set<T>().RemoveRange(entities);
        }
    }
}
