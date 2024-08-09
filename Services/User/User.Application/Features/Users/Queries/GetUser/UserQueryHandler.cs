using AutoMapper;
using User.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Application.Features.Users.Queries.GetUser
{
    public class UserQueryHandler : IRequestHandler<UserQuery, List<UserDto>>
    {
        private readonly IUserRepository _UserRepository;
        private readonly IMapper _mapper;

        public UserQueryHandler(IUserRepository UserRepository, IMapper mapper)
        {
            _UserRepository = UserRepository;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> Handle(UserQuery request, CancellationToken cancellationToken)
        {
            var User = await _UserRepository.GetAllAsync();
            return _mapper.Map<List<UserDto>>(User)!;
        }
    }
}
