using Order.Application.Constants.Messages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Features.Orders.Queries.GetOrder
{
    public class GetAllOrderValidator : AbstractValidator<OrderDto>
    {
        public GetAllOrderValidator()
        {
            RuleFor(x => x.UserId)
                .NotEqual(Guid.Empty).WithMessage(OrderMessages.UserRequired);
            RuleFor(x => x.OrderId)
                .NotEqual(Guid.Empty).WithMessage(OrderMessages.OrderRequired);
        }
    }
}
