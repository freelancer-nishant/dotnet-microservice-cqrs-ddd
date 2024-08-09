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
using Order.Application.Features.Orders.Queries.GetOrder;

namespace Order.Application.Features.Orders.Queries.GetAllOrder
{
    public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQuery, List<OrderDto>>
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

        public async Task<List<OrderDto>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<OrderDto>>(await _OrderRepository.GetAllAsync())!;
        }
    }
}
