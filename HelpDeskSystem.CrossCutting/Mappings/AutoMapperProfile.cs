using AutoMapper;
using DefaultNamespace;
using HelpDeskSystem.API.Enums;
using HelpDeskSystem.API.Models;
using HelpDeskSystem.DTO.Client;
using HelpDeskSystem.DTO.Messages;

namespace HelpDeskSystem.CrossCutting.Mappings;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<ClientModel, ClientResponseDto>().ReverseMap();
        CreateMap<ClientRequestDto, ClientModel>();

        CreateMap<CalledModel, CalledResponseDto>()
            .ForMember(dest => dest.ClientName, opt => opt.MapFrom(src => src.Client.Name))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
            .ForMember(dest => dest.Messages, opt => opt.MapFrom(src => src.Messages));

        CreateMap<CalledRequestDto, CalledModel>()
            .ConstructUsing(dto => new CalledModel(
                dto.IdCalled,
                dto.ClientId,
                dto.TechnicalId,
                dto.Technical,
                dto.DateClose,
                Enum.Parse<CalledStatusEnum>(dto.Status),
                new List<MessageModel>()
            ));

        CreateMap<MessageModel, MessageResponseDto>().ReverseMap();
        CreateMap<MessageRequestDto, MessageModel>();
    }
}
