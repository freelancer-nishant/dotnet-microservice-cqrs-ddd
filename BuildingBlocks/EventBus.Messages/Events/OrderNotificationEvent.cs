using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages.Events
{
    public class OrderNotificationEvent : IntegrationBaseEvent
    {
        public Guid OrderId { get; set; }
        public Guid UserId { get; set; }
        public OrderStatusType Type { get; set; }
        public decimal Amount { get; set; }
    }
}