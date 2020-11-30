using MoneyExchangerApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoneyExchangerApp.Services.Interfaces
{
    public interface ICurrencyRateService
    {
        Task<CurrencyRate> GetCurrencyRatesAsync();
    }
}
