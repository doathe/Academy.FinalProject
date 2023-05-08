using AutoMapper;
using ECommerce.Domain.AggregateModels.UserModels;
using ECommerce.Infrastructure.EFCore.Repository.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ECommerce.Application.Users.Commands.UserRegistration
{
    public class UserRegistrationCommandHandler : IRequestHandler<UserRegistrationCommand, UserRegistrationDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserRegistrationCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserRegistrationDto> Handle(UserRegistrationCommand request, CancellationToken cancellationToken)
        {

            var userExistCheck = await _userRepository.EmailExistCheckAsync(request.Email);
            if (userExistCheck == true)
            {
                throw new ApplicationException("User Already Exist");
            }
            else
            {
                if (request.Password != request.PasswordVerify)
                {
                    throw new ApplicationException("Password Verify is not match");
                }

                var model = _mapper.Map<User>(request);
                await _userRepository.AddAsync(model);

                var responseModel = _mapper.Map<UserRegistrationDto>(request);
                return await Task.FromResult(responseModel);
            }
        }
    }
}
