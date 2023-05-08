using ECommerce.Application.Users.Commands.UserRegistration;
using ECommerce.Application.Users.Queries.UserLogin;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginUser(UserLoginQuery query)
        {
            return Ok(await mediator.Send(query));
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterUser(UserRegistrationCommand command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}
