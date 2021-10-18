using System;

namespace Domain.Events.Models
{
    public class DomainEvent
    {
        public string AggregateId { get; set; }

        public string EventType { get; set; }

        public DateTime EventTimeStamp { get; set; }
    }
}
