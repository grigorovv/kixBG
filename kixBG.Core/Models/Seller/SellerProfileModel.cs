using kixBG.Core.Models.Clothes;
using kixBG.Core.Models.Shoes;
using kixBG.Infrastructure.Data.Entities;

namespace kixBG.Core.Models.Seller
{
    public class SellerProfileModel
    {
        public Infrastructure.Data.Entities.Seller Seller { get; set; } = null!;
        public string CityName { get; set; } = null!;
        public string CountryName { get; set; } = null!;
        public IEnumerable<ShoeAllModel> Shoes { get; set; } = new List<ShoeAllModel>();
        public IEnumerable<ClothesAllModel> Clothes { get; set; } = new List<ClothesAllModel>();
        public SellerProfileModel(Infrastructure.Data.Entities.Seller seller, List<ShoeAllModel> shoes, List<ClothesAllModel> clothes)
        {
            Seller = seller;
            Shoes = shoes;
            Clothes = clothes;
        }
    }
}
