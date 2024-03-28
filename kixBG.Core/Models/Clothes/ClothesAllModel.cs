using kixBG.Core.Models.ClothesCategories;

namespace kixBG.Core.Models.Clothes
{
    public class ClothesAllModel
    {
        public int Id { get; set; }
        public string ImageURL { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Size { get; set; } = null!;
        public decimal Price { get; set; }
        public int SellerId { get; set; }
        public int CategoryId { get; set; }
    }
}
