using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherInformation.Models;

namespace WeatherInformation.Interfaces
{
    public class WeatherService : IWeatherService
    {
        //https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests
        private readonly HttpClient countryRepository;
        public WeatherService(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }
        public async Task<List<CityVM>> GetWeatherInfoByCityNameAsync(string cityName)
        {
            return await this.countryRepository.GetAllCountriesAsync();
        }
    }
}
