using ECommerce.Domain.AggregateModels.BasketAggregate;
using ECommerce.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.AggregateModels.ProductAggregate
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; }  // Stok
        public bool Status { get; set; }

        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
        public virtual ICollection<BasketItem> Items { get; set; }

        public Product()
        {
            Status = true;
        }
    }
}