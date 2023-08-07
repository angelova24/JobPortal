namespace JobPortal.Web.ViewModels.Job
{
    public class JobViewModel
    {
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public int? Salary { get; set; } 

        public string CompanyName { get; set; } = null!;

        public string CompanyAddress { get; set; } = null!;

        public DateTime CreatedOn { get; set; }
    }
}
