using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using WeatherInformation.Interfaces;
using Xunit;

namespace WeatherInfoXUnit
{
    public class CountryRepositoryTest
    {
        private readonly ICountryRepository countryRepository;
        public CountryRepositoryTest()
        {
            var services = new ServiceCollection();
            services.AddSingleton<ICountryRepository, CountryRepository>();
            var serviceProvider = services.BuildServiceProvider();
            countryRepository = serviceProvider.GetService<ICountryRepository>();
        }
        [Fact]
        public async Task GetAllCountries()
        {
            try
            {
                var countries = await countryRepository.GetAllCountriesAsync();
                Assert.True(countries!= null && countries.Count != 0);
            }
            catch(Exception ex)
            {
                Assert.True(false, ex.ToString());
            }
        }
    }
}
