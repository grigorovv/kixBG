using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static kixBG.Infrastructure.Data.Constants.DataConstants;

namespace kixBG.Infrastructure.Data.Entities
{
    [Comment("Shoe and/or clothe brand")]
    public class Brand
    {
        [Key]
        [Comment("Brand identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(brandNameMaxLength)]
        [Comment("Brand name")]
        public string Name { get; set; } = string.Empty;

        public IList<Clothe> Clothes { get; set; } = new List<Clothe>();
        public IList<Shoe> Shoes { get; set; } = new List<Shoe>();
    }
}
