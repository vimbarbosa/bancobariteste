using System;
using System.Threading.Tasks;
using AutoMapper;
using Vini.Application.Interfaces;
using Vini.Application.ViewModels;
using Vini.Domain.Commands;
using FluentValidation.Results;
using NetDevPack.Mediator;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Vini.Application.Services
{
    public class HelloAppService : IHelloAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
        private readonly ILogger<HelloAppService> _log;

        public HelloAppService(IMapper mapper,
                                  IMediatorHandler mediator, ILogger<HelloAppService> log)
        {
            _mapper = mapper;
            _mediator = mediator;
            _log = log;
        }

        public async Task<ValidationResult> SayHello(HelloViewModel helloViewModel)
        {
            _log.LogInformation($"[{nameof(HelloAppService)}][{nameof(SayHello)}]Posted|{JsonSerializer.Serialize(helloViewModel)}");

            var registerCommand = _mapper.Map<SendNewHelloCommand>(helloViewModel);
            return await _mediator.SendCommand(registerCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
