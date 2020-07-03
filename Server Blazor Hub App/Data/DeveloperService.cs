using BlazorAPIShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server_Blazor_Hub_App.Data
{
    public class DeveloperService : IDeveloperService
    {
        public string CreationDate { get; set; }
        public List<Developer> Developers { get; set; }
        public DeveloperService()
        {
            CreationDate =  string.Format("{0: HH:mm:ss - dddd MM, yyyy.}", DateTime.Now.ToString());

        }
        public List<Developer> GetDevelopers()
        {
            return Developers;
        }
        public Developer GetDeveloperById(string developerId)
        {
            return Developers.Where(dev => dev.DeveloperId == developerId).FirstOrDefault();
        }
        public bool SaveDeveloper(Developer developer)
        {
            Developers.Add(developer);
            return true;
        }
        public void DeleteDeveloper(string developerId)
        {
            //Developers.Remove(dev => dev.DeveloperId == developerId);
            var item = Developers.SingleOrDefault(dev => dev.DeveloperId == developerId);
            if (item != null)
                Developers.Remove(item);
        }
        public Developer EditDeveloper(string developerId)
        {
            var item = Developers.Find(dev => dev.DeveloperId == developerId);
            return item;
        }
        public string GetCreationDate()
        {
            return CreationDate;
        }
        public string GetVersion()
        {
            return "v1";
        }
    }
}
