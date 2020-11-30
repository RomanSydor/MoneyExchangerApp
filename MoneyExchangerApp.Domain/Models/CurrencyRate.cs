using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyExchangerApp.Domain.Models
{
    public class CurrencyRate
    {
        public string Base { get; set; }
        public DateTime Date { get; set; }
        public Dictionary<string, double> Rates { get; set; }
    }
}
