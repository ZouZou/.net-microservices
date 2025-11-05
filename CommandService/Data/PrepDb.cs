using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommandService.Models;
using CommandService.SyncDataServices.Grpc;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CommandService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var grpcClient = serviceScope.ServiceProvider.GetService<IPlatformDataClient>();

                var platforms = grpcClient.ReturnAllPlatforms();

                SeedDataAsync(serviceScope.ServiceProvider.GetService<ICommandRepo>(), platforms).GetAwaiter().GetResult();
            }
        }

        private static async Task SeedDataAsync(ICommandRepo repo, IEnumerable<Platform> platforms)
        {
            Console.WriteLine("--> Seeding new platforms...");

            foreach (var plat in platforms)
            {
                if (!await repo.ExternalPlatformExistsAsync(plat.ExternalId))
                {
                    repo.CreatePlatform(plat);
                }
            }

            // Save changes once after all platforms are added
            await repo.SaveChangesAsync();
        }
    }
}