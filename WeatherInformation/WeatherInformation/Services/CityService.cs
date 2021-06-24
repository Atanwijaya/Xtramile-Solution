using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherInformation.Models;

namespace WeatherInformation.Interfaces
{
    public class CityService : ICityService
    {
        private readonly ICityRepository cityRepository;
        public CityService(ICityRepository cityRepository)
        {
            this.cityRepository = cityRepository;
        }
        public async Task<List<CityVM>> GetAllCitiesByCountryIDAsync(string countryID)
        {
            var cities = await this.cityRepository.GetAllCitiesByCountryIDAsync(countryID);
            return cities.Select(x => new CityVM()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
    }
}
