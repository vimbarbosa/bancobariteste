using System;
using System.Threading.Tasks;
using Mac.Application.ViewModels;
using FluentValidation.Results;

namespace Mac.Application.Interfaces
{
    public interface IHelloAppService : IDisposable
    {
        Task<ValidationResult> SayHello(HelloViewModel helloViewModel);
    }
}
