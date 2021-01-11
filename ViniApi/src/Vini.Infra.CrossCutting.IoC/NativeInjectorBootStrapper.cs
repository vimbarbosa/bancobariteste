using Vini.Application.Interfaces;
using Vini.Application.Services;
using Vini.Domain.Commands;
using Vini.Domain.Interfaces;
using Vini.Infra.CrossCutting.BUS;
using Vini.Infra.Data.Context;
using Vini.Infra.Data.Repository;
using Vini.MessageBroker.Producer.v1;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NetDevPack.Mediator;

namespace Vini.Infra.CrossCutting.IoC
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