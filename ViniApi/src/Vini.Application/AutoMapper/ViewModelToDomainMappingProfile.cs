using AutoMapper;
using Vini.Application.ViewModels;
using Vini.Domain.Commands;

namespace Vini.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<HelloViewModel, SendNewHelloCommand>()
                .ConstructUsing(c => new SendNewHelloCommand(c.Message));
        }
    }
}
