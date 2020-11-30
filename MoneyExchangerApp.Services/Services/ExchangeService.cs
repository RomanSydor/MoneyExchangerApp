using MoneyExchangerApp.Domain.Entities;
using MoneyExchangerApp.Domain.Models;
using MoneyExchangerApp.Repositories.Interfaces;
using MoneyExchangerApp.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MoneyExchangerApp.Services.Services
{
    public class ExchangeService : IExchangeService
    {
        private readonly IExchangeRepository _exchangeRepository;
        public ExchangeService(IExchangeRepository exchangeRepository)
        {
            _exchangeRepository = exchangeRepository;
        }

        public async Task<double> CalculateExchangeAsync(string fromCurrency, double fromAmount, string toCurrency)
        {
            var rate = await GetCurrencyRatesAsync(fromCurrency);
            var exchangeResult = Math.Round(fromAmount * rate.Rates[toCurrency], 2);

            var exchangeEntity = BuildExchange(fromCurrency, fromAmount, toCurrency, exchangeResult);
            _exchangeRepository.SaveEntity(exchangeEntity);

            return exchangeResult;
        }

        private ExchangeEntity BuildExchange(string fromCurrency, double fromAmount, string toCurrency, double toAmount)
        {
            var exchange = new ExchangeEntity(fromCurrency, fromAmount, toCurrency, toAmount, DateTime.Now);
            return exchange;
        }

        private async Task<CurrencyRate> GetCurrencyRatesAsync(string baseCurrency)
        {
            UriBuilder uriBuilder = new UriBuilder();
            uriBuilder.Scheme = "https";
            uriBuilder.Host = "api.exchangeratesapi.io";
            var path = "/latest";
            uriBuilder.Path = path;
            var query = $"?base={baseCurrency}";
            uriBuilder.Query = query;
            using (HttpClient client = new HttpClient())
            {
                var uri = uriBuilder.ToString();
                HttpResponseMessage response = await client.GetAsync(uri);
                response.EnsureSuccessStatusCode();
                var responseString = await response.Content.ReadAsStringAsync();
                var currencyRates = JsonConvert.DeserializeObject<CurrencyRate>(responseString);
                return currencyRates;
            }
        }
    }
}
