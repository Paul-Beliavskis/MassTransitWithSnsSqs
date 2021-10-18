using Domain.Events.Models;
using MassTransit;
using System.Threading.Tasks;

namespace ShipmentService.Consumers
{
    public class OrderCreatedConsumer : IConsumer<OrderCreatedEvent>
    {

        public OrderCreatedConsumer()
        {

        }

        public Task Consume(ConsumeContext<OrderCreatedEvent> context)
        {

            return Task.CompletedTask;
        }
    }
}
