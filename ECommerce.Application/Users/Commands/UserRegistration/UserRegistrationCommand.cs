using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Users.Commands.UserRegistration
{
    public class UserRegistrationCommand : IRequest<UserRegistrationDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordVerify { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
    }
}
