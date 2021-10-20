using Domain.Events.Models;
using MassTransit;
using MassTransit.AmazonSqsTransport;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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
            var orderevent = new OrderCreatedEvent
            {
                OrderId = Guid.NewGuid(),
                OrderNumber = "1234568",
                OrderTimestamp = DateTime.UtcNow
            };

            await _bus.Publish(orderevent, x =>
                    {
                        x.SetDeduplicationId(Guid.NewGuid().ToString());
                        x.SetGroupId("Events");
                    });

            return "Success";
        }

        [HttpPut]
        public async Task<string> UpdateOrder()
        {
            var tasks = new List<Task>();

            for (int i = 0; i < 700; i++)
            {
                _bus.Publish(new OrderUpdatedEvent
                {
                    OrderId = Guid.NewGuid(),
                    OrderNumber = "1234568",
                    OrderTimestamp = DateTime.UtcNow
                }, x =>
                {
                    x.SetDeduplicationId(Guid.NewGuid().ToString());
                    x.SetGroupId("Events");
                });
            }

            await Task.WhenAll(tasks);

            return "Success";
        }
    }
}
