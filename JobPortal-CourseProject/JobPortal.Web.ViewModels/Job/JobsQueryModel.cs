namespace JobPortal.Web.ViewModels.Job
{
    using System.ComponentModel.DataAnnotations;
    using Enums;
    using static Common.GeneralApplicationConstants;
    public class JobsQueryModel
    {
        public JobsQueryModel()
        {
            CurrentPage = DefaultPage;
            JobsPerPage = EntitiesPerPage;
            Categories = new HashSet<string>();
            Jobs = new HashSet<JobViewModel>();
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
