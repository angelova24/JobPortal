namespace JobPortal.Web.ViewModels.Job
{
    using Employer;
    
    public class JobDetailsViewModel
    {
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Requirements { get; set; } = null!;

        public int? Salary { get; set; }
        
        public DateTime CreatedOn { get; set; }

        public EmployerInfoViewModel EmployerInfo { get; set; } = null!;
    }
}
