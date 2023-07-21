namespace JobPortal.Sevices.Data.Interfaces
{
    using JobPortal.Web.ViewModels.Job;

    public interface IJobService
    {
        Task<IEnumerable<JobViewModel>> GetAllJobsAsync();

        Task CreateAsync(string employerId, JobAddFormModel model);
    }
}
