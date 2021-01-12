using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Vini.Domain.Interfaces;
using Vini.Domain.Entities;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;
using Vini.MessageBroker.Producer.v1;
using Vini.MessageBroker.Producer.v1.Message;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace Vini.Domain.Commands
{
    public class HelloCommandHandler : CommandHandler,
        IRequestHandler<SendNewHelloCommand, ValidationResult>
    {
        private readonly IMessageProducer _messageProducer;
        private readonly ILogger _logger;
        private readonly string _topicName;
        private readonly Guid _serviceId;

        public HelloCommandHandler(IConfiguration configuration, IMessageProducer messageProducer, ILogger<HelloCommandHandler> logger)
        {
            _serviceId = Guid.NewGuid();
            _topicName = configuration.GetSection("Queues:Producer").Value;
            _messageProducer = messageProducer;
            _logger = logger;
        }

        public async Task<ValidationResult> Handle(SendNewHelloCommand message, CancellationToken cancellationToken)
        {
            var timer = new System.Timers.Timer(5000)
            {
                AutoReset = true,
                Enabled = true,
            };

            var hello = new Hello(message.Id, message.Message);

            timer.Elapsed += (sender, e) => TimeElapsed(sender, e, new HelloMessage(_serviceId, hello));

            return await Task.FromResult(new ValidationResult());
        }

        private void TimeElapsed(object sender, System.Timers.ElapsedEventArgs e, HelloMessage message)
        {
            _logger.LogInformation($"[{nameof(HelloCommandHandler)}][{nameof(TimeElapsed)}]Posted|{JsonSerializer.Serialize(message)}");
            _messageProducer.SendMessageAsync(_topicName,  message).Wait();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}