using BlazorAPIShared.Models;
using BlazorDeveloperHubApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDeveloperHubApi.Repositories
{
    public class CountryRepository : ICountry
    {
        private readonly DeveloperhubDbContext context;

        public CountryRepository(DeveloperhubDbContext context)
        {
            this.context = context;
        }
        public async Task<Country> Add(Country country)
        {
            var result = await context.Countries.AddAsync(country);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Country> Delete(Country country)
        {
            context.Countries.Remove(country);
            await context.SaveChangesAsync();
            return country;
        }

        public async Task<IEnumerable<Country>> GetAll()
        {
            return await context.Countries
                //   .Include(c=> c.States)
                .ToListAsync();
        }

        public async Task<Country> GetSingle(string id)
        {
            var country = await context.Countries.FindAsync(id);
            return country;
        }

        public async Task<Country> Update(Country countryToBeModified)
        {
            var country = context.Countries.Attach(countryToBeModified);
            country.State = EntityState.Modified;
            await context.SaveChangesAsync();
            return countryToBeModified;
        }
    }
}
