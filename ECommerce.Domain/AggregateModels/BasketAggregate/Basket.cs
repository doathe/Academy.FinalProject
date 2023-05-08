using ECommerce.Domain.AggregateModels.CategoryAggregate;
using ECommerce.Domain.AggregateModels.GuestAggregate;
using ECommerce.Domain.AggregateModels.ProductAggregate;
using ECommerce.Domain.AggregateModels.UserModels;
using ECommerce.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.AggregateModels.BasketAggregate
{
    public class Basket : BaseEntity
    {
        public bool Status { get; set; }
        public int TotalPrice { get; set; }

        public int? UserId { get; set; }
        public virtual User User { get; set; }
        public int? GuestId { get; set; }
        public virtual Guest Guest { get; set; }
        public virtual ICollection<BasketItem> Items { get; set; }
    }
}
