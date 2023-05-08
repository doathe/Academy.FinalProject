using ECommerce.Domain.AggregateModels.BasketAggregate;
using ECommerce.Domain.AggregateModels.CategoryAggregate;
using ECommerce.Infrastructure.EFCore.Context;
using ECommerce.Infrastructure.EFCore.Repository.Common;
using ECommerce.Infrastructure.EFCore.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.EFCore.Repository
{
    public class BasketRepository : GenericRepository<Basket>, IBasketRepository
    {
        public BasketRepository(ECommerceDbContext dbContext) : base(dbContext)
        {
        }
    }
}