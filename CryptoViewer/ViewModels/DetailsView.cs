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
    public partial class DetailsViewModel : ObservableObject
    {
        private readonly ICryptoService _service;

        [ObservableProperty]
        private CryptoCurrency currency;

        [ObservableProperty]
        private ObservableCollection<double> prices = new();

        [ObservableProperty]
        private bool isLoading;

        public DetailsViewModel(CryptoCurrency currency)
        {
            _service = new CoinGeckoService();
            Currency = currency;
            _ = LoadChartAsync();
            
            //LoadChart();
        }

        private async Task LoadChartAsync()
        {
            try
            {
                isLoading = true;

                var data = await _service.GetMarketChartAsync(Currency.Id);
                Prices = new ObservableCollection<double>(data);
            }
            finally
            {
                isLoading = false;
            }
        }

        //private async void LoadChart()
        //{
        //    var data = await _service.GetMarketChartAsync(currency.Id);
        //    Prices = new ObservableCollection<double>(data);
        //}
    }
}
