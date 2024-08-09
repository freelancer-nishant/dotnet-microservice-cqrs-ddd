using notification.API.Data.DTOs.Requests;
using notification.API.Data.DTOs.Responses;

namespace notification.API.Services.Interfaces
{
    public interface INotificationService
    {
        Task<List<NotificationDto>> GetByOrderId(Guid OrderId);
        Task<List<NotificationDto>> GetWithFilter(RequestFilter filter);
    }
}
