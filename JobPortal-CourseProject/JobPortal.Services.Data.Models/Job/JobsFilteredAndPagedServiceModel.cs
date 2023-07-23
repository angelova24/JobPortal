namespace JobPortal.Services.Data.Models.Job
{
    using JobPortal.Web.ViewModels.Job;

    public class JobsFilteredAndPagedServiceModel
    {
        public JobsFilteredAndPagedServiceModel()
        {
            this.Jobs = new HashSet<JobViewModel>();
        }

        public int JobsCount { get; set; }

        public IEnumerable<JobViewModel> Jobs { get; set; }
    }
}
