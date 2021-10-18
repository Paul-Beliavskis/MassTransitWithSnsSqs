using System;

namespace Domain.Events.Models
{
    public class OrderCreatedEvent : DomainEvent
    {
        public string OrderNumber { get; set; }

        public Guid OrderId { get; set; }

        public DateTime OrderTimestamp { get; set; }

    }
}
