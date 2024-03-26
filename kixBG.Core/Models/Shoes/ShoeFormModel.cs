using kixBG.Core.Models.Brands;
using kixBG.Core.Models.ClothesCategories;
using System.ComponentModel.DataAnnotations;
using static kixBG.Infrastructure.Data.Constants.DataConstants;
using static kixBG.Infrastructure.Data.Constants.StringConstants;

namespace kixBG.Core.Models.Shoes
{
    public class ShoeFormModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = requiredMessage)]
        public string ImageURL { get; set; } = null!;

        [Required(ErrorMessage = requiredMessage)]
        public int BrandId { get; set; }

        [Required(ErrorMessage = requiredMessage)]
        [StringLength(clothingModelNameMaxLength,
            MinimumLength = clothingModelNameMinLength,
            ErrorMessage = lengthErrorMessage)]
        public string Model { get; set; } = null!;

        [Required(ErrorMessage = requiredMessage)]
        [Range(typeof(decimal),
            minimumPrice,
            maximumPrice,
            ConvertValueInInvariantCulture = true,
            ErrorMessage = "Price must be a positive number and less than {2} leva")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = requiredMessage)]
        [Range(typeof(int),
            shoeMinSize, 
            shoeMaxSize,
            ErrorMessage = shoeSizeErrorMessage)]
        public int Size { get; set; }

        [Required(ErrorMessage = requiredMessage)]
        public int Condition { get; set; }

        public IEnumerable<BrandsServiceModel> Brands { get; set; } = new List<BrandsServiceModel>();
    }
}
