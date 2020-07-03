using BlazorAPIShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDeveloperHubApi.Interfaces
{
    public interface ICountry
    {
        Task<Country> Add(Country country);
        Task<Country> Update(Country countryToBeModified);
        Task<Country> GetSingle(string id);
        Task<IEnumerable<Country>> GetAll();
        Task<Country> Delete(Country country);
    }
}
