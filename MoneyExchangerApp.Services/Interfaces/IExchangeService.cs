using System.Threading.Tasks;

namespace MoneyExchangerApp.Services.Interfaces
{
    public interface IExchangeService
    {
        Task<double> CalculateExchangeAsync(string fromCurrency, double fromAmount, string toCurrency);
    }
}
