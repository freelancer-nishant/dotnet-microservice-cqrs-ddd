using MongoDB.Driver;
using notification.API.Data.DTOs.Requests;
using notification.API.Data.Interfaces;
using notification.API.Repositories.Interfaces;

namespace notification.API.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly INotificationContext _notificationContext;

        public NotificationRepository(INotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        public async Task Add(Entities.Notification notification)
        {
            await _notificationContext.notifications.InsertOneAsync(notification);
        }

        public async Task<IEnumerable<Entities.Notification>> GetByOrderId(Guid OrderId)
        {
            return await _notificationContext
                .notifications
                .Find(x => x.OrderId == OrderId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Entities.Notification>> GetWithFilter(RequestFilter filter)
        {
            var filterBuilder = Builders<Entities.Notification>.Filter;

            var filters = filterBuilder.Eq(x => x.UserId, filter.UserId) &
                filterBuilder.Gte(x => x.CreatedDate, filter.StartDate) &
                filterBuilder.Lt(x => x.CreatedDate, filter.EndDate);

            return await _notificationContext
                .notifications
                .Find(filters)
                .ToListAsync();
        }
    }
}
