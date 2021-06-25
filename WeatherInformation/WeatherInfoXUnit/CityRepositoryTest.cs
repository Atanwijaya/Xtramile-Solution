using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using WeatherInformation.Interfaces;
using Xunit;

namespace WeatherInfoXUnit
{
    public class CityRepositoryTest
    {
        private readonly ICityRepository cityRepository;
        public CityRepositoryTest()
        {
            var services = new ServiceCollection();
            services.AddSingleton<ICityRepository, CityRepository>();
            var serviceProvider = services.BuildServiceProvider();
            cityRepository = serviceProvider.GetService<ICityRepository>();
        }
        [Fact]
        public async Task TestGetAllCitiesByCountryID()
        {
            try
            {
                var cities = await cityRepository.GetAllCitiesByCountryIDAsync("JPY");
                Assert.True(cities!= null && cities.Count > 0);
            }catch(Exception ex)
            {
                Assert.True(false, ex.ToString());
            }
        }
    }
}
