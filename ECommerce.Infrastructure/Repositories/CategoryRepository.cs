using ECommerce.Domain.AggregateModels.CategoryAggregate;
using ECommerce.Domain.AggregateModels.UserModels;
using ECommerce.Infrastructure.EFCore.Context;
using ECommerce.Infrastructure.EFCore.Repository.Common;
using ECommerce.Infrastructure.EFCore.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.EFCore.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly ECommerceDbContext dbContext;
        public CategoryRepository(ECommerceDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<TreeView>> GetTree()
        {
            List<Category> mainCategories = dbContext.Set<Category>().Where(x => x.ParentCategoryId == 0).ToList();
            List<Category> subCategories = dbContext.Set<Category>().Where(x => x.ParentCategoryId != 0).ToList();


            List<TreeView> categoryTree = new List<TreeView>();
            foreach(var mainCat in mainCategories)
            {
                var children = subCategories.Where(x => x.ParentCategoryId == mainCat.Id).ToList();
                var model = new TreeView(mainCat, children);
                categoryTree.Add(model);
            }

            return categoryTree;
        }
    }
}