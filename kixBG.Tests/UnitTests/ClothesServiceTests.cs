using kixBG.Core.Contracts;
using kixBG.Core.Services;
using kixBG.Infrastructure.Data.Entities;

namespace kixBG.Tests.UnitTests
{
    [TestFixture]
    public class ClothesServiceTests: BaseUnitTestClass
    {
        private IClothesService clothesService;

        [OneTimeSetUp]
        public void SetUp() => clothesService = new ClothesService(repository);

        [Test]
        public async Task AllCategories_ShouldBeCorrect()
        {
            var result = await clothesService.AllCategoriesAsync();
            var categories = data.ClotheCategories;

            var resultCategoriesNames = result.Select(c => c.Name).ToList();
            var databaseCategoriesNames = categories.ToList().Select(c => c.Name).ToList();

            Assert.That(databaseCategoriesNames, Is.EquivalentTo(resultCategoriesNames));
        }

        [Test]
        public async Task AllBrands_ShouldBeCorrect()
        {
            var result = await clothesService.AllBrandsAsync();
            var brands = data.Brands;

            var resultBrandsNames = result.Select(c => c.Name).ToList();
            var databaseBrandsNames = brands.ToList().Select(c => c.Name).ToList();

            Assert.That(databaseBrandsNames, Is.EquivalentTo(resultBrandsNames));
        }

        [Test]
        public async Task Add_ShouldBeCorrect()
        {
            var clothes = await clothesService.GetAllAsync();
            Assert.That(clothes.Count(), Is.EqualTo(2));

            clothesService.AddAsync(new Clothe());

            var clothesChanged = await clothesService.GetAllAsync();
            Assert.That(clothesChanged.Count(), Is.EqualTo(3));
        }

        [Test]
        public async Task GetItemById_ShoulReturnItem()
        {
            var clothingLookedFor = await clothesService.GetItemByIdAsync(1);
            Assert.That(Clothe.Model, Is.EqualTo(clothingLookedFor.Model));
        }

        [Test]
        public async Task DeleteItem_ShouldDelete()
        {
            var clothes = await clothesService.GetAllAsync();
            Assert.That(clothes.Count(), Is.EqualTo(3));

            clothesService.DeleteItem(ClotheToDelete);

            var clothesChanged = await clothesService.GetAllAsync();
            Assert.That(clothesChanged.Count(), Is.EqualTo(2));
        }
    }
}
