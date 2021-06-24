using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherInformation.Models;

namespace WeatherInformation.Interfaces
{
    public interface IWeatherService
    {
        Task<List<CityVM>> GetWeatherInfoByCityNameAsync(string cityName);
    }
}
