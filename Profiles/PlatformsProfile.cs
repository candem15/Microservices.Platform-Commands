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
            CreateMap<PlatformReadDto, PlatformPublishedDto>();
            CreateMap<Platform, GrpcPlatformModel>()
                .ForMember(destinationMember=>destinationMember.PlatformId, opt=>opt.MapFrom(sourceMember=>sourceMember.Id))
                .ForMember(destinationMember=>destinationMember.Name, opt=>opt.MapFrom(sourceMember=>sourceMember.Name))
                .ForMember(destinationMember=>destinationMember.Publisher, opt=>opt.MapFrom(sourceMember=>sourceMember.Publisher));
        }
    }
}