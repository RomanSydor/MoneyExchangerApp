using MoneyExchangerApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoneyExchangerApp.Repositories.Interfaces
{
    public interface IExchangeRepository
    {
        void SaveEntityAsync(ExchangeEntity exchangeEntity);
        IQueryable<ExchangeEntity> GetExchangeEntitiesAsQuery();
    }
}
