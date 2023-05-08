using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.AggregateModels.CategoryAggregate
{
    public class TreeView
    {
        public Category Parent { get; set; }
        public List<Category> Children { get; set;}

        public TreeView(Category parent, List<Category> children)
        {
            Parent = parent;
            Children = children;
        }
    }
}
