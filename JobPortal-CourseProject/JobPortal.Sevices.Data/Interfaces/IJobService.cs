namespace JobPortal.Sevices.Data.Interfaces
{
    using JobPortal.Services.Data.Models.Job;
    using JobPortal.Web.ViewModels.Job;

    public interface IJobService
    {
        Task<JobsFilteredAndPagedServiceModel> GetAllJobsAsync(JobsQueryModel queryModel);

        Task CreateAsync(string employerId, JobAddFormModel model);

        Task<JobDetailsViewModel?> GetJobByIdAsync(string jobId);

        Task<bool> ExistsByIdAsync(string jobId);
    }
}
