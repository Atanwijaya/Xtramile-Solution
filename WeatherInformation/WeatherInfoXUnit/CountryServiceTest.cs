using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using WeatherInformation.Interfaces;
using Xunit;

namespace WeatherInfoXUnit
{
    public class CountryServiceTest
    {
        private readonly ICountryService countryService;
        public CountryServiceTest()
        {
            var services = new ServiceCollection();
            services.AddSingleton<ICountryRepository, CountryRepository>();
            services.AddSingleton<ICountryService, CountryService>();
            var serviceProvider = services.BuildServiceProvider();
            countryService = serviceProvider.GetService<ICountryService>();
        }
        [Fact]
        public async Task GetAllCountries()
        {
           
            try
            {
                var countries = await countryService.GetAllCountriesAsync();
                Assert.True(countries != null && countries.Count > 0);
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.ToString());
            }
        }
    }
}
