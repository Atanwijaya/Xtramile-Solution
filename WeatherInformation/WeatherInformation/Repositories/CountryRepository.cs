using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherInformation.Models;

namespace WeatherInformation.Interfaces
{
    public class CountryRepository : ICountryRepository
    {
        public Task<List<CountryDTO>> GetAllCountriesAsync()
        {
            return Task.Run<List<CountryDTO>>(() =>
            {
                return GetAllCountries();
            });
        }
        private List<CountryDTO> GetAllCountries()
        {
            var listOfCountries = new List<CountryDTO>()
                {
                    new CountryDTO()
                    {
                        Id = "JPY",
                        Name = "Japan"

                    },
                     new CountryDTO()
                    {
                        Id = "USA",
                        Name = "United States"
                    },
                      new CountryDTO()
                    {
                        Id = "AUS",
                        Name = "Australia"
                    }
                };
            return listOfCountries;
        }
    }
}
