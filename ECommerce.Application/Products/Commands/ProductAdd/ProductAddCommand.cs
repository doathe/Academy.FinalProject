using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Products.Commands.ProductAdd
{
    public class ProductAddCommand : IRequest<ProductAddDto>
    {
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public int ProductInventory { get; set; }
    }
}
