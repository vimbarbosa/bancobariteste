using Mac.Application.Interfaces;
using Mac.Application.Services;
using Mac.Domain.Commands;
using Mac.Domain.Interfaces;
using Mac.Infra.CrossCutting.BUS;
using Mac.Infra.Data.Context;
using Mac.Infra.Data.Repository;
using Mac.MessageBroker.Producer.v1;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NetDevPack.Mediator;

namespace Mac.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application
            services.AddScoped<IHelloAppService, HelloAppService>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<SendNewHelloCommand, ValidationResult>, HelloCommandHandler>();

            // Infra - Data
            services.AddScoped<IHelloRepository, HelloRepository>();
            services.AddScoped<ViniContext>();

            //Message Broker
            services.AddScoped<IMessageProducer, MessageProducer>();
        }
    }
}