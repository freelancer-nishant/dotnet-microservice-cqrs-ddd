using MongoDB.Driver;

namespace notification.API.Data.Interfaces
{
    public interface INotificationContext
    {
        IMongoCollection<Entities.Notification> notifications { get; }
    }
}
