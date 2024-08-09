using Order.Application.Constants.Messages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Features.Orders.Queries.GetAllOrder
{
    public class GetAllOrderValidator : AbstractValidator<GetAllOrderQuery>
    {
        public GetAllOrderValidator()
        {
  
        }
    }
}
