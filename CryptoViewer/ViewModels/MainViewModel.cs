using CommunityToolkit.Mvvm.ComponentModel;
using CryptoViewer.Models;
using CryptoViewer.Services;
using CryptoViewer.Services.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CryptoViewer.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly ICryptoService _service;

        private List<CryptoCurrency> _allCurrencies = new();

        [ObservableProperty]
        private ObservableCollection<CryptoCurrency> currencies = new();

        [ObservableProperty]
        private CryptoCurrency? selectedCurrency;

        private string search;
        public string Search
        {
            get => search;
            set
            {
                SetProperty(ref search, value);
                ApplyFilter();
            }
        }

        public MainViewModel()
        {
            _service = new CoinGeckoService();
            Load();
        }

        private async void Load()
        {
            var data = await _service.GetTopAsync(20);
            _allCurrencies = data.ToList();
            Currencies = new ObservableCollection<CryptoCurrency>(_allCurrencies);
        }

        private void ApplyFilter()
        {
            if (string.IsNullOrWhiteSpace(Search))
            {
                Currencies = new ObservableCollection<CryptoCurrency>(_allCurrencies);
                return;
            }

            var filtered = _allCurrencies
                .Where(c =>
                    c.Name.Contains(Search, System.StringComparison.OrdinalIgnoreCase) ||
                    c.Symbol.Contains(Search, System.StringComparison.OrdinalIgnoreCase))
                .ToList();

            Currencies = new ObservableCollection<CryptoCurrency>(filtered);
        }
    }
}
