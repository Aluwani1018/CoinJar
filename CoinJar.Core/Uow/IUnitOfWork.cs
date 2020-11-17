using CoinJar.Core.Repositories;

namespace CoinJar.Core.Uow
{
    public interface IUnitOfWork
    {
        ICoinRepository Coins { get; }

        int Commit();
    }
}
