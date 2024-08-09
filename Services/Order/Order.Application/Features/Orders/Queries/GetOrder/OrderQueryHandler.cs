using Order.Application.Contracts.Persistence;
using Order.Application.Exceptions;
using Order.Application.Features.Orders.Commands.CreateOrder;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Features.Orders.Queries.GetOrder
{
    public class GetAllOrderQueryHandler : IRequestHandler<GetOrderQuery, OrderDto>
    {
        private readonly IOrderRepository _OrderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllOrderQueryHandler> _logger;

        public GetAllOrderQueryHandler(IOrderRepository OrderRepository, IMapper mapper, ILogger<GetAllOrderQueryHandler> logger)
        {
            _OrderRepository = OrderRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<OrderDto> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var Order = await _OrderRepository.GetAsync(x => x.Id == request.OrderId);
            if (Order is null)
                throw new NotFoundException(nameof(Domain.Entities.Order), request.OrderId);
            return _mapper.Map<OrderDto>(Order)!;
        }
    }
}
