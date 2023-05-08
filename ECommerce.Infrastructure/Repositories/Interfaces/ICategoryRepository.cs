using ECommerce.Domain.AggregateModels.CategoryAggregate;
using ECommerce.Domain.AggregateModels.UserModels;
using ECommerce.Infrastructure.EFCore.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.EFCore.Repository.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        public Task<IEnumerable<TreeView>> GetTree();
    }
}