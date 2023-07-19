namespace JobPortal.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
            this.JobApplications = new HashSet<Job>();
        }

        public ICollection<Job> JobApplications { get; set; }
    }
}
