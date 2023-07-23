namespace JobPortal.Web.ViewModels.Job
{
    using JobPortal.Web.ViewModels.Job.Enums;
    using System.ComponentModel.DataAnnotations;

    using static Common.GeneralApplicationConstants;
    public class JobsQueryModel
    {
        public JobsQueryModel()
        {
            this.CurrentPage = DefaultPage;
            this.JobsPerPage = EntitiesPerPage;
            this.Categories = new HashSet<string>();
            this.Jobs = new HashSet<JobViewModel>();
        }

        public string? Category { get; set; }

        [Display(Name = "Search by word")]
        public string? SearchTerm { get; set; }

        [Display(Name = "Sort by")]
        public JobSorting JobSorting { get; set; }

        [Display(Name = "Current page")]
        public int CurrentPage { get; set; }

        [Display(Name = "Jobs per page")]
        public int JobsPerPage { get; set; }

        [Display(Name = "Total jobs")]
        public int TotalJobs { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public IEnumerable<JobViewModel> Jobs { get; set; }
    }
}
