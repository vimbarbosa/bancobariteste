using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Mac.Domain.Interfaces;
using Mac.Domain.Entities;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;
using Mac.MessageBroker.Producer.v1;
using Mac.MessageBroker.Producer.v1.Message;
using Microsoft.Extensions.Configuration;

namespace Mac.Domain.Commands
{
    public class HelloCommandHandler : CommandHandler,
        IRequestHandler<SendNewHelloCommand, ValidationResult>
    {
        private readonly IHelloRepository _customerRepository;
        private readonly IMessageProducer _messageProducer;
        private readonly ILogger _logger;
        private readonly string _topicName;
        private readonly Guid _serviceId;

        public HelloCommandHandler(IHelloRepository customerRepository, IConfiguration configuration, IMessageProducer messageProducer, ILogger<HelloCommandHandler> logger)
        {
            _customerRepository = customerRepository;
            _serviceId = Guid.NewGuid();
            _topicName = configuration.GetSection("Queues:Producer").Value;
            _messageProducer = messageProducer;
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
             _messageProducer.SendMessageAsync(_topicName,  message).Wait();
        }

        public void Dispose()
        {
            _customerRepository.Dispose();
        }
    }
}