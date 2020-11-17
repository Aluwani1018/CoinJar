using System.Text.Json.Serialization;

namespace CoinJar.Api.Model.Response
{
    public class CoinResponse
    {
        [JsonPropertyName("totalAmount")]
        public decimal TotalAmount { get; set; }
    }
}
