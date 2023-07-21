namespace JobPortal.Web.ViewModels.Employer
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Employer;

    public class BecomeEmployerFormModel
    {
        [Required]
        [StringLength(CompanyNameMaxLength, MinimumLength = CompanyNameMinLength)]
        [Display(Name = "Your company name")]
        public string CompanyName { get; set; } = null!;

        [Required]
        [StringLength(CompanyAddressMaxLength, MinimumLength = CompanyAddressMinLength)]
        [Display(Name = "Your company address")]
        public string CompanyAddress { get; set; } = null!;

        [Required]
        [StringLength(PhoneNumberMaxLenght, MinimumLength = PhoneNumberMinLenght)]
        [Phone]
        [Display(Name = "Your phone")]
        public string PhoneNumber { get; set; } = null!;
    }
}
