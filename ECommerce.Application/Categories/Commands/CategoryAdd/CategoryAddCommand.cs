using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Categories.Commands.CategoryAdd
{
    public class CategoryAddCommand : IRequest<CategoryAddDto>
    {
        public string CategoryName { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}
