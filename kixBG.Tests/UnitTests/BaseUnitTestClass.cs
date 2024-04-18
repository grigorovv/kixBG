using AutoMapper;
using kixBG.Infrastructure.Data;
using kixBG.Infrastructure.Data.Common;
using kixBG.Infrastructure.Data.Common.Repository;
using kixBG.Infrastructure.Data.Entities;
using kixBG.Tests.Mocks;
using Microsoft.AspNetCore.Identity;

namespace kixBG.Tests.UnitTests
{
    public class BaseUnitTestClass
    {
        protected MainDbContext data;
        protected IMapper mapper;
        protected IRepository repository;


        public IdentityUser User { get; private set; }
        public Seller ShoeSeller { get; private set; }
        public Seller ClotheSeller { get; private set; }
        public Shoe Shoe { get; private set; }
        public Shoe ShoeToDelete { get; private set; }
        public Clothe Clothe { get; private set; }
        public Clothe ClotheToDelete { get; private set; }
        public City City { get; private set; }
        public Country Country { get; private set; }

        [OneTimeSetUp]
        public void SetUp()
        {
            data = DatabaseMock.Instance;
            repository = new Repository(data);
            SeedDatabase();
        }

        private void SeedDatabase()
        {
            User = new IdentityUser()
            {
                Id = "random",
                Email = "random@gmail.com"
            };
            data.Users.Add(User);

            ShoeSeller = new Seller()
            {
                Id = 1,
                User = new IdentityUser()
                {
                    Id = "ShoeSellerUserId",
                    Email = "shoeselleruser@gmail.com"
                },
                PhoneNumber = "ShoeSellerPhoneNumber"
            };
            data.Sellers.Add(ShoeSeller);

            ClotheSeller = new Seller()
            {
                Id = 2,
                User = new IdentityUser()
                {
                    Id = "ClotheSellerUserId",
                    Email = "clotheselleruser@gmail.com"
                },
                PhoneNumber = "ClotheSellerPhoneNumber"
            };
            data.Sellers.Add(ClotheSeller);

            Shoe = new Shoe()
            {
                Id = 1,
                Model = "Test Shoe Model",
                Seller = ShoeSeller,
                ImageURL = "https://hypepoint.ca/cdn/shop/files/Air-Jordan-4-Retro-Military-Black-Product_b9174d75-a617-422a-9c65-e2e8b0ab21d0.webp?v=1711492840&width=1400",
                Brand = new Brand() { Name = "Nike" }
            };
            ShoeToDelete = new Shoe()
            {
                Id = 2,
                Model = "Test Shoe Delete Model",
                Seller = ShoeSeller,
                ImageURL = "",
                Brand = new Brand() { Name = "Adidas" }
            };
            data.Shoes.Add(Shoe);
            data.Shoes.Add(ShoeToDelete);

            Clothe = new Clothe()
            {
                Id = 1,
                Model = "Test Clothe Model",
                Seller = ClotheSeller,
                ImageURL = "https://eu.louisvuitton.com/images/is/image/lv/1/PP_VP_L/louis-vuitton-monogram-classic-scarf-s00-scarves--M70520_PM2_Front%20view.jpg",
                Brand = new Brand() { Name = "Louis Vuitton" },
                Category = new ClotheCategory() { Name = "Other" }
            };
            ClotheToDelete = new Clothe()
            {
                Id = 2,
                Model = "Test Clothe Delete Model",
                Seller = ClotheSeller,
                ImageURL = "",
                Brand = new Brand() { Name = "Gucci" },
                Category = new ClotheCategory() { Name = "Other" }
            };
            data.Clothes.Add(Clothe);
            data.Clothes.Add(ClotheToDelete);

            Country = new Country()
            {
                Id = 1,
                Name = "Bulgaria"
            };
            data.Countries.Add(Country);

            City = new City()
            {
                Id = 2,
                Name = "Varna",
                Country = this.Country
            };
            data.Cities.Add(City);


            data.SaveChanges();
        }

        [OneTimeTearDown]
        public void TearDownBase() => data.Dispose();
    }
}
