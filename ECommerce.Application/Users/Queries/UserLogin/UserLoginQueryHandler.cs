using AutoMapper;
using ECommerce.Application.Users.Commands.UserRegistration;
using ECommerce.Domain.AggregateModels.UserModels;
using ECommerce.Infrastructure.EFCore.Repository.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Users.Queries.UserLogin
{
    public class UserLoginQueryHandler : IRequestHandler<UserLoginQuery, UserLoginDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserLoginQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserLoginDto> Handle(UserLoginQuery request, CancellationToken cancellationToken)
        {
            var userExist = await _userRepository.EmailExistCheckAsync(request.Email);
            
            if (userExist == false) 
            {
                throw new Exception("User not exist!");
            }

            var userCheck = await _userRepository.GetByEmailAsync(request.Email);
            if (request.Password != userCheck.Password)
            {
                throw new Exception("Password is not correct!");
            }

            var statusCheck = _mapper.Map<UserLoginDto>(userCheck);
            if (statusCheck.Status == false)
            {
                throw new Exception("User is not active");
            }

            return await Task.FromResult(statusCheck);

        }
    }
}
