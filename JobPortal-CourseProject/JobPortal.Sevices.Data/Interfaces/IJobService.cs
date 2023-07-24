namespace JobPortal.Sevices.Data.Interfaces
{
    using JobPortal.Services.Data.Models.Job;
    using JobPortal.Web.ViewModels.Job;

    public interface IJobService
    {
        Task<JobsFilteredAndPagedServiceModel> GetAllJobsAsync(JobsQueryModel queryModel);

        Task<string> CreateAndReturnIdAsync(string employerId, JobAddFormModel model);

        Task<JobDetailsViewModel> GetJobDetailsByIdAsync(string jobId);

        Task<bool> ExistsByIdAsync(string jobId);

        Task<JobAddFormModel> GetJobForEditByIdAsync(string jobId);

        Task EditJobById(string jobId, JobAddFormModel model);
    }
}
