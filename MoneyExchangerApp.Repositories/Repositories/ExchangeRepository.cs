using MoneyExchangerApp.Domain.Contexts;
using MoneyExchangerApp.Domain.Entities;
using MoneyExchangerApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyExchangerApp.Repositories.Repositories
{
    public class ExchangeRepository : IExchangeRepository
    {
        private CurrencyExchangerDbContext _db;
        public ExchangeRepository(CurrencyExchangerDbContext dataContext)
        {
            _db = dataContext;
        }

        public async void SaveEntityAsync(ExchangeEntity exchangeEntity)
        {
            await Task.Run(() => _db.ExchangeEntities.Add(exchangeEntity));
            await Task.Run(() => _db.SaveChangesAsync());
        }

        public IQueryable<ExchangeEntity> GetExchangeEntitiesAsQuery() 
        {
            var query = _db.ExchangeEntities
                                .OrderByDescending(x => x.Date)
                                .AsQueryable();
            return query;
        }
    }
}
