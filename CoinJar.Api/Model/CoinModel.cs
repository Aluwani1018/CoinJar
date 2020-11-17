using CoinJar.Core.Interfaces;

namespace CoinJar.Api.Model
{
    public class CoinModel : ICoin
    {
        public decimal Amount { get; set; }
        public decimal Volume { get; set; }
    }
}
