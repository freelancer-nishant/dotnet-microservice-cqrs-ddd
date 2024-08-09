using MediatR;
using Order.Application.Features.Orders.Queries.GetOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Features.Orders.Queries.GetAllOrder
{
    public class GetAllOrderQuery : IRequest<List<OrderDto>>
    {
        
    }
}
