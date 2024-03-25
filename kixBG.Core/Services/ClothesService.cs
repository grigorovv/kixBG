using kixBG.Core.Contracts;
using kixBG.Core.Models.Brands;
using kixBG.Core.Models.Clothes;
using kixBG.Core.Models.ClothesCategories;
using kixBG.Infrastructure.Data.Common;
using kixBG.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace kixBG.Core.Services
{
    public class ClothesService : IClothesService
    {
        private readonly IRepository repository;

        public ClothesService(IRepository repository)
        {
            this.repository = repository;
        }

        public void AddAsync(Clothe clotheToAdd)
        {
            repository.AddAsync(clotheToAdd);
            repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<BrandsServiceModel>> AllBrandsAsync()
        {
            return await repository.All<Brand>()
                .Select(b => new BrandsServiceModel()
                {
                    Id = b.Id,
                    Name = b.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ClothesCategoryServiceModel>> AllCategoriesAsync()
        {
            return await repository.All<ClotheCategory>()
                .Select(cc => new ClothesCategoryServiceModel()
                {
                    Id = cc.Id,
                    Name = cc.Name
                })
                .ToListAsync();
        }

        public async Task<List<ClothesAllModel>> GetAllAsync()
        {
            return await repository.All<Clothe>()
                .Select(c => new ClothesAllModel()
                {
                    Id = c.Id,
                    Model = c.Model,
                    ImageURL = c.ImageURL,
                    Price = c.Price,
                    Size = c.Size
                })
                .ToListAsync();
        }
    }
}
