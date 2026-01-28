using CommunityToolkit.Mvvm.ComponentModel;
using CryptoViewer.Models;
using CryptoViewer.Services;
using CryptoViewer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoViewer.ViewModels
{
    public partial class DetailsView : ObservableObject
    {
        private readonly ICryptoService _service;

        [ObservableProperty]
        private CryptoCurrency currency;

        [ObservableProperty]
        private ObservableCollection<double> prices = new();

        public DetailsView(CryptoCurrency currency)
        {
            _service = new CoinGeckoService();
            Currency = currency;
            LoadChart();
        }

        private async void LoadChart()
        {
            var data = await _service.GetMarketChartAsync(currency.Id);
            Prices = new ObservableCollection<double>(data);
        }
    }
}
