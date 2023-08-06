namespace JobPortal.Sevices.Data.Interfaces
{
    using Web.ViewModels.Job;
    using Web.ViewModels.User;

    public interface IUserService
    {
        Task ApplyForJobAsync(string userId, string jobId);

        Task<bool> HasAppliedForThatJobAsync(string userId, string jobId);

        Task<IEnumerable<JobViewModel>> GetAllJobsByCandidateIdAsync(string candidateId);
        
        Task<string> GetFullNameByEmailAsync(string email);
        
        Task<IEnumerable<UserViewModel>> GetAllAsync();
    }
}
