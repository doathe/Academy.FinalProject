using ECommerce.Domain.AggregateModels.ProductAggregate;
using ECommerce.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.AggregateModels.BasketAggregate
{
    public class BasketItem : BaseEntity
    {
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }

        public int BasketId { get; set; }
        public virtual Basket Basket { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
