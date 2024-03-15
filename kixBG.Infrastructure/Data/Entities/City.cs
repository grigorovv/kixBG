using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static kixBG.Infrastructure.Data.Constants.DataConstants;

namespace kixBG.Infrastructure.Data.Entities
{
    [Comment("Seller city")]
    public class City
    {
        [Key]
        [Comment("City identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(cityNameMaxLength)]
        [Comment("City name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Comment("Country city is situated in")]
        public int CountryId { get; set; }

        [ForeignKey(nameof(CountryId))]
        public Country Country { get; set; } = null!;
    }
}
