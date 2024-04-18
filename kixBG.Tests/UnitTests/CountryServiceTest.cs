using kixBG.Core.Contracts;
using kixBG.Core.Services;

namespace kixBG.Tests.UnitTests
{
    public class CountryServiceTest: BaseUnitTestClass
    {
        private ICountryService countryService;

        [OneTimeSetUp]
        public void SetUp() => countryService = new CountryService(repository);

        [Test]
        public async Task GetCountryById_ShouldWork()
        {
            var country = await countryService.GetCountryByIdAsync(1);
            Assert.That(country.Name, Is.EqualTo(Country.Name));
        }
    }
}
