using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherInformation.Models;

namespace WeatherInformation.Interfaces
{
    public class WeatherService : IWeatherService
    {
        private readonly ApplicationSettings appSetting;
        private readonly IHttpClientFactory clientFactory;
        public WeatherService(IHttpClientFactory clientFactory, IOptions<ApplicationSettings> appSetting)
        {
            this.clientFactory = clientFactory;
            this.appSetting = appSetting.Value;
        }
        public async Task<WeatherConditionVM> GetWeatherConditionByCityNameAsync(string cityName)
        {
            string fullURL = string.Format(appSetting.WeatherURL + "?q={0}&units=metric&appid={1}", cityName, appSetting.AppID);
            var responseString = await clientFactory.CreateClient("WeatherHTTPClient").GetStringAsync(fullURL);
            WeatherConditionDTO weatherConditionDTO = JsonConvert.DeserializeObject<WeatherConditionDTO>(responseString);
            return new WeatherConditionVM()
            {
                Coordinate = new CoordVM()
                {
                    Latitude = weatherConditionDTO.Coord.Lat,
                    Longitude = weatherConditionDTO.Coord.Lon
                },
                Time = DateTimeOffset.FromUnixTimeSeconds(weatherConditionDTO.Dt).UtcDateTime.ToString("ddd, dd MMM yyy HH:mm:ss K"),
                Temperature = weatherConditionDTO.Main.Temp,
                Pressure = weatherConditionDTO.Main.Pressure,
                Wind = new WindVM()
                {
                    Direction = weatherConditionDTO.Wind.Deg,
                    Speed = weatherConditionDTO.Wind.Speed
                },
                Visibility = weatherConditionDTO.Visibility,
                SkyCondition = weatherConditionDTO.Weather.Select(x => x.Description).ToList(),
                Humidity = weatherConditionDTO.Main.Humidity
            };
        }
    }
}
