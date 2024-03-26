using kixBG.Core.Contracts;
using kixBG.Core.Models.Brands;
using kixBG.Core.Models.Shoes;
using kixBG.Infrastructure.Data.Common;
using kixBG.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace kixBG.Core.Services
{
    public class ShoesService : IShoesService
    {
        private readonly IRepository repository;

        public ShoesService(IRepository repository)
        {
            this.repository = repository;
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

        public void AddAsync(Shoe shoeToAdd)
        {
            repository.AddAsync(shoeToAdd);
            repository.SaveChangesAsync();
        }

        public async Task<List<ShoeAllModel>> GetAllAsync()
        {
            return await repository.All<Shoe>()
                .Select(s => new ShoeAllModel()
                {
                    Id = s.Id,
                    Model = s.Model,
                    ImageURL = s.ImageURL,
                    Price = s.Price,
                    Size = s.Size.ToString(),
                    SellerId = s.SellerId
                })
                .ToListAsync();
        }

        public void SaveChangesAsync()
        {
            repository.SaveChangesAsync();
        }

        public async Task<Shoe> GetShoeByIdAsync(int id)
        {
            return await repository.All<Shoe>()
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync();
        }

        public void DeleteItem(Shoe shoeToDelete)
        {
            repository.DeleteItem(shoeToDelete);
        }
    }
}
