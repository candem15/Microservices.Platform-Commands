using System;
using System.Linq;
using Micro.CommandsService.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Micro.CommandsService.Data
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
            Console.WriteLine("--> Trying to apply migrations...");

            try
            {
                dbContext.Database.Migrate();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Migrations could not applied: {ex.Message}");
            }

            if (!dbContext.Platforms.Any())
            {
                Console.WriteLine("--> Seeding data...");

                dbContext.Platforms.AddRange(
                 new Platform() { Id = 1, Name = "Dot Net", ExternalId = 1 },
                 new Platform() { Id = 2, Name = "Sql Server Express", ExternalId = 2 },
                 new Platform() { Id = 3, Name = "Kubernetes", ExternalId = 3 },
                 new Platform() { Id = 4, Name = "Postgresql", ExternalId = 4 },
                 new Platform() { Id = 5, Name = "Node.js", ExternalId = 5 }
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