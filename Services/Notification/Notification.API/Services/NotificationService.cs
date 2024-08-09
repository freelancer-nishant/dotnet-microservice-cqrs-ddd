using AutoMapper;
using notification.API.Data.DTOs.Requests;
using notification.API.Data.DTOs.Responses;
using notification.API.Repositories.Interfaces;
using notification.API.Services.Interfaces;

namespace notification.API.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly ILogger<NotificationService> _logger;
        private readonly IMapper _mapper;

        public NotificationService(INotificationRepository notificationRepository, ILogger<NotificationService> logger, IMapper mapper)
        {
            _notificationRepository = notificationRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<List<NotificationDto>> GetByOrderId(Guid OrderId)
        {
            var notifications = await _notificationRepository.GetByOrderId(OrderId);
            return _mapper.Map<List<NotificationDto>>(notifications)!;
        }

        public async Task<List<NotificationDto>> GetWithFilter(RequestFilter filter)
        {
            var notifications = await _notificationRepository.GetWithFilter(filter);
            return _mapper.Map<List<NotificationDto>>(notifications)!;
        }
    }
}
