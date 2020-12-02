﻿using MoneyExchangerApp.Domain.Contexts;
using MoneyExchangerApp.Domain.Entities;
using MoneyExchangerApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoneyExchangerApp.Repositories.Repositories
{
    public class ExchangeRepository : IExchangeRepository
    {
        private CurrencyExchangerDbContext _db;
        public ExchangeRepository(CurrencyExchangerDbContext dataContext)
        {
            _db = dataContext;
        }

        public void SaveEntity(ExchangeEntity exchangeEntity)
        {
            _db.ExchangeEntities.Add(exchangeEntity);
            _db.SaveChanges();
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
