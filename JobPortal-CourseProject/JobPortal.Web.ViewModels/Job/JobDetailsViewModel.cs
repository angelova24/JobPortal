namespace JobPortal.Web.ViewModels.Job
{
    public class JobDetailsViewModel
    {
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Requirements { get; set; } = null!;

        public int? Salary { get; set; }

        public string EmployerName { get; set; } = null!;

        public string CompanyName { get; set; } = null!;

        public string CompanyAddress { get; set; } = null!;
    }
}
