using ECommerce.Application.Users.Commands.UserRegistration;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Users.Queries.UserLogin
{
    public class UserLoginQueryValidator : AbstractValidator<UserLoginQuery>
    {
        public UserLoginQueryValidator() 
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Email is not in a valid format");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(10).WithMessage("You must enter at least ten characters")
                .Matches(@"^(?=.*[A-Z])(?=.*\d).+$").WithMessage("Password must contain at least one uppercase letter and one digit");
        }
    }
}
