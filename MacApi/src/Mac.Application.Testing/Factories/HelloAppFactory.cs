using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Mac.Application.Interfaces;
using Mac.Application.Testing.Factories.Interface;
using Mac.Application.ViewModels;

namespace Mac.Application.Testing.Factories
{
    public class HelloAppFactory : IBaseApplicationTestFactory
    {
        private readonly IHelloAppService _helloAppService;

        public HelloAppFactory(IHelloAppService helloAppService)
        {
            _helloAppService = helloAppService;
        }

        public async Task<ValidationResult> SayHello(HelloViewModel helloViewModel)
        {
            return await _helloAppService.SayHello(helloViewModel);
        }
    }
}
