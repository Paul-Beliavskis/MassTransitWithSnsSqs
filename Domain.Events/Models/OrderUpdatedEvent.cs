using System;

namespace Domain.Events.Models
{
    public class OrderUpdatedEvent
    {
        public string OrderNumber { get; set; }

        public Guid OrderId { get; set; }

        public DateTime OrderTimestamp { get; set; }
    }
}
