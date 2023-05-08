using ECommerce.Application.Categories.Commands.CategoryAdd;
using ECommerce.Application.Categories.Queries.CategoriesGetAll;
using ECommerce.Application.Users.Commands.UserRegistration;
using ECommerce.Application.Users.Queries.UserLogin;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator mediator;

        public CategoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("categories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var result = await mediator.Send(new CategoriesGetAllQuery());
            return new JsonResult(result);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> CategoryAdd(CategoryAddCommand command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}
