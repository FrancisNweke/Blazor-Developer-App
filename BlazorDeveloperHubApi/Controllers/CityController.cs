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

namespace Server_Blazor_Hub_App.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("_MyAllowSpecificOrigins")]
    public class CityController : ControllerBase
    {
        private readonly ICity repository;

        public CityController(ICity repository)
        {
            this.repository = repository;
        }
        [HttpGet("GetAllCity")]
        public async Task<ActionResult<IEnumerable<City>>> GetAllCity()
        {
            var cities = await repository.GetAll();

            return StatusCode(StatusCodes.Status200OK, cities);
        }
        [SwaggerOperation(Summary = "Gets a list of city by country code", Description = "All cities with the same country code.")]
        [HttpGet("GetAllCityByCountryCode/{countryCode}")]
        public async Task<ActionResult<IEnumerable<City>>> GetAllCityByCountryCode(string countryCode)
        {
            var city = await repository.GetAllByCountryCode(countryCode);

            return StatusCode(StatusCodes.Status200OK, city);
        }
        [HttpGet("GetSingleCity/{id}")]
        public async Task<ActionResult<City>> GetSingleCity(string id)
        {
            var city = await repository.GetSingle(id);
            return StatusCode(StatusCodes.Status200OK, city);
        }
        [HttpPost("AddCity")]
        public async Task<ActionResult<City>> AddCity(CityViewModel model)
        {
            if (ModelState.IsValid)
            {
                City city = new City
                {
                    Code = model.Code,
                    Description = model.Description,
                    CountryCode = model.CountryCode
                };
                var result = await repository.Add(city);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            else
            {
                //ModelState.AddModelError(StatusCodes.Status400BadRequest.ToString(), "Unable to save state record.")
                return StatusCode(StatusCodes.Status400BadRequest, "Unable to save city record.");
            }
        }
        [HttpDelete("DeleteCity")]
        public async Task<ActionResult<City>> DeleteCity(string id)
        {
            var city = await repository.GetSingle(id);
            if (city == null)
                return StatusCode(StatusCodes.Status404NotFound, city);

            city.Code = city.Code;
            city.Description = city.Description;
            city.CountryCode = city.CountryCode;

            var result = await repository.Delete(city);
            return StatusCode(StatusCodes.Status200OK, result);
        }
        [HttpPut("UpdateCity")]
        public async Task<ActionResult<City>> UpdateCity(CityViewModel model)
        {
            var city = await repository.GetSingle(model.Code);
            if (city == null)
                return StatusCode(StatusCodes.Status404NotFound, city);
            if (ModelState.IsValid)
            {

                city.Code = model.Code;
                city.Description = model.Description;
                city.CountryCode = model.CountryCode;

                var result = await repository.Update(city);
                return StatusCode(StatusCodes.Status200OK, result);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Unable to save city record.");
            }
        }
    }
}
