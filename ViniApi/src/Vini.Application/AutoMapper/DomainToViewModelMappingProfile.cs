using AutoMapper;
using Vini.Application.ViewModels;
using Vini.Domain.Entities;

namespace Vini.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Hello, HelloViewModel>();
        }
    }
}
