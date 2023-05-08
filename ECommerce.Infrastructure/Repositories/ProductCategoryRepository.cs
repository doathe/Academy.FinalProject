using ECommerce.Domain.AggregateModels.ProductAggregate;
using ECommerce.Domain.AggregateModels.UserModels;
using ECommerce.Infrastructure.EFCore.Context;
using ECommerce.Infrastructure.EFCore.Repositories.Interfaces;
using ECommerce.Infrastructure.EFCore.Repository.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.EFCore.Repositories
{
    public class ProductCategoryRepository : GenericRepository<ProductCategory>, IProductCategoryRepository
    {
        private readonly ECommerceDbContext dbContext;
        public ProductCategoryRepository(ECommerceDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Index()
        {
            dbContext.Set<ProductCategory>().Include(x => x.Product).Include(x => x.Category);
        }
        public async Task<ProductCategory> GetByIdAsync(int id)
        {
            Index();
            return await dbContext.Set<ProductCategory>().FindAsync(id);
        }
        public async Task<IEnumerable<ProductCategory>> GetAllAsync()
        {
            Index();
            return await dbContext.Set<ProductCategory>().ToListAsync();
        }

        public async Task AddAsync(ProductCategory entity)
        {
            //Index();
            await dbContext.Set<ProductCategory>().AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductCategory>> GetByCategoryAsync(string categoryName)
        {
            Index();
            return dbContext.Set<ProductCategory>().Where(x => x.Category.Name == categoryName).ToList();
        }

    }
}
