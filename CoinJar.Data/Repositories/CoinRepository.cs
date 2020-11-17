using CoinJar.Core.Domain;
using CoinJar.Core.Repositories;

namespace CoinJar.Data.Repositories
{
    public class CoinRepository : Repository<Coin>, ICoinRepository
    {
        public CoinRepository(ApplicationDbContext context)
            : base(context)
        {
        }
        public ApplicationDbContext LibraryContext
        {
            get { return _dBcontext as ApplicationDbContext; }
        }
    }
}
