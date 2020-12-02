using MoneyExchangerApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoneyExchangerApp.Repositories.Interfaces
{
    public interface IExchangeRepository
    {
        void SaveEntity(ExchangeEntity exchangeEntity);
        IQueryable<ExchangeEntity> GetExchangeEntitiesAsQuery();
    }
}
