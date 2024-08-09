using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Infrastructure.Persistence
{
    public class UserContextSeed
    {
        public static async Task SeedAsync(UserContext UserContext, ILogger<UserContextSeed> logger)
        {
            if (!UserContext.Users.Any())
            {
                UserContext.Users.AddRange(GetPreconfiguredUsers());
                await UserContext.SaveChangesAsync();
                logger.LogInformation($"Seed database associated with context {typeof(UserContext).Name}");
            }
        }

        private static IEnumerable<Domain.Entities.User> GetPreconfiguredUsers()
        {
            return new List<Domain.Entities.User>
            {
                new Domain.Entities.User(Guid.Parse("ef533977-e666-4c75-ac4e-ea1de9ea4aef"), "nishant@hotmail.com", "nishant", "agarwal")
            };
        }
    }
}
