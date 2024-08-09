using AutoMapper;
using User.Application.Contracts.Persistence;
using User.Application.Features.Users.Queries.GetUser;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IUserRepository _UserRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateUserHandler> _logger;

        public CreateUserHandler(IUserRepository UserRepository, IMapper mapper, ILogger<CreateUserHandler> logger)
        {
            _UserRepository = UserRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var UserEntity = _mapper.Map<Domain.Entities.User>(request);
            var newUser = await _UserRepository.AddAsync(UserEntity!);
            return _mapper.Map<UserDto>(newUser)!;
        }
    }
}
