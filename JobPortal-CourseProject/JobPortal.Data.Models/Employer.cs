namespace JobPortal.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Employer;
    public class Employer
    {
        public Employer()
        {
            this.JobOffers = new HashSet<Job>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(CompanyNameMaxLength, MinimumLength = CompanyNameMinLength)]
        public string CompanyName { get; set; } = null!;

        [Required]
        [StringLength(PhoneNumberMaxLenght, MinimumLength = PhoneNumberMinLenght)]
        public string PhoneNumber { get; set;} = null!;

        public Guid UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; } = null!;

        public virtual ICollection<Job> JobOffers { get; set; }
    }
}
