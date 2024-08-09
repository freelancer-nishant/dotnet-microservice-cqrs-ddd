using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.Persistence
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext OrderContext, ILogger<OrderContextSeed> logger)
        {
            if (!OrderContext.Orders.Any())
            {
                OrderContext.Orders.AddRange(GetPreconfiguredOrders());
                await OrderContext.SaveChangesAsync();
                logger.LogInformation($"Seed database associated with context {typeof(OrderContext).Name}");
            }
        }

        private static IEnumerable<Domain.Entities.Order> GetPreconfiguredOrders()
        {
            return new List<Domain.Entities.Order>
            {
                new Domain.Entities.Order(Guid.Parse("ef533977-e666-4c75-ac4e-ea1de9ea4aef"), 1_000_000)
            };
        }
    }
}
