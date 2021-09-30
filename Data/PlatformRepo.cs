using System;
using System.Collections.Generic;
using System.Linq;
using Micro.PlatformService.Models;

namespace Micro.PlatformService.Data
{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly AppDbContext _dbContext;
        public PlatformRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void CreatePlatform(Platform plat)
        {
            if(plat==null)
            {
                throw new ArgumentNullException(nameof(plat));
            }

            _dbContext.Platforms.Add(plat);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _dbContext.Platforms.ToList();
        }

        public Platform GetPlatformById(int id)
        {
            return _dbContext.Platforms.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_dbContext.SaveChanges() >= 0); //If anythings changes, this method will be greater than zero and returns true.
        }
    }
}