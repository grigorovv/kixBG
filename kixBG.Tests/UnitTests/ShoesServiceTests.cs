using kixBG.Core.Contracts;
using kixBG.Core.Services;
using kixBG.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kixBG.Tests.UnitTests
{
    public class ShoesServiceTests: BaseUnitTestClass
    {
        private IShoesService shoesService;

        [OneTimeSetUp]
        public void SetUp() => shoesService = new ShoesService(repository);

        [Test]
        public async Task AllBrands_ShouldBeCorrect()
        {
            var result = await shoesService.AllBrandsAsync();
            var brands = data.Brands;

            var resultBrandsNames = result.Select(c => c.Name).ToList();
            var databaseBrandsNames = brands.ToList().Select(c => c.Name).ToList();

            Assert.That(databaseBrandsNames, Is.EquivalentTo(resultBrandsNames));
        }

        [Test]
        public async Task Add_ShouldBeCorrect()
        {
            var shoes = await shoesService.GetAllAsync();
            Assert.That(shoes.Count(), Is.EqualTo(2));

            shoesService.AddAsync(new Shoe());

            var shoesChanged = await shoesService.GetAllAsync();
            Assert.That(shoesChanged.Count(), Is.EqualTo(3));
        }

        [Test]
        public async Task GetItemById_ShoulReturnItem()
        {
            var shoeLookedFor = await shoesService.GetShoeByIdAsync(1);
            Assert.That(Shoe.Model, Is.EqualTo(shoeLookedFor.Model));
        }

        [Test]
        public async Task DeleteItem_ShouldDelete()
        {
            var shoes = await shoesService.GetAllAsync();
            Assert.That(shoes.Count(), Is.EqualTo(3));

            shoesService.DeleteItem(ShoeToDelete);

            var shoesChanged = await shoesService.GetAllAsync();
            Assert.That(shoesChanged.Count(), Is.EqualTo(2));
        }
    }
}
