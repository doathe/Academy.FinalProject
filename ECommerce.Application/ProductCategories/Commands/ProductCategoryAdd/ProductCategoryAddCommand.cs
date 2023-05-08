using ECommerce.Domain.AggregateModels.CategoryAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.ProductCategories.Commands.ProductCategoryAdd
{
    public class ProductCategoryAddCommand : IRequest<ProductCategoryAddDto>
    {
        public int CategoryId { get; set; }
        public int ProductId { get; set; }
    }
}
