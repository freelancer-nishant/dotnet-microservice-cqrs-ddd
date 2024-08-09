using EventBus.Messages.Events;

namespace notification.API.Data.DTOs.Responses
{
    public class NotificationDto
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid UserId { get; set; }
        public decimal Amount { get; set; }
        public OrderStatusType Type { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
