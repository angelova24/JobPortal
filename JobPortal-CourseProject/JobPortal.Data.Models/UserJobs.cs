namespace JobPortal.Data.Models
{
    public class UserJobs
    {
        public Guid CandidateId { get; set; }

        public ApplicationUser Candidate { get; set; } = null!;

        public Guid JobId { get; set; }

        public Job Job { get; set; } = null!;

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}
