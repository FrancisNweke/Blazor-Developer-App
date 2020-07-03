using BlazorAPIShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDeveloperHubApi.Interfaces
{
    public interface ICity
    {
        Task<City> Add(City city);
        Task<City> Update(City cityToBeModified);
        Task<City> GetSingle(string id);
        Task<IEnumerable<City>> GetAll();
        Task<IEnumerable<City>> GetAllByCountryCode(string countryCode);
        Task<City> Delete(City city);
    }
}
