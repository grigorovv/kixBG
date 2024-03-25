using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static kixBG.Infrastructure.Data.Constants.DataConstants;

namespace kixBG.Infrastructure.Data.Entities
{
    [Comment("Clothing")]
    public class Clothe
    {
        [Key]
        [Comment("Clothing identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("URL of item image")]
        public string ImageURL { get; set; } = string.Empty;

        [Required]
        [Comment("Brand identifier of item")]
        public int BrandId { get; set; }

        [Required]
        [MaxLength(clothingModelNameMaxLength)]
        [Comment("Model(name) of clothing")]
        public string Model { get; set; } = string.Empty;

        [Required]
        [Comment("Seller of item identifier")]
        public int SellerId { get; set; }

        [Required]
        [Comment("Category of item")]
        public int CategoryId { get; set; }

        [Required]
        [Comment("Item price")]
        public decimal Price { get; set; }

        [Required]
        [Comment("Item size")]
        public string Size { get; set; } = string.Empty;

        [Required]
        [Comment("Item condition on a scale of 1-10")]
        public int Condition { get; set; }

        [ForeignKey(nameof(BrandId))]
        public Brand Brand { get; set; } = null!;

        [ForeignKey(nameof(SellerId))]
        public Seller Seller { get; set; } = null!;

        [ForeignKey(nameof(CategoryId))]
        public ClotheCategory Category { get; set; } = null!;

    }
}
