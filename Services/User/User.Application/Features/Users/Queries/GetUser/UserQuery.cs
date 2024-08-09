using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Application.Features.Users.Queries.GetUser
{
    public class UserQuery : IRequest<List<UserDto>>
    {
        public UserQuery()
        {
            
        }
    }
}
