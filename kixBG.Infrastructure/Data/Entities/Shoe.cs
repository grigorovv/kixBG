using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static kixBG.Infrastructure.Data.Constants.DataConstants;

namespace kixBG.Infrastructure.Data.Entities
{
    [Comment("Shoe")]
    public class Shoe
    {
        [Key]
        [Comment("Shoe identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("URL of item image")]
        public string ImageURL { get; set; } = string.Empty;

        [Required]
        [Comment("Brand identifier of item")]
        public int BrandId { get; set; }

        [Required]
        [MaxLength(shoeModelNameMaxLength)]
        [Comment("Model(name) of shoe")]
        public string Model { get; set; } = string.Empty;

        [Required]
        [Comment("Seller of item identifier")]
        public int SellerId { get; set; }

        [Required]
        [Comment("Item price")]
        public decimal Price { get; set; }

        [Required]
        [Comment("Item condition on a scale of 1-10")]
        public int Condition { get; set; }

        [Required]
        [Comment("Shoe size")]
        public int Size { get; set; }

        [ForeignKey(nameof(SellerId))]
        public Seller Seller { get; set; } = null!;

        [ForeignKey(nameof(BrandId))]
        public Brand Brand { get; set; } = null!;

    }
}
