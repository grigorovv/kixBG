using kixBG.Core.Models.Brands;
using kixBG.Core.Models.Shoes;
using kixBG.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kixBG.Core.Contracts
{
    public interface IShoesService
    {
        Task<IEnumerable<BrandsServiceModel>> AllBrandsAsync();
        void AddAsync(Shoe shoeToAdd);
        Task<List<ShoeAllModel>> GetAllAsync();
        Task<Shoe> GetShoeByIdAsync(int id);
        void SaveChangesAsync();
        void DeleteItem(Shoe shoeToDelete);
    }
}
