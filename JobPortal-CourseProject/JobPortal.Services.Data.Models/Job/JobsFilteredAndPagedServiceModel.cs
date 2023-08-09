namespace JobPortal.Services.Data.Models.Job
{
    using Web.ViewModels.Job;

    public class JobsFilteredAndPagedServiceModel
    {
        public JobsFilteredAndPagedServiceModel()
        {
            Jobs = new HashSet<JobViewModel>();
        }

        public int JobsCount { get; set; }

        public IEnumerable<JobViewModel> Jobs { get; set; }
    }
}
