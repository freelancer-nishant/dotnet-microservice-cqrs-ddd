using MongoDB.Driver;
using notification.API.Data.Interfaces;

namespace notification.API.Data
{
    public class NotificationContext : INotificationContext
    {
        public NotificationContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            notifications = database.GetCollection<Entities.Notification>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            NotificationContextSeed.SeedData(notifications);
        }

        public IMongoCollection<Entities.Notification> notifications { get; }
    }
}
