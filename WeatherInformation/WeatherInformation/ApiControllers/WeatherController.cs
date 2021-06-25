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
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService weatherService;
        public WeatherController(IWeatherService weatherService)
        {
            this.weatherService = weatherService;
        }

        [HttpGet]
        [Route("{cityName}")]
        public async Task<IActionResult> GetWeatherConditionByCityName([FromRoute] string cityName)
        {
            var weatherConditionVM = await this.weatherService.GetWeatherConditionByCityNameAsync(cityName);
            return Ok(weatherConditionVM);
        }
    }
}