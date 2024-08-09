using AutoMapper;
using EventBus.Messages.Events;
using MassTransit;
using notification.API.Repositories.Interfaces;
using notification.API.Services.Interfaces;

namespace notification.API.EventBusConsumer
{
    public class OrderNotificationConsumer : IConsumer<OrderNotificationEvent>
    {
        private readonly ILogger<OrderNotificationConsumer> _logger;
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;

        public OrderNotificationConsumer(ILogger<OrderNotificationConsumer> logger, INotificationRepository notificationRepository, IMapper mapper)
        {
            _logger = logger;
            _notificationRepository = notificationRepository;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<OrderNotificationEvent> context)
        {
            var notification = _mapper.Map<Entities.Notification>(context.Message);
            if (notification is not null)
            {
                await _notificationRepository.Add(notification);
                _logger.LogTrace($"Order Notification Received OrderId:{context.Message.OrderId}, UserId:{context.Message.UserId}, Amound:{context.Message.Amount}");
            }
        }
    }
}
