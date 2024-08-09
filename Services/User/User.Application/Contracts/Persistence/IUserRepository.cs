using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace User.Application.Contracts.Persistence
{
    public interface IUserRepository : IRepositoryBase<Domain.Entities.User>
    {
        Task<bool> AnyAsync(Expression<Func<Domain.Entities.User, bool>> predicate);
    }
}
