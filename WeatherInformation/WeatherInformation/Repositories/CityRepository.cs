using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherInformation.Models;

namespace WeatherInformation.Interfaces
{
    public class CityRepository : ICityRepository
    {
        public Task<List<CityDTO>> GetAllCitiesByCountryIDAsync(string countryID)
        {
            return Task.Run<List<CityDTO>>(() =>
            {
                return GetAllCitiesByCountryID(countryID);
            });
        }
        private List<CityDTO> GetAllCitiesByCountryID(string countryID)
        {
            var listOfCities = new List<CityDTO>()
                {
                    new CityDTO()
                    {
                        Id = "TYT",
                        Name = "Tokyo",
                        CountryId = "JPY"

                    },
                     new CityDTO()
                    {
                        Id = "KYT",
                        Name = "Kyoto",
                        CountryId = "JPY"
                    },
                      new CityDTO()
                    {
                        Id = "OSK",
                        Name = "Osaka",
                        CountryId = "JPY"
                    },
                       new CityDTO()
                    {
                        Id = "SPR",
                        Name = "Sapporo",
                        CountryId = "JPY"
                    },
                        new CityDTO()
                    {
                        Id = "FKK",
                        Name = "Fukuoka",
                        CountryId = "JPY"
                    },
                       new CityDTO()
                    {
                        Id = "KKB",
                        Name = "Kobe",
                        CountryId = "JPY"
                    },
                        new CityDTO()
                    {
                        Id = "HRS",
                        Name = "Hiroshima",
                        CountryId = "JPY"
                    },
                       new CityDTO()
                    {
                        Id = "SEN",
                        Name = "Sendai",
                        CountryId = "JPY"
                    },
                        new CityDTO()
                    {
                        Id = "SHB",
                        Name = "Shibuya",
                        CountryId = "JPY"
                    },
                        new CityDTO()
                    {
                        Id = "NGS",
                        Name = "Nagasaki",
                        CountryId = "JPY"
                    },
                        new CityDTO()
                    {
                        Id = "NYC",
                        Name = "New York",
                        CountryId = "USA"
                    },
                        new CityDTO()
                    {
                        Id = "SFS",
                        Name = "San Fransisco",
                        CountryId = "USA"
                    },
                        new CityDTO()
                    {
                        Id = "CHI",
                        Name = "Chicago",
                        CountryId = "USA"
                    },
                        new CityDTO()
                    {
                        Id = "LAS",
                        Name = "Los Angeles",
                        CountryId = "USA"
                    },
                        new CityDTO()
                    {
                        Id = "BOS",
                        Name = "Boston",
                        CountryId = "USA"
                    },
                        new CityDTO()
                    {
                        Id = "SET",
                        Name = "Seattle",
                        CountryId = "USA"
                    },
                        new CityDTO()
                    {
                        Id = "AUS",
                        Name = "Austin",
                        CountryId = "USA"
                    },
                        new CityDTO()
                    {
                        Id = "WDC",
                        Name = "Washington DC",
                        CountryId = "USA"
                    },
                        new CityDTO()
                    {
                        Id = "SND",
                        Name = "San Diego",
                        CountryId = "USA"
                    },
                        new CityDTO()
                    {
                        Id = "PHI",
                        Name = "Philadelphia",
                        CountryId = "USA"
                    },
                        new CityDTO()
                    {
                        Id = "SYD",
                        Name = "Sydney",
                        CountryId = "AUS"
                    },
                        new CityDTO()
                    {
                        Id = "MEL",
                        Name = "Melbourne",
                        CountryId = "AUS"
                    },
                        new CityDTO()
                    {
                        Id = "PER",
                        Name = "Perth",
                        CountryId = "AUS"
                    },
                        new CityDTO()
                    {
                        Id = "ADE",
                        Name = "Adelaide",
                        CountryId = "AUS"
                    },
                        new CityDTO()
                    {
                        Id = "BRI",
                        Name = "Brisbane",
                        CountryId = "AUS"
                    },
                        new CityDTO()
                    {
                        Id = "CAN",
                        Name = "Canberra",
                        CountryId = "AUS"
                    },
                        new CityDTO()
                    {
                        Id = "HOB",
                        Name = "Hobart",
                        CountryId = "AUS"
                    },
                        new CityDTO()
                    {
                        Id = "DAR",
                        Name = "Darwin",
                        CountryId = "AUS"
                    },
                        new CityDTO()
                    {
                        Id = "NEW",
                        Name = "Newcastle",
                        CountryId = "AUS"
                    }
                };
            return listOfCities.Where(x => x.CountryId == countryID).ToList();
        }
    }
}
