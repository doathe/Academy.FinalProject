using ECommerce.Domain.AggregateModels.BasketAggregate;
using ECommerce.Domain.AggregateModels.UserModels;
using ECommerce.Infrastructure.EFCore.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.EFCore.Repository.Interfaces
{
    public interface IBasketItemRepository : IGenericRepository<BasketItem>
    {
    }
}