using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherInformation.Models
{
    public class CityDTO
    {
        public string Id { get; set; }
        public string CountryId { get; set; }
        public string Name { get; set; }
    }
}
