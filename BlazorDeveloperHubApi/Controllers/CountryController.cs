using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorAPIShared.Models;
using BlazorAPIShared.ViewModels;
using BlazorDeveloperHubApi.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BlazorDeveloperHubApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("_MyAllowSpecificOrigins")]
    public class CountryController : ControllerBase
    {
        private readonly ICountry repository;

        public CountryController(ICountry repository)
        {
            this.repository = repository;
        }
        [SwaggerOperation(Summary = "Gets a list of Countries")]
        [HttpGet("GetAllCountry")]
        public async Task<ActionResult<IEnumerable<Country>>> GetAllCountry()
        {
            var countries = await repository.GetAll();

            return StatusCode(StatusCodes.Status200OK, countries);
        }
       
        [SwaggerOperation(Summary = "Gets a single of country by id")]
        [HttpGet("GetSingleCountry/{id}")]
        public async Task<ActionResult<Country>> GetSingleCountry(string id)
        {
            var countries = await repository.GetSingle(id);
            return StatusCode(StatusCodes.Status200OK, countries);
        }
        [HttpPost("AddCountry")]
        public async Task<ActionResult<Country>> AddCountry(CountryViewModel model)
        {

            if (ModelState.IsValid)
            {
                Country country = new Country
                {
                    Code = model.Code,
                    Description = model.Description
                };
                var result = await repository.Add(country);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Unable to save country record.");
            }
        }
        [HttpDelete("DeleteCountry")]
        public async Task<ActionResult<Country>> DeleteCountry(string id)
        {
            var country = await repository.GetSingle(id);
            if (country == null)
                return StatusCode(StatusCodes.Status404NotFound, country);

            country.Code = country.Code;
            country.Description = country.Description;

            var result = await repository.Delete(country);

            return StatusCode(StatusCodes.Status200OK, result);
        }
        [HttpPut("UpdateCountry")]
        public async Task<ActionResult<Country>> UpdateCountry(CountryViewModel model)
        {
            var country = await repository.GetSingle(model.Code);
            if (country == null)
                return StatusCode(StatusCodes.Status404NotFound, country);
            if (ModelState.IsValid)
            {
                country.Code = model.Code;
                country.Description = model.Description;

                var result = await repository.Update(country);
                return StatusCode(StatusCodes.Status200OK, result);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Unable to update country record.");
            }
        }
    }
}
