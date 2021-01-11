using System;
using System.Threading.Tasks;
using Vini.Application.ViewModels;
using FluentValidation.Results;

namespace Vini.Application.Interfaces
{
    public interface IHelloAppService : IDisposable
    {
        Task<ValidationResult> SayHello(HelloViewModel helloViewModel);
    }
}
