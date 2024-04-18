using kixBG.Core.Contracts;
using kixBG.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kixBG.Tests.UnitTests
{
    public class CityServiceTest: BaseUnitTestClass
    {
        private ICityService cityService;

        [OneTimeSetUp]
        public void SetUp() => cityService = new CityService(repository);

        [Test]
        public async Task GetAll_ShouldWork()
        {
            var cities = await cityService.GetAllAsync();
            Assert.That(cities.Count(), Is.EqualTo(1)); 
        }

        [Test]
        public void FindIdByName_ShouldWork()
        {
            var cityId = cityService.FindIdByName("Varna");
            Assert.That(cityId, Is.EqualTo(2)); 
        }
    }
}
