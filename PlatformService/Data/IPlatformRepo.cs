using System.Collections.Generic;
using System.Threading.Tasks;
using PlatformService.Models;

namespace PlatformService.Data
{
    public interface IPlatformRepo
    {
        Task<bool> SaveChangesAsync();

        Task<IEnumerable<Platform>> GetAllPlatformsAsync(int? skip = null, int? take = null);
        Task<Platform> GetPlatformByIdAsync(int id);
        void CreatePlatform(Platform plat);
    }
}