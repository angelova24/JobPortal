namespace JobPortal.Sevices.Data.Interfaces
{
    using JobPortal.Web.ViewModels.Employer;
    using JobPortal.Web.ViewModels.Job;

    public interface IEmployerService
    {
        Task<bool> EmployerExistsByUserIdAsync(string userId);

        Task<bool> EmployerExistsByPhoneNumberAsync(string phoneNumber);

        Task CreateAsync(string userId, BecomeEmployerFormModel model);

        Task<string?> GetEmployerIdByUserIdAsync(string userId);
        
        Task<IEnumerable<JobViewModel>> GetAllJobsByEmployerIdAsync(string employerId);

        Task<bool> IsAuthorOfJobByUserIdAsync(string userId, string jobId);
    }
}