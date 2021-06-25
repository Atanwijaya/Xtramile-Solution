using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using WeatherInformation.Interfaces;
using Xunit;

namespace WeatherInfoXUnit
{
    public class CityServiceTest
    {
        private readonly ICityService cityService;
        public CityServiceTest()
        {
            var services = new ServiceCollection();
            services.AddSingleton<ICityRepository, CityRepository>();
            services.AddSingleton<ICityService, CityService>();
            var serviceProvider = services.BuildServiceProvider();
            cityService = serviceProvider.GetService<ICityService>();
        }
        [Fact]
        public async Task TestGetAllCitiesByCountryID()
        {
            try
            {
                var cities = await cityService.GetAllCitiesByCountryIDAsync("JPY");
                Assert.True(cities != null && cities.Count > 0);
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.ToString());
            }
        }
    }
}
