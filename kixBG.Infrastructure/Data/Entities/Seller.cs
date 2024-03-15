using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static kixBG.Infrastructure.Data.Constants.DataConstants;

namespace kixBG.Infrastructure.Data.Entities
{
    [Comment("Item seller")]
    public class Seller
    {
        [Key]
        [Comment("Seller identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(sellerNameMaxLength)]
        [Comment("Seller full name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Comment("Identity GUID")]
        public string UserId { get; set; } = string.Empty;

        [Required]
        [MaxLength(sellerPhoneNumberMaxLength)]
        [Comment("Phone number to contact seller")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [Comment("City seller is situated in")]
        public int CityId { get; set; }

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

        [ForeignKey(nameof(CityId))]
        public City City { get; set; } = null!;

        public IList<Shoe> Shoes { get; set; } = new List<Shoe>();
        public IList<Clothe> Clothes { get; set; } = new List<Clothe>();
    }
}
