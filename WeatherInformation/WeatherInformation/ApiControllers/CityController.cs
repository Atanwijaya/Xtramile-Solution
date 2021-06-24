using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherInformation.Interfaces;

namespace WeatherInformation.ApiControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Produces("application/json")]

    public class CityController : ControllerBase
    {
        private readonly ICityService cityService;
        public CityController(ICityService cityService)
        {
            this.cityService = cityService;
        }

        [HttpGet]
        [Route("{countryID}")]
        public async Task<IActionResult> GetAllCitiesByCountryID([FromRoute] string countryID)
        {
            var cities = await this.cityService.GetAllCitiesByCountryIDAsync(countryID);
            return Ok(cities);
        }
    }
}