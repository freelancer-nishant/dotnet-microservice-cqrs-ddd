using EventBus.Messages.Events;
using MongoDB.Bson.Serialization.Attributes;

namespace notification.API.Entities
{
    public class Notification
    {
        [BsonId]
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid UserId { get; set; }
        public decimal Amount { get; set; }
        public OrderStatusType Type { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
