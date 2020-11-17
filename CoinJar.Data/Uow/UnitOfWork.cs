using System;
using CoinJar.Core.Uow;
using System.Threading.Tasks;
using CoinJar.Data.Repositories;
using CoinJar.Core.Repositories;

namespace CoinJar.Data.Uow
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ApplicationDbContext _dbContext = null;
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext as ApplicationDbContext;

        }

        #region Properties
        public ICoinRepository Coins
        {
            get
            {
                return new CoinRepository(_dbContext);
            }
        }

        #endregion

        #region Method(s)
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                }
            }
        }
        public int Commit()
        {
            return _dbContext.SaveChanges();
        }
        #endregion
    }
}
