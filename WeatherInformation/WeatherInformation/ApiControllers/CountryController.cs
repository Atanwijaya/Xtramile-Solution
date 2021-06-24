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

    public class CountryController : ControllerBase
    {
        private readonly ICountryService countryService;
        public CountryController(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            var countries = await this.countryService.GetAllCountriesAsync();
            return Ok(countries);
        }
    }
}