using ECommerce.Domain.AggregateModels.BasketAggregate;
using ECommerce.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.AggregateModels.GuestAggregate
{
    public class Guest : BaseEntity
    {
        public virtual ICollection<Basket> Baskets { get; set; }
    }
}
