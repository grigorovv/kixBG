using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static kixBG.Infrastructure.Data.Constants.DataConstants;

namespace kixBG.Infrastructure.Data.Entities
{
    [Comment("Country of cities")]
    public class Country
    {
        [Key]
        [Comment("Country identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(countryNameMaxLength)]
        [Comment("Country name")]
        public string Name { get; set; } = string.Empty;

        public IList<City> Cities { get; set; } = new List<City>();
    }
}
