using ECommerce.Domain.AggregateModels.ProductAggregate;
using ECommerce.Domain.AggregateModels.UserModels;
using ECommerce.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.AggregateModels.CategoryAggregate
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
       
        public int? ParentCategoryId { get; set; }

        //public virtual Category ParentCategory { get; set; }
        //public virtual ICollection<Category> SubCategories { get; set; }

        public virtual ICollection<ProductCategory> ProductCategories { get; set; }

        public Category(string name, int? parentCategoryId)
        {
            Name = name;
            ParentCategoryId = parentCategoryId;
        }
    }
}
