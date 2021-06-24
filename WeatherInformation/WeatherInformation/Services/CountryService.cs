using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherInformation.Models;

namespace WeatherInformation.Interfaces
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository countryRepository;
        public CountryService(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }
        public async Task<List<CountryDTO>> GetAllCountriesAsync()
        {
            return await this.countryRepository.GetAllCountriesAsync();
        }
    }
}
