using Microsoft.EntityFrameworkCore;
using MoneyExchangerApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyExchangerApp.Domain.Contexts
{
    public class CurrencyExchangerDbContext : DbContext
    {
        public CurrencyExchangerDbContext(DbContextOptions<CurrencyExchangerDbContext> options)
           : base(options)
        {
        }

        public DbSet<ExchangeEntity> ExchangeEntities { get; set; }
    }
}
