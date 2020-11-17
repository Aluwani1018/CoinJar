using CoinJar.Core.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoinJar.Core.Domain
{
    public class Coin : ICoin
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public decimal Volume { get; set; }
    }
}
