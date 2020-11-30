using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyExchangerApp.Domain.Entities
{
    public class ExchangeEntity
    {
        public int Id { get; set; }
        public string FromCurrency { get; set; }
        public double FromAmount { get; set; }
        public string ToCurrency { get; set; }
        public double ToAmount { get; set; }
        public DateTime Date { get; set; }

        public ExchangeEntity(string FromCurrency, double FromAmount, string ToCurrency, double ToAmount, DateTime Date)
        {
            this.FromCurrency = FromCurrency;
            this.FromAmount = FromAmount;
            this.ToCurrency = ToCurrency;
            this.ToAmount = ToAmount;
            this.Date = Date;
        }
    }
}
