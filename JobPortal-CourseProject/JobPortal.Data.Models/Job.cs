namespace JobPortal.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using JobPortal.Data.Models.Interfaces;

    using static Common.EntityValidationConstants.Job;

    public class Job : ISoftDeletable
    {
        public Job()
        {
            this.Id = Guid.NewGuid();
            this.Candidates = new HashSet<UserJobs>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(TitleMaxLenght, MinimumLength = TitleMinLenght)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLenght, MinimumLength = DescriptionMinLenght)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(RequirementsMaxLenght, MinimumLength = RequirementsMinLenght)]
        public string Requirements { get; set; } = null!;

        public int? Salary { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;

        public Guid EmployerId { get; set; }

        public virtual Employer Employer { get; set; } = null!;

        public ICollection<UserJobs> Candidates { get; set; }
        
        public DateTime? DeletedOn { get; set; }
    }
}
