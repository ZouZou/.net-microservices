using System.Collections.Generic;
using System.Threading.Tasks;
using CommandService.Models;

namespace CommandService.Data
{
    public interface ICommandRepo
    {
        Task<bool> SaveChangesAsync();

        // Platforms
        Task<IEnumerable<Platform>> GetAllPlatformsAsync(int? skip = null, int? take = null);
        void CreatePlatform(Platform plat);
        Task<bool> PlatformExistsAsync(int platformId);
        Task<bool> ExternalPlatformExistsAsync(int externalPlatfromId);

        // Commands
        Task<IEnumerable<Command>> GetCommandsForPlatformAsync(int platformId);
        Task<Command> GetCommandAsync(int platformId, int commandId);
        void CreateCommand(int platformId, Command command);
    }
}