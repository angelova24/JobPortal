namespace JobPortal.Sevices.Data.Interfaces
{
    using JobPortal.Web.ViewModels.Job;

    public interface IUserService
    {
        Task ApplyForJobAsync(string userId, string jobId);

        Task<bool> HasAppliedForThatJobAsync(string userId, string jobId);

        Task<IEnumerable<JobViewModel>> GetAllJobsByCandidateIdAsync(string candidateId);
    }
}
