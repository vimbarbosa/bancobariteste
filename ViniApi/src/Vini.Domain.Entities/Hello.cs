using NetDevPack.Domain;
using System;

namespace Vini.Domain.Entities
{
    public class Hello : Entity, IAggregateRoot
    {
        public Hello(Guid id, string message)
        {
            Id = id;
            Message = message;
        }

        // Empty constructor for EF
        protected Hello() { }

        public string Message { get; private set; }
    }
}
