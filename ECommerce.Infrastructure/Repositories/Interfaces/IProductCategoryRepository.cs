using ECommerce.Domain.AggregateModels.ProductAggregate;
using ECommerce.Infrastructure.EFCore.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.EFCore.Repositories.Interfaces
{
    public interface IProductCategoryRepository : IGenericRepository<ProductCategory>
    {
    }
}