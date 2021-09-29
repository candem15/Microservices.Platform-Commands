using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Micro.PlatformService.Models;
using Microsoft.EntityFrameworkCore;

namespace Micro.PlatformService.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        public DbSet<Platform> Platforms { get; set; }
    }
}