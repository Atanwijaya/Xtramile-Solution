using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherInformation.Models;

namespace WeatherInformation.Interfaces
{
    public interface IWeatherService
    {
        Task<WeatherConditionVM> GetWeatherConditionByCityNameAsync(string cityName);
    }
}
