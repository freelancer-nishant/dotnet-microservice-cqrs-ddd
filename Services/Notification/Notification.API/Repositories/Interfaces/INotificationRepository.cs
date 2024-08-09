using notification.API.Data.DTOs.Requests;

namespace notification.API.Repositories.Interfaces
{
    public interface INotificationRepository
    {
        Task Add(Entities.Notification notification);
        Task<IEnumerable<Entities.Notification>> GetByOrderId(Guid OrderId);
        Task<IEnumerable<Entities.Notification>> GetWithFilter(RequestFilter filter);
    }
}
