using Microsoft.AspNetCore.Mvc;
using MoneyExchangerApp.Services.Interfaces;
using System.Threading.Tasks;

namespace MoneyExchangerApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeController : ControllerBase
    {
        private readonly IExchangeService _exchangeService;

        public ExchangeController(IExchangeService exchangeService)
        {
            _exchangeService = exchangeService;
        }

        [HttpPost("{fromCurrency}/{fromAmount}/{toCurrency}")]
        public async Task<IActionResult> PostExchange(string fromCurrency, double fromAmount, string toCurrency)
        {
            var calculatedRate = await _exchangeService.CalculateExchangeAsync(fromCurrency, fromAmount, toCurrency);

            return Ok(calculatedRate);
        }
    }
}
