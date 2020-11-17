using CoinJar.Core.Interfaces;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace CoinJar.Api.Model
{
    public class CoinModel : ICoin
    {
        [Required]
        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }
        
        [Required]
        [JsonPropertyName("volume")]
        public decimal Volume { get; set; }
    }
}
