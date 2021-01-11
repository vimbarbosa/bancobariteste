using System;
using NetDevPack.Messaging;

namespace Mac.Domain.Core.Events
{
    public class StoredEvent : Event
    {
        public StoredEvent(Event theEvent, string data)
        {
            Id = Guid.NewGuid();
            AggregateId = theEvent.AggregateId;
            MessageType = theEvent.MessageType;
            Data = data;
        }

        // EF Constructor
        protected StoredEvent() { }

        public Guid Id { get; private set; }

        public string Data { get; private set; }
    }
}