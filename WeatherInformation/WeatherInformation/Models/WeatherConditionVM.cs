using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherInformation.Models
{
    public class WeatherConditionVM
    {
        public CoordVM Coordinate { get; set; }
        public string Time { get; set; }
        public WindVM Wind { get; set; }
        public int Visibility { get; set; }
        public List<string> SkyCondition { get; set; }
        public double Temperature { get; set; }
        public int Humidity { get; set; }
        public int Pressure { get; set; }
    }
}
