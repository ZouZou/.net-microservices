using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Data
{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly AppDbContext _context;

        public PlatformRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreatePlatform(Platform plat)
        {
            if (plat == null)
            {
                throw new System.ArgumentNullException(nameof(plat));
            }

            _context.Platforms.Add(plat);
        }

        public async Task<IEnumerable<Platform>> GetAllPlatformsAsync(int? skip = null, int? take = null)
        {
            var query = _context.Platforms.AsQueryable();

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return await query.ToListAsync();
        }

        public async Task<Platform> GetPlatformByIdAsync(int id)
        {
            return await _context.Platforms.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}