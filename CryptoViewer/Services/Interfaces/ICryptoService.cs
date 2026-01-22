using CryptoViewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoViewer.Services.Interfaces
{
    interface ICryptoService
    {
        Task<List<CryptoCurrency>> GetTopAsync(int count);
        Task<CryptoCurrency> GetDetailsAsync(string id);
        Task<List<(DateTime, decimal)>> GetChartAsync(string id);
        Task<decimal> ConvertAsync(string from, string to);
    }
}
