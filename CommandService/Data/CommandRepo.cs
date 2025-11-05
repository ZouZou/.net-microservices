using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CommandService.Models;

namespace CommandService.Data
{
    public class CommandRepo : ICommandRepo
    {
        private readonly AppDbContext _context;
        public CommandRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreateCommand(int platformId, Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof (command));
            }
            command.PlatformId = platformId;
            _context.Commands.Add(command);
        }

        public void CreatePlatform(Platform plat)
        {
            if (plat == null)
            {
                throw new ArgumentNullException(nameof (plat));
            }
            _context.Platforms.Add(plat);
        }

        public async Task<bool> ExternalPlatformExistsAsync(int externalPlatformId)
        {
            return await _context.Platforms.AnyAsync(p => p.ExternalId == externalPlatformId);
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

        public async Task<Command> GetCommandAsync(int platformId, int commandId)
        {
            return await _context.Commands
                    .Where(c => c.PlatformId == platformId && c.Id == commandId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Command>> GetCommandsForPlatformAsync(int platformId)
        {
            return await _context.Commands
                    .Include(c => c.Platform)
                    .Where(c => c.PlatformId == platformId)
                    .OrderBy(c => c.Platform.Name)
                    .ToListAsync();
        }

        public async Task<bool> PlatformExistsAsync(int platformId)
        {
            return await _context.Platforms.AnyAsync(p => p.Id == platformId);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}