using EventBus.Messages.Events;
using MongoDB.Driver;

namespace notification.API.Data
{
    public class NotificationContextSeed
    {
        public static void SeedData(IMongoCollection<Entities.Notification> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetPreconfiguredProducts());
            }
        }
        private static IEnumerable<Entities.Notification> GetPreconfiguredProducts()
        {
            return new List<Entities.Notification>()
            {
                new ()
                {
                    Id = Guid.NewGuid(),
                    OrderId = Guid.Parse("a3372135-ea3d-4eb9-8209-5a36634b2bba"),
                    Amount = 1_000_000,
                    UserId = Guid.Parse("ef533977-e666-4c75-ac4e-ea1de9ea4aef"),
                    Type = OrderStatusType.Create,
                    CreatedDate = DateTime.UtcNow
                }
            };
        }
    }
}
