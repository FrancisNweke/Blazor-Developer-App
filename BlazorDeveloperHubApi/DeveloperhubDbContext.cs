using BlazorAPIShared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDeveloperHubApi
{
    public class DeveloperhubDbContext : DbContext
    {
        public DeveloperhubDbContext(DbContextOptions<DeveloperhubDbContext> options) : base(options)
        {

        }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }        
    }
}
