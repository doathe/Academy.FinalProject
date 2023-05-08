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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ECommerceDbContext dbContext;
        public UserRepository(ECommerceDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await dbContext.Set<User>().FirstOrDefaultAsync(x => x.Email == email);
        }
        public async Task<bool> EmailExistCheckAsync(string email)
        {
            var model = await dbContext.Set<User>().FirstOrDefaultAsync(x => x.Email == email);
            if (model == null)
            {
                return false;
            }
            return true;
        }
    }
}