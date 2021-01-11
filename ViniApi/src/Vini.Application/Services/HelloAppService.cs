using System;
using System.Threading.Tasks;
using AutoMapper;
using Vini.Application.Interfaces;
using Vini.Application.ViewModels;
using Vini.Domain.Commands;
using FluentValidation.Results;
using NetDevPack.Mediator;

namespace Vini.Application.Services
{
    public class HelloAppService : IHelloAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        public HelloAppService(IMapper mapper,
                                  IMediatorHandler mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ValidationResult> SayHello(HelloViewModel helloViewModel)
        {
            var registerCommand = _mapper.Map<SendNewHelloCommand>(helloViewModel);
            return await _mediator.SendCommand(registerCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
