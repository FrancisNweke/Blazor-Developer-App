using BlazorAPIShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDeveloperHubApi.Interfaces
{
    public interface IDeveloper
    {
        Task<IEnumerable<Developer>> GetAll();

        Task<Developer> GetSingle(string developerId);

        Task<Developer> Delete(Developer developer);

        Task<Developer> Update(Developer developerToBeModified);

        Task<Developer> Add(Developer developer);
    }
}
