using kixBG.Core.Models.Brands;
using kixBG.Core.Models.Clothes;
using kixBG.Core.Models.ClothesCategories;
using kixBG.Infrastructure.Data.Entities;

namespace kixBG.Core.Contracts
{
    public interface IClothesService
    {
        Task<IEnumerable<ClothesCategoryServiceModel>> AllCategoriesAsync();
        Task<IEnumerable<BrandsServiceModel>> AllBrandsAsync();
        void AddAsync(Clothe clotheToAdd);
        Task<List<ClothesAllModel>> GetAllAsync();
        Task<Clothe> GetItemByIdAsync(int id);
        void SaveChangesAsync();
    }
}
