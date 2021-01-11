using AutoMapper;
using Mac.Application.ViewModels;
using Mac.Domain.Commands;

namespace Mac.Application.AutoMapper
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
