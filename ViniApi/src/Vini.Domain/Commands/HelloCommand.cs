using System;
using NetDevPack.Messaging;

namespace Vini.Domain.Commands
{
    public abstract class HelloCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Message { get; protected set; }
    }
}