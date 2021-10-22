using System.Collections.Generic;
using Micro.CommandsService.Models;

namespace Micro.CommandsService.SyncDataServices.Grpc
{
    public interface IPlatformDataClient
    {
        IEnumerable<Platform> ReturnAllPlatforms();
    }
}