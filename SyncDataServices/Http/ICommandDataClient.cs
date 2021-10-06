using System.Threading.Tasks;
using Micro.PlatformService.Dtos;

namespace  Micro.PlatformService.SyncDataServices.Http
{
    public interface ICommandDataClient
    {
         Task SendPlatformToCommand(PlatformReadDto plat);
    }
}