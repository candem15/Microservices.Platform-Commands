using AutoMapper;
using Micro.CommandsService.Dtos;
using Micro.CommandsService.Models;
using Micro.PlatformService;

namespace Micro.CommandsService.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            // Source --> Target
            CreateMap<Platform, PlatformReadDto>();
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandCreateDto, Command>();
            CreateMap<PlatformPublishedDto, Platform>()
                .ForMember(
                    destinationMember => destinationMember.ExternalId,
                    memberOption => memberOption.MapFrom(
                        sourceMember => sourceMember.Id));
            CreateMap<GrpcPlatformModel, Platform>()
                .ForMember(destinationMember => destinationMember.ExternalId, opt => opt.MapFrom(sourceMember => sourceMember.PlatformId))
                .ForMember(destinationMember => destinationMember.Name, opt => opt.MapFrom(sourceMember => sourceMember.Name))
                .ForMember(destinationMember => destinationMember.Commands, opt => opt.Ignore());
        }
    }
}