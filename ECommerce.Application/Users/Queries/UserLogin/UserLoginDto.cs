using AutoMapper;
using ECommerce.Application.Users.Commands.UserRegistration;
using ECommerce.Domain.AggregateModels.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Users.Queries.UserLogin
{
    public class UserLoginDto
    {
        public string Email { get; set; }
        public bool Status { get; set; }
    }

    public class UserLoginProfile : Profile
    {
        public UserLoginProfile()
        {
            CreateMap<UserLoginQuery, User>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();
        }
    }
}
