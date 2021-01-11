using AutoMapper;
using Mac.Application.ViewModels;
using Mac.Domain.Entities;

namespace Mac.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Hello, HelloViewModel>();
        }
    }
}
