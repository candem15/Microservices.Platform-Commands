using System;
using System.Linq;
using Micro.PlatformService.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Micro.PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext dbContext)
        {
            if(!dbContext.Platforms.Any())
            {
                Console.WriteLine("--> Seeding data...");

                dbContext.Platforms.AddRange(
                    new Platform() {Name="Dot Net", Publisher="Microsoft", Cost="Free"},
                    new Platform() {Name="Sql Server Express", Publisher="Microsoft", Cost="Free"},
                    new Platform() {Name="Kubernetes", Publisher="Cloud Native Computing Foundation", Cost="Free"},
                    new Platform() {Name="Postgresql", Publisher="PostgreSQL Global Development Group", Cost="Free"},
                    new Platform() {Name="Node.js", Publisher="	OpenJS Foundation", Cost="Free"}
                );

                dbContext.SaveChanges();
            }
            else
            {
                    Console.WriteLine("--> We aldready have data");
            }
        }
    }
}