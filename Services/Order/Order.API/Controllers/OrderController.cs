

using Order.Application.Constants.Messages;
using Order.Application.Features.Orders.Commands.CreateOrder;
using Order.Application.Features.Orders.Queries.GetOrder;
using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Application.Features.Orders.Queries.GetAllOrder;

namespace Order.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IPublishEndpoint _publishEndpoint;

        public OrderController(IMediator mediator,IPublishEndpoint publishEndpoint)
        {
            _mediator = mediator;
           _publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Create([FromBody] CreateOrderCommand command)
        {
            var result = await _mediator.Send(command);

            await _publishEndpoint.Publish(
              new OrderNotificationEvent()
              {
                  UserId = command.UserId,
                  Amount = command.Amount,
                  Type = OrderStatusType.Create
              });
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(OrderDto),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> GetById([FromRoute]Guid id)
        {
            var result = await _mediator.Send(new GetOrderQuery { OrderId = id });
            if (result is null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(OrderDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllOrderQuery());
            if (result is null)
                return NotFound();
            return Ok(result);
        }
    }
}
