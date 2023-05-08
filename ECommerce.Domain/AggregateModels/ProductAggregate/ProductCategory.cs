using ECommerce.Domain.AggregateModels.BasketAggregate;
using ECommerce.Domain.AggregateModels.CategoryAggregate;
using ECommerce.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.AggregateModels.ProductAggregate
{
    public class ProductCategory : BaseEntity
    {
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public ProductCategory(int categoryId, int productId)
        {
            CategoryId = categoryId;
            ProductId = productId;
        }
    }
}
