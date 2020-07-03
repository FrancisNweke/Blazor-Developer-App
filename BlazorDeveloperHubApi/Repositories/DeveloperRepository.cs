using BlazorAPIShared.Models;
using BlazorDeveloperHubApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDeveloperHubApi.Repositories
{
    public class DeveloperRepository : IDeveloper
    {
        private readonly DeveloperhubDbContext context;
        public DeveloperRepository(DeveloperhubDbContext context)
        {
            this.context = context;
        }

        public async Task<Developer> Add(Developer developer)
        {
            var result = await context.Developers.AddAsync(developer);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Developer> Delete(Developer developer)
        {
            context.Developers.Remove(developer);
            await context.SaveChangesAsync();
            return developer;
        }

        public async Task<IEnumerable<Developer>> GetAll()
        {
            return await context.Developers.ToListAsync();
        }

        public async Task<Developer> GetSingle(string developerId)
        {
            var developer = await context.Developers.FindAsync(developerId);
            return developer;
        }

        public async Task<Developer> Update(Developer developerToBeModified)
        {
            var developer = context.Developers.Attach(developerToBeModified);
            developer.State = EntityState.Modified;
            await context.SaveChangesAsync();
            return developerToBeModified;
        }
    }
}
