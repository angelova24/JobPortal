namespace JobPortal.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;
    using static Common.EntityValidationConstants.User;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            Id = Guid.NewGuid();
            JobApplications = new HashSet<UserJobs>();
        }
        
        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;

        public ICollection<UserJobs> JobApplications { get; set; }
        
        public ICollection<Article> Articles { get; set; }
    }
}
