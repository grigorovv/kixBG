using System.ComponentModel.DataAnnotations;
using static kixBG.Infrastructure.Data.Constants.DataConstants;
using static kixBG.Infrastructure.Data.Constants.StringConstants;

namespace kixBG.Core.Models.Seller
{
    public class BecomeSellerFormModel
    {
        [Required(ErrorMessage = requiredMessage)]
        [StringLength(sellerNameMaxLength, 
            MinimumLength = sellerNameMinLength,
            ErrorMessage = lengthErrorMessage)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = requiredMessage)]
        [StringLength(sellerPhoneNumberMaxLength,
            MinimumLength = sellerPhoneNumberMinLength,
            ErrorMessage = lengthErrorMessage)]
        [Display(Name = "Phone number")]
        [Phone]
        public string PhoneNumber { get; set; } = null!;

        [Required(ErrorMessage = requiredMessage)]
        public string City { get; set; } = null!;
    }
}
