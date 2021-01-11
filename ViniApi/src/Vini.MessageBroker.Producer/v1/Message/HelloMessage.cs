using Vini.Domain.Entities;
using System;

namespace Vini.MessageBroker.Producer.v1.Message
{
    public class HelloMessage : Message<Hello>
    {
        public HelloMessage(Guid serviceId, Hello content) : base(serviceId, content)
        {
        }
    }
}
