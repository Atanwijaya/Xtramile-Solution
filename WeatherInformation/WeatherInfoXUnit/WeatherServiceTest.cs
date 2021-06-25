using Microsoft.Extensions.DependencyInjection;
using Moq;
using Moq.Protected;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherInformation.Models;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using WeatherInformation.Interfaces;
using Microsoft.Extensions.Options;

namespace WeatherInfoXUnit
{
    public class WeatherServiceTest
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IOptions<ApplicationSettings> options;
        private readonly IWeatherService weatherService;
        public WeatherServiceTest()
        {
            var services = new ServiceCollection();
            services.AddHttpClient("WeatherHTTPClient");
            services.AddSingleton<IWeatherService, WeatherService>();
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json");
            IConfiguration configuration = builder.Build();
            services.Configure<ApplicationSettings>(configuration.GetSection("ApplicationSettings"));
            var serviceProvider = services.BuildServiceProvider();
            this.httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();
            IOptions<ApplicationSettings> options = serviceProvider.GetService<IOptions<ApplicationSettings>>();
            this.options = options;
            this.weatherService = serviceProvider.GetService<IWeatherService>();
        }
        [Fact]
        public async Task WeatherServiceHttpTest()
        {
            try
            {
               var weatherCon = await this.weatherService.GetWeatherConditionByCityNameAsync("London");
                Assert.True(weatherCon != null);
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.ToString());
            }
        }
    }
}
