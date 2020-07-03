using BlazorAPIShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server_Blazor_Hub_App.Data
{
    interface IDeveloperService
    {
        public List<Developer> GetDevelopers();
        public Developer GetDeveloperById(string developerId);
        public string GetCreationDate();
        public bool SaveDeveloper(Developer developer);

        public void DeleteDeveloper(string developerId);

        public Developer EditDeveloper(string developerId);
        public string GetVersion();
    }
}
