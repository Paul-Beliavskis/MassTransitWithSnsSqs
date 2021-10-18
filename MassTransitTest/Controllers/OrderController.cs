using Domain.Events.Models;
using MassTransit;
using MassTransit.AmazonSqsTransport;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;

        readonly IBus _bus;

        public OrderController(ILogger<OrderController> logger, IBus bus)
        {
            _logger = logger;

            _bus = bus;
        }

        [HttpPost]
        public async Task<string> CreateOrder()
        {
            await _bus.Publish(new OrderCreatedEvent
            {
                OrderId = Guid.NewGuid(),
                OrderNumber = "1234568",
                OrderTimestamp = DateTime.UtcNow

            });

            return "Success";
        }

        [HttpPut]
        public async Task<string> UpdateOrder()
        {
            await _bus.Publish(new OrderUpdatedEvent
            {
                OrderId = Guid.NewGuid(),
                OrderNumber = "1234568",
                OrderTimestamp = DateTime.UtcNow
            }, x => x.SetGroupId("OrderUpdated"));

            return "Success";
        }
    }
}
