using Mac.Domain.Entities;
using System;

namespace Mac.MessageBroker.Producer.v1.Message
{
    public class HelloMessage : Message<Hello>
    {
        public HelloMessage(Guid serviceId, Hello content) : base(serviceId, content)
        {
        }
    }
}
