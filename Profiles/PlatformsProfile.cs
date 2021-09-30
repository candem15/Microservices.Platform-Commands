using AutoMapper;
using Micro.PlatformService.Dtos;
using Micro.PlatformService.Models;

namespace Micro.PlatformService.Profiles
{
    public class PlatformsProfile : Profile
    {
        public PlatformsProfile()
        {
            // Source -> Target
            CreateMap<Platform, PlatformReadDto>();
            CreateMap<PlatformCreateDto, Platform>();
        }
    }
}