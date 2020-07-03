using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorAPIShared.Models;
using BlazorDeveloperHubApi.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server_Blazor_Hub_App.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("_MyAllowSpecificOrigins")]
    public class DeveloperController : ControllerBase
    {
        private readonly IDeveloper repository;
        public DeveloperController(IDeveloper repository)
        {
            this.repository = repository;
        }
        [HttpGet("GetAllDeveloper")]
        public async Task<ActionResult<IEnumerable<Developer>>> GetAllDeveloper()
        {
            var developers = await repository.GetAll();
            return StatusCode(StatusCodes.Status200OK, developers);
        }
        [HttpGet("GetSingleDeveloper/{developerId}")]
        public async Task<ActionResult<Developer>> GetSingleDeveloper(string developerId)
        {
            var developer = await repository.GetSingle(developerId);
            return StatusCode(StatusCodes.Status200OK, developer);
        }
        [HttpPost("AddDeveloper")]
        public async Task<ActionResult<Developer>> AddDeveloper(Developer model)
        {
            if (ModelState.IsValid)
            {
                Developer developer = new Developer
                {
                    DeveloperId = model.DeveloperId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Description = model.Description,
                    EmailAddress = model.EmailAddress,
                    Country = model.Country,
                    City = model.City,
                    AnnualSalary = model.AnnualSalary,
                    ExperienceInYears = model.ExperienceInYears,
                    DoesOpenSource = model.DoesOpenSource,
            };
                var result = await repository.Add(developer);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Unable to save developer record.");
            }
        }
        [HttpDelete("DeleteDeveloper")]
        public async Task<ActionResult<Developer>> DeleteDeveloper(string developerId)
        {
            var developer = await repository.GetSingle(developerId);
            if (developer == null)
                return StatusCode(StatusCodes.Status404NotFound, developer);
            developer.DeveloperId = developer.DeveloperId;
            developer.FirstName = developer.FirstName;
            developer.LastName = developer.LastName;
            developer.Description = developer.Description;
            developer.EmailAddress = developer.EmailAddress;
            developer.Country = developer.Country;
            developer.City = developer.City;
            developer.AnnualSalary = developer.AnnualSalary;
            developer.ExperienceInYears = developer.ExperienceInYears;
            developer.DoesOpenSource = developer.DoesOpenSource;

            var result = await repository.Delete(developer);
            return StatusCode(StatusCodes.Status200OK, result);
        }
        [HttpPut("UpdateDeveloper")]
        public async Task<ActionResult<Developer>> UpdateDeveloper(Developer model)
        {
            var developer = await repository.GetSingle(model.DeveloperId);
            if (developer == null)
                return StatusCode(StatusCodes.Status404NotFound, developer);

            if (ModelState.IsValid)
            {
                developer.DeveloperId = model.DeveloperId;
                developer.FirstName = model.FirstName;
                developer.LastName = model.LastName;
                developer.Description = model.Description;
                developer.EmailAddress = model.EmailAddress;
                developer.Country = model.Country;
                developer.City = model.City;
                developer.AnnualSalary = model.AnnualSalary;
                developer.ExperienceInYears = model.ExperienceInYears;
                developer.DoesOpenSource = model.DoesOpenSource;

                var result = await repository.Update(developer);
                return StatusCode(StatusCodes.Status200OK, result);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Unable to save developer record.");
            }
        }
    }
}
