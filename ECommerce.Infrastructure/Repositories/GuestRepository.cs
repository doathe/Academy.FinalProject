using ECommerce.Domain.AggregateModels.GuestAggregate;
using ECommerce.Domain.AggregateModels.UserModels;
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
    public class GuestRepository : GenericRepository<Guest>, IGuestRepository
    {
        public GuestRepository(ECommerceDbContext dbContext) : base(dbContext)
        {
        }
    }
}