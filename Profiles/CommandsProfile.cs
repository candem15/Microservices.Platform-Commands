using AutoMapper;
using Micro.CommandsService.Dtos;
using Micro.CommandsService.Models;

namespace Micro.CommandsService.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            // Source --> Target
            CreateMap<Platform,PlatformReadDto>();
            CreateMap<Command,CommandReadDto>();
            CreateMap<CommandCreateDto,Command>();
        }
    }
}