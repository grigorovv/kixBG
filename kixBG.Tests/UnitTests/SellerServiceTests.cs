using kixBG.Core.Contracts;
using kixBG.Core.Services;
using kixBG.Infrastructure.Data.Common;
using kixBG.Infrastructure.Data.Common.Repository;
using kixBG.Infrastructure.Data.Entities;

namespace kixBG.Tests.UnitTests
{
    [TestFixture]
    public class SellerServiceTests : BaseUnitTestClass
    {
        private ISellerService sellerService;

        [OneTimeSetUp]
        public void SetUp() => sellerService = new SellerService(repository);


        [Test]
        public async Task ExistsById_ShouldExist()
        {
            bool exists = await sellerService.ExistsById(ShoeSeller.User.Id);

            Assert.IsTrue(exists);
        }

        [Test]
        public async Task PhoneNumberTaken_ShouldBeTaken()
        {
            bool taken = await sellerService.PhoneNumberTaken(ClotheSeller.PhoneNumber);

            Assert.IsTrue(taken);
        }

        [Test]
        public async Task GetSellerIdByUserId_ShouldBeEqual()
        {
            int sellerId = await sellerService.GetSellerIdByUserId(ClotheSeller.User.Id);

            Assert.That(ClotheSeller.Id, Is.EqualTo(sellerId));
        }

        [Test]
        public async Task GetUserIdBySellerId_ShouldBeEqual()
        {
            string userId = await sellerService.GetUserIdBySellerId(ClotheSeller.Id);

            Assert.That(ClotheSeller.User.Id, Is.EqualTo(userId));
        }

        [Test]
        public async Task GetSellerById_ShouldBeEqual()
        {
            Seller seller = await sellerService.GetSellerById(1);

            Assert.That(ShoeSeller.Id, Is.EqualTo(seller.Id));
        }

        [Test]
        public async Task Add_ShouldWork()
        {
            var sellers = repository.AllReadOnly<Seller>().ToList();
            Assert.That(sellers.Count(), Is.EqualTo(2));

            await sellerService.AddAsync("", "", "", 0);

            var sellersChanged = repository.AllReadOnly<Seller>().ToList();
            Assert.That(sellersChanged.Count(), Is.EqualTo(3));
        }
    }
}
