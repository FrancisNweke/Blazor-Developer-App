using BlazorAPIShared.Models;
using BlazorDeveloperHubApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDeveloperHubApi.Repositories
{
    public class CityRepository: ICity
    {
        private readonly DeveloperhubDbContext context;
        public CityRepository(DeveloperhubDbContext context)
        {
            this.context = context;
        }

        public async Task<City> Add(City city)
        {
            var result = await context.Cities.AddAsync(city);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<City> Delete(City city)
        {
            context.Cities.Remove(city);
            await context.SaveChangesAsync();
            return city;
        }

        public async Task<IEnumerable<City>> GetAll()
        {
            return await context.Cities.ToListAsync();
        }
        public async Task<IEnumerable<City>> GetAllByCountryCode(string countryCode)
        {
            return await context.Cities.Where(p => p.CountryCode == countryCode).ToListAsync();
        }
        public async Task<City> GetSingle(string id)
        {
            var city = await context.Cities.FindAsync(id);
            return city;
        }

        public async Task<City> Update(City cityToBeModified)
        {
            var city = context.Cities.Attach(cityToBeModified);
            city.State = EntityState.Modified;
            await context.SaveChangesAsync();
            return cityToBeModified;
        }
    }
}
