using System.Linq;
using CoinJar.Core.Uow;
using CoinJar.Core.Domain;
using CoinJar.Core.Interfaces;
using System.Collections.Generic;

namespace CoinJar.Service.Services.Implementation
{
    public class CoinService : ICoinService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoinService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public void AddCoin(ICoin coin)
        {
            this._unitOfWork.Coins.Add((Coin)coin);

            this._unitOfWork.Commit();
        }

        public decimal GetTotalAmount()
        {
            List<Coin> coinList = GetAllCoins();
            return coinList.Sum(x => x.Amount);
        }

        public void Reset()
        {
            _unitOfWork.Coins.RemoveRange(GetAllCoins());

            _unitOfWork.Commit();
        }

        private List<Coin> GetAllCoins()
        {
            return this._unitOfWork.Coins.GetAll().ToList();
        }
    }
}
