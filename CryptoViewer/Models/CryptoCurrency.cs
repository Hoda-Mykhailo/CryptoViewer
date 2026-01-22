using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CryptoViewer.Models
{
    class CryptoCurrency
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("current_price")]
        public decimal Price { get; set; }

        [JsonPropertyName("price_change_percentage_24h")]
        public decimal Change24h { get; set; }

        [JsonPropertyName("market_cap")]
        public decimal MarketCap { get; set; }

        [JsonPropertyName("image")]
        public string ImageUrl { get; set; }
    }
}
