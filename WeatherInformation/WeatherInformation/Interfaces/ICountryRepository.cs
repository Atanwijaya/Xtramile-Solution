using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherInformation.Models;

namespace WeatherInformation.Interfaces
{
    public interface ICountryRepository
    {
        Task<List<CountryDTO>> GetAllCountriesAsync();
    }
}
