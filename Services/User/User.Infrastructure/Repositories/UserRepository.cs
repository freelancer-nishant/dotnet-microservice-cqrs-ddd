using User.Application.Contracts.Persistence;
using User.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace User.Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<Domain.Entities.User>, IUserRepository
    {
        public UserRepository(UserContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> AnyAsync(Expression<Func<Domain.Entities.User, bool>> predicate)
        {
            return await _dbContext.Users
                .AnyAsync(predicate);
        }
    }
}
