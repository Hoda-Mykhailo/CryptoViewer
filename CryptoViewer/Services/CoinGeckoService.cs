using CryptoViewer.Models;
using CryptoViewer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CryptoViewer.Services
{
    class CoinGeckoService : ICryptoService
    {
        private readonly HttpClient _http;

        public CoinGeckoService()
        {
            _http = new HttpClient
            {
                BaseAddress = new Uri("https://api.coingecko.com/api/v3/")
            };

            _http.DefaultRequestHeaders.UserAgent.ParseAdd("CryptoViewerApp/1.0");
        }


        public async Task<List<CryptoCurrency>> GetTopAsync(int count)
        {
            var json = await _http.GetStringAsync(
                $"coins/markets?vs_currency=usd&order=market_cap_desc&per_page={count}");

            return JsonSerializer.Deserialize<List<CryptoCurrency>>(json);
        }

        public async Task<CryptoCurrency> GetDetailsAsync(string id)
        {
            var json = await _http.GetStringAsync(
                $"coins/markets?vs_currency=usd&ids={id}");

            return JsonSerializer.Deserialize<List<CryptoCurrency>>(json)[0];
        }

        public async Task<List<(DateTime, decimal)>> GetChartAsync(string id)
        {
            var json = await _http.GetStringAsync(
                $"coins/{id}/market_chart?vs_currency=usd&days=7");

            using var doc = JsonDocument.Parse(json);
            var prices = doc.RootElement.GetProperty("prices");

            return prices
                .EnumerateArray()
                .Select(p => (
                    DateTimeOffset.FromUnixTimeMilliseconds(p[0].GetInt64()).DateTime,
                    p[1].GetDecimal()))
                .ToList();
        }

        public async Task<decimal> ConvertAsync(string from, string to)
        {
            var json = await _http.GetStringAsync(
                $"simple/price?ids={from}&vs_currencies={to}");

            using var doc = JsonDocument.Parse(json);
            return doc.RootElement
                .GetProperty(from)
                .GetProperty(to)
                .GetDecimal();
        }
        public async Task<List<double>> GetMarketChartAsync(string coinId)
        {
            var url = $"https://api.coingecko.com/api/v3/coins/{coinId}/market_chart?vs_currency=usd&days=7";

            var json = await _http.GetStringAsync(url);
            using var doc = JsonDocument.Parse(json);

            return doc.RootElement
                .GetProperty("prices")
                .EnumerateArray()
                .Select(p => p[1].GetDouble())
                .ToList();
        }

    }
}
