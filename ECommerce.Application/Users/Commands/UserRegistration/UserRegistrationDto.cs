using AutoMapper;
using ECommerce.Domain.AggregateModels.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECommerce.Application.Users.Commands.UserRegistration
{
    public class UserRegistrationDto 
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
    public class UserRegistrationProfile : Profile
    {
        public UserRegistrationProfile()
        {
            CreateMap<UserRegistrationCommand, UserRegistrationDto>()
                .ForMember(destination => destination.Name, operation => operation.MapFrom(source => source.FirstName + " " + source.LastName));
            CreateMap<UserRegistrationCommand, User>().ReverseMap();
        }
    }
}
