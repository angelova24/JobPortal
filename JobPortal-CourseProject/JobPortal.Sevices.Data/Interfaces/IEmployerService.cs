namespace JobPortal.Sevices.Data.Interfaces
{
    using Web.ViewModels.Employer;
    using Web.ViewModels.Job;
    using Web.ViewModels.User;

    public interface IEmployerService
    {
        Task<bool> EmployerExistsByUserIdAsync(string userId);

        Task<bool> EmployerExistsByPhoneNumberAsync(string phoneNumber);

        Task CreateAsync(string userId, BecomeEmployerFormModel model);

        Task<string?> GetEmployerIdByUserIdAsync(string userId);
        
        Task<IEnumerable<JobViewModel>> GetAllJobsByEmployerIdAsync(string employerId);

        Task<bool> IsAuthorOfJobByUserIdAsync(string userId, string jobId);
        
        Task<IEnumerable<CandidateViewModel>> GetAllCandidatesByJobIdAsync(string jobId);
    }
}