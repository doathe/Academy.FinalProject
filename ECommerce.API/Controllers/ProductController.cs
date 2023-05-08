using ECommerce.Application.Categories.Commands.CategoryAdd;
using ECommerce.Application.Categories.Queries.CategoriesGetAll;
using ECommerce.Application.ProductCategories.Commands.ProductCategoryAdd;
using ECommerce.Application.Products.Commands.ProductAdd;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> ProductAdd(ProductAddCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpPost]
        [Route("productCategory/add")]
        public async Task<IActionResult> ProductCategoryAdd(ProductCategoryAddCommand command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}
