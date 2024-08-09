using Order.Application.Contracts.Persistence;
using Order.Application.Features.Orders.Queries.GetOrder;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IOrderRepository _OrderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateOrderHandler> _logger;

        public CreateOrderHandler(IOrderRepository OrderRepository, IMapper mapper, ILogger<CreateOrderHandler> logger)
        {
            _OrderRepository = OrderRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var OrderEntity = new Domain.Entities.Order()
            {
                UserId = request.UserId,
                Balance = request.Amount,
                //CreatedDate = DateTime.UtcNow,
                //LastModifiedDate = DateTime.UtcNow                
            };
            var newOrder = await _OrderRepository.AddAsync(OrderEntity!);
            return newOrder.Id;
        }
    }
}
