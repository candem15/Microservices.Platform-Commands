using System.Collections.Generic;
using Micro.CommandsService.Models;

namespace Micro.CommandsService.Data
{
    public interface ICommandRepo
    {
        bool SaveChanges();
        // Platform related methods
        IEnumerable<Platform> GetAllPlatforms();
        void CreatePlatform(Platform platform);
        bool PlatformExists(int platformId);
        bool ExternalPlatformExists(int externalPlatformId);
        // Command related methods
        IEnumerable<Command> GetCommandsForPlatform(int platformId);
        Command GetCommand(int platformId,int commandId);
        void CreateCommand(int platformId, Command command);
    }
}