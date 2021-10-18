using Domain.Events.Models;
using MassTransit;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ShipmentService.Consumers
{
    public class OrderUpdatedConsumer : IConsumer<OrderUpdatedEvent>
    {
        readonly ILogger<OrderUpdatedConsumer> _logger;

        public OrderUpdatedConsumer(ILogger<OrderUpdatedConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<OrderUpdatedEvent> context)
        {
            _logger.LogInformation("Received Text: {Text}", context.Message);

            return Task.CompletedTask;
        }
    }
}
